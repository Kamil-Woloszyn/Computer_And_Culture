/*
 * CREATED BY: KAMIL WOLOSZYN
 * DATE: 10th March 2025
 * FUNCTION: Script for the UI System called UI_Manager which controls all behaviour relating to changing screens
 */
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    [Serializable]
    public class UI_OBJECTS
    {
        public GameObject gameObjectReferance;
        public UI_Tabs key;

    }
    [SerializeField]
    public UI_OBJECTS[] tabs = { };

    private UI_Tabs currentTab = UI_Tabs.LOGIN_SCREEN;
    private UI_Tabs previousTab = UI_Tabs.QUIT;
    [SerializeField]
    public bool ingame_Flag = false;
    
    public static UI_Manager Singleton = null;
    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(Singleton);
        }
        else
        {
            Singleton = this;
        }
    }
    private void Start()
    {
        if(ingame_Flag)
        {
            currentTab = UI_Tabs.GAME_GAMEPLAY_SCREEN;
        }
        previousTab = currentTab;
        SelectNewUI(currentTab);
    }

    /// <summary>
    /// Public function which goes through validation before chaning tabs
    /// </summary>
    /// <param name="target"></param>
    public void ChangeUITab(UI_Tabs target)
    {
        if (currentTab == target) return;
        if (!ValidateTabChange(target)) return;
        if (target == UI_Tabs.QUIT) QuitGame();
        //Code for changing the tabs from here on
        DisableAllUI();
        SelectNewUI(target);
        previousTab = currentTab;
        currentTab = target;
    }

    /// <summary>
    /// Function which has custom rulesets which control whether or not actions are allowed in the UI
    /// </summary>
    /// <param name="_target"></param>
    /// <returns></returns>
    private bool ValidateTabChange(UI_Tabs _target)
    {
        bool isItOkToChangeTabs = true;

        //TO-DO RULES TO BE IMPLEMENTED - Special Behaviours 
        if (_target == UI_Tabs.STUDENT_GRADES_SCREEN)
        {
            UI_MainMenu.Singleton.SET_TEACHER_JOIN_CODE_STUDENT_GRADES_TEXT(PlayerPrefs.GetString("RoomCode"));
        }
        else if (_target == UI_Tabs.MAIN_MENU_TEACHER_SCREEN)
        {
            UI_MainMenu.Singleton.SET_TEACHER_JOIN_CODE_MAIN_MENU_TEXT(PlayerPrefs.GetString("RoomCode"));
        }
        else if (_target == UI_Tabs.GAME_GAMEPLAY_SCREEN)
        {
            SceneManager.LoadScene(1);
            ingame_Flag = true;
        }
        else if (_target == UI_Tabs.MAIN_MENU_STUDENT_SCREEN && (currentTab == UI_Tabs.GAME_GAMEPLAY_SCREEN || currentTab == UI_Tabs.GAME_HELP_INSTRUCTIONS_SCREEN || currentTab == UI_Tabs.GAME_GAMEOVER_SCREEN))
        {
            SceneManager.LoadScene(0);

            ingame_Flag = true;
        }
        return isItOkToChangeTabs;
    }

    /// <summary>
    /// Function to go back to the previous tab 
    /// </summary>
    public void UI_GoBack()
    {
        Debug.Log("Going Back, Current Tab: " + currentTab + " , Previous Tab: " + previousTab);
        DisableAllUI();
        SelectNewUI(previousTab);
        //Rotating the tabs around as we do not save any previous tabs (creating an infinite tab loop possible be careful)
        UI_Tabs temp = previousTab;
        previousTab = currentTab;
        currentTab = temp;
    }

    /// <summary>
    /// Function to disable all UI elements references active in the scene
    /// </summary>
    private void DisableAllUI()
    {
        foreach (var tab in tabs)
        {
            //Disabling all UI objects
             tab.gameObjectReferance.SetActive(false);
        }
    }

    /// <summary>
    /// Function to enable all UI (has not been used yet)
    /// </summary>
    public void EnableAllUI()
    {
        foreach (var tab in tabs)
        {
            //Disabling all UI objects
            tab.gameObjectReferance.SetActive(true);
        }
    }

    /// <summary>
    /// Function to select a new UI based on passed in target
    /// </summary>
    /// <param name="_target"></param>
    private void SelectNewUI(UI_Tabs _target)
    {
        foreach(var tab in tabs)
        {
            if (tab.key == _target)
            {
                //Enabling Correct Tab GameObject Reference
                tab.gameObjectReferance.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Function to quit the game
    /// </summary>
    private void QuitGame()
    {
        Debug.Log("Exitting Game...");
        //Close the application completely
        Application.Quit();
    }

    /// <summary>
    /// Function to get the current tab
    /// </summary>
    /// <returns></returns>
    public UI_Tabs GetCurrentTab()
    {
        return currentTab;
    }

    /// <summary>
    /// Function to get the previous tab
    /// </summary>
    /// <returns></returns>
    public UI_Tabs GetPreviousTab()
    {
        return currentTab;
    }
}
