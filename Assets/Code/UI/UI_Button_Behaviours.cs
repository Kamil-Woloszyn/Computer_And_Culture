using UnityEngine;

public class UI_Button_Behaviours : MonoBehaviour
{
    public void GOTO_LOGIN_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.LOGIN_SCREEN);
    }

    public void GOTO_MAIN_MENU_STUDENT_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_STUDENT_SCREEN);
    }

    public void GOTO_MAIN_MENU_TEACHER_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_TEACHER_SCREEN);
    }

    public void GOTO_INSTRUCTIONS_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.INSTRUCTIONS_SCREEN);
    }

    public void GOTO_STUDENT_GRADES_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.STUDENT_GRADES_SCREEN);
    }

    public void GOTO_DIFFICULTY_SELECT_SCREEN()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.DIFFICULTY_SELECT_SCREEN);
    }

    public void GOTO_QUIT_GAME()
    {
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.QUIT);
    }

    public void GOTO_BACK_BUTTON_PRESSED()
    {
        UI_Manager.Singleton.UI_GoBack();
    }
}
