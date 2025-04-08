using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
            DontDestroyOnLoad(Singleton);
        }
    }
    private void Start()
    {
        SelectNewUI(currentTab);
    }

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
    
    

    public void UI_GoBack()
    {
        DisableAllUI();
        SelectNewUI(previousTab);

        //Rotating the tabs around as we do not save any previous tabs (creating an infinite tab loop possible be careful)
        UI_Tabs temp = previousTab;
        previousTab = currentTab;
        currentTab = temp;
    }

    private void DisableAllUI()
    {
        foreach (var tab in tabs)
        {
            //Disabling all UI objects
             tab.gameObjectReferance.SetActive(false);
        }
    }

    public void EnableAllUI()
    {
        foreach (var tab in tabs)
        {
            //Disabling all UI objects
            tab.gameObjectReferance.SetActive(true);
        }
    }

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

    private bool ValidateTabChange(UI_Tabs _target)
    {
        bool isItOkToChangeTabs = true;

        //TO-DO RULES TO BE IMPLEMENTED
        if(_target == UI_Tabs.STUDENT_GRADES_SCREEN)
        {
            UI_MainMenu.Singleton.SET_TEACHER_JOIN_CODE_STUDENT_GRADES_TEXT(PlayerPrefs.GetString("RoomCode"));
            

        }
        else if (_target == UI_Tabs.MAIN_MENU_TEACHER_SCREEN)
        {
            UI_MainMenu.Singleton.SET_TEACHER_JOIN_CODE_MAIN_MENU_TEXT(PlayerPrefs.GetString("RoomCode"));
        }
        return isItOkToChangeTabs;
    }

    private void QuitGame()
    {
        Debug.Log("Exitting Game...");
        //Close the application completely
        Application.Quit();
    }

    public UI_Tabs GetCurrentTab()
    {
        return currentTab;
    }

    public UI_Tabs GetPreviousTab()
    {
        return currentTab;
    }
}
