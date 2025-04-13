/*
 * CREATED BY: KAMIL WOLOSZYN
 * DATE: 5th March 2025
 * FUNCTION: Serialized Object of type enum which will be used as a key for changing tabs easily through code
 */
[System.Serializable]
public enum UI_Tabs
{
    //MAIN MENU
    LOGIN_SCREEN,
    MAIN_MENU_STUDENT_SCREEN,
    MAIN_MENU_TEACHER_SCREEN,
    INSTRUCTIONS_SCREEN,
    STUDENT_GRADES_SCREEN,
    DIFFICULTY_SELECT_SCREEN,
    SETTINGS_SCREEN,
    QUIT,
    //Gameplay UI
    GAME_GAMEPLAY_SCREEN,
    GAME_GAMEOVER_SCREEN,
    GAME_HELP_INSTRUCTIONS_SCREEN
}
