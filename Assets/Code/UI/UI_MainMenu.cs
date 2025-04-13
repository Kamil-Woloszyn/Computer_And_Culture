/*
 * CREATED BY: KAMIL WOLOSZYN
 * DATE: 5th March 2025
 * FUNCTION: Script for controlling more detailed tasks in the main menu 
 */
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    [Header("Login Screen")]
    [SerializeField]
    TextMeshProUGUI STUDENT_NAME_INPUTFIELD = null;
    [SerializeField]
    TextMeshProUGUI STUDENT_JOIN_CODE_INPUTFIELD = null;
    [SerializeField]
    TextMeshProUGUI TEACHER_USERNAME_INPUTFIELD = null;
    [SerializeField]
    TextMeshProUGUI TEACHER_PASSWORD_INPUTFIELD = null;
    [SerializeField]
    Button STUDENT_JOIN_BUTTON = null;
    [SerializeField]
    Button TEACHER_LOGIN_BUTTON = null;
    [SerializeField]
    Button TEACHER_REGISTER_BUTTON = null;

    [Header("Main Menu - Student Screen")]
    [SerializeField]
    Button STUDENT_RAISE_HAND_BUTTON = null;

    [Header("Main Menu - Teacher Screen")]
    [SerializeField]
    Button TEACHER_CREATE_NEW_JOIN_CODE_BUTTON = null;
    [SerializeField]
    TextMeshProUGUI TEACHER_JOIN_CODE_MAIN_MENU_TEXT = null;


    [Header("Instructions Screen")]
    [SerializeField]
    TextMeshProUGUI STUDENT_INSTRUCTIONS_TEXT = null;

    [Header("Student Grades Screen")]
    [SerializeField]
    TextMeshProUGUI TEACHER_STUDENTS_NAME_TEXT = null;
    [SerializeField]
    TextMeshProUGUI TEACHER_STUDENTS_GRADE_TEXT = null;
    [SerializeField]
    TextMeshProUGUI TEACHER_JOIN_CODE_STUDENT_GRADES_TEXT = null;


    [Header("Difficulty Select Screen")]
    [SerializeField]
    Button STUDENT_EASY_DIFFICULTY_BUTTON = null;
    [SerializeField]
    Button STUDENT_MEDIUM_DIFFICULTY_BUTTON = null;
    [SerializeField]
    Button STUDENT_HARD_DIFFICULTY_BUTTON = null;

    /* PRIVATE
     * VARIABLES
     */
    private float time;
    private bool studentRaisedHandFlag = false;



    public static UI_MainMenu Singleton = null;
    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }
    }

    private void Start()
    {
        //LOGIN START FUNCTION
        STUDENT_JOIN_BUTTON.onClick.AddListener(LoginPage_Student_Login);
        TEACHER_LOGIN_BUTTON.onClick.AddListener(LoginPage_Teacher_Login);
        TEACHER_REGISTER_BUTTON.onClick.AddListener(LoginPage_Teacher_Register);
        STUDENT_RAISE_HAND_BUTTON.onClick.AddListener(MainMenu_Student_RaiseHand);

        STUDENT_EASY_DIFFICULTY_BUTTON.onClick.AddListener(StartGame_Student_EasyDifficulty);
        STUDENT_MEDIUM_DIFFICULTY_BUTTON.onClick.AddListener(StartGame_Student_MediumDifficulty);
        STUDENT_HARD_DIFFICULTY_BUTTON.onClick.AddListener(StartGame_Student_HardDifficulty);
        TEACHER_CREATE_NEW_JOIN_CODE_BUTTON.onClick.AddListener(GenerateNew_Teacher_JoinCode);
    }

    private void LoginPage_Student_Login()
    {
        //TO-DO: Validation Bahaviour Before Allowing Access to Game
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_STUDENT_SCREEN);
    }

    private void LoginPage_Teacher_Login()
    {
        //TO-DO: Validation Bahaviour Before Allowing Access to Game
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_TEACHER_SCREEN);
    }

    private void LoginPage_Teacher_Register()
    {
        //TO-DO: Validation Bahaviour Before Allowing Access to Game
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.MAIN_MENU_TEACHER_SCREEN);
    }

    private void MainMenu_Student_RaiseHand()
    {
        studentRaisedHandFlag = !studentRaisedHandFlag;
        if (studentRaisedHandFlag)
        {
            STUDENT_RAISE_HAND_BUTTON.gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            STUDENT_RAISE_HAND_BUTTON.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "HAND RAISED";
        }
        else
        {
            STUDENT_RAISE_HAND_BUTTON.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            STUDENT_RAISE_HAND_BUTTON.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "RAISE HAND";
        }
    }

    private void StartGame_Student_EasyDifficulty()
    {
        PlayerPrefs.SetInt("DifficultyMultiplier", 1);
        Debug.Log("EASY DIFFICULTY SELECTED... STARTING GAME...");
        //TO-DO ADD BEHAVIOUR FOR CHANGING SCENES
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.GAME_GAMEPLAY_SCREEN);
    }

    private void StartGame_Student_MediumDifficulty()
    {
        PlayerPrefs.SetInt("DifficultyMultiplier", 2);
        Debug.Log("MEDIUM DIFFICULTY SELECTED... STARTING GAME...");
        //TO-DO ADD BEHAVIOUR FOR CHANGING SCENES
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.GAME_GAMEPLAY_SCREEN);
    }

    private void StartGame_Student_HardDifficulty()
    {
        PlayerPrefs.SetInt("DifficultyMultiplier", 4);
        Debug.Log("HARD DIFFICULTY SELECTED... STARTING GAME...");
        //TO-DO ADD BEHAVIOUR FOR CHANGING SCENES
        UI_Manager.Singleton.ChangeUITab(UI_Tabs.GAME_GAMEPLAY_SCREEN);
    }

    private void GenerateNew_Teacher_JoinCode()
    {
        int sizeOfCode = 6;
        var allowableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var stringChars = new char[sizeOfCode];
        var random = new System.Random();
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = allowableChars[random.Next(allowableChars.Length)];
        }

        var result = new String(stringChars);

        TEACHER_JOIN_CODE_MAIN_MENU_TEXT.text = result;
        PlayerPrefs.SetString("RoomCode", result);
    }

    public void SET_TEACHER_JOIN_CODE_MAIN_MENU_TEXT(string text)
    {
        TEACHER_JOIN_CODE_MAIN_MENU_TEXT.text = text;
    }

    public void SET_TEACHER_JOIN_CODE_STUDENT_GRADES_TEXT(string text)
    {
        TEACHER_JOIN_CODE_STUDENT_GRADES_TEXT.text = text;
    }

}
