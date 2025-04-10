using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Test : MonoBehaviour
{
    public Button LOGIN_SCREEN;
    public Button MAIN_MENU_STUDENT_SCREEN;
    public Button MAIN_MENU_TEACHER_SCREEN;
    public Button INSTRUCTIONS_SCREEN;
    public Button STUDENT_GRADES_SCREEN;
    public Button DIFFICULTY_SELECT_SCREEN;
    public Button SETTINGS_SCREEN;
    public Button QUIT;

    private void Start()
    {
        LOGIN_SCREEN.onClick.AddListener(GOTO_LOGINSCREEN);
        MAIN_MENU_STUDENT_SCREEN.onClick.AddListener(GOTO_MAIN_MENU_STUDENT_SCREEN);
        MAIN_MENU_TEACHER_SCREEN.onClick.AddListener(GOTO_MAIN_MENU_TEACHER_SCREEN);
        INSTRUCTIONS_SCREEN.onClick.AddListener(GOTO_INSTRUCTIONS_SCREEN);
        STUDENT_GRADES_SCREEN.onClick.AddListener(GOTO_STUDENT_GRADES_SCREEN);
        DIFFICULTY_SELECT_SCREEN.onClick.AddListener(GOTO_DIFFICULTY_SELECT_SCREEN);
        SETTINGS_SCREEN.onClick.AddListener(GOTO_SETTINGSCREEN);
        QUIT.onClick.AddListener(GOTO_QUIT);
    }

    private void GOTO_LOGINSCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.LOGIN_SCREEN);
    }

    private void GOTO_SETTINGSCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.SETTINGS_SCREEN);
    }

    private void GOTO_MAIN_MENU_STUDENT_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_STUDENT_SCREEN);
    }
    private void GOTO_MAIN_MENU_TEACHER_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_TEACHER_SCREEN);
    }
    private void GOTO_INSTRUCTIONS_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.INSTRUCTIONS_SCREEN);
    }
    private void GOTO_STUDENT_GRADES_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.STUDENT_GRADES_SCREEN);
    }
    private void GOTO_DIFFICULTY_SELECT_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.DIFFICULTY_SELECT_SCREEN);
    }
    private void GOTO_QUIT()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.QUIT);
    }

}
