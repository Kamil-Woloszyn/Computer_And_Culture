/*
 * CREATED BY: KAMIL WOLOSZYN
 * DATE: 13th April 2025
 * FUNCTION: Script for controlling UI behaviour in the gameplay section of the game
 */
using UnityEngine;
using UnityEngine.UI;

public class UI_Gameplay : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button exitToMainMenuButton = null;
    [SerializeField]
    private Button helpInstructionsButton = null;

    private static UI_Gameplay Singleton = null;

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
        //Adding Listeners to buttons for when they are clicked on in the UI
        exitToMainMenuButton.onClick.AddListener(GOTO_MAINMENU_STUDENT);
        helpInstructionsButton.onClick.AddListener(GOTO_INSTRUCTIONS_GAMEPLAY);
    }

    /// <summary>
    /// Function that switches the UI to MAIN_MENU_STUDENT_SCREEN
    /// </summary>
    private void GOTO_MAINMENU_STUDENT()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_STUDENT_SCREEN);
    }

    /// <summary>
    /// Function that switches the UI to GAME_HELP_INSTRUCTIONS_SCREEN
    /// </summary>
    private void GOTO_INSTRUCTIONS_GAMEPLAY()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.GAME_HELP_INSTRUCTIONS_SCREEN);
    }


}
