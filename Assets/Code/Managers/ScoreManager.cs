/*
 * CREATED BY: KAMIL WOLOSZYN
 * DATE: 12th April 2025
 * FUNCTION: Managing everything to do with players score and highscore
 */
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Score Data Variables
    private float score;
    private float highscore;
    private float multiplier;
    private const int ADD_VALUE = 100;

    [Header("Text Mesh Pro - Text References")]
    [SerializeField]
    private TextMeshProUGUI scoreTextReference = null;
    [SerializeField]
    private TextMeshProUGUI highScoreTextReference = null;
    [SerializeField]
    private TextMeshProUGUI afterGameScoreTextReference = null;

    public static ScoreManager Singleton = null;

    private void Awake()
    {
        if(Singleton != null && Singleton != this)
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
        IntializeVariables();
        UpdateHighscoreUI();
        UpdateScoreUI();
        UpdateAfterGameScoreText();
    }

    private void IntializeVariables()
    {
        //Initializing the private variables used in the script
        score = 0;
        highscore = PlayerPrefs.GetInt("PlayerHighScore");
        multiplier = 1;
        multiplier = PlayerPrefs.GetInt("DifficultyMultiplier");
    }

    public void UpdateScore()
    {
        //Updating the score with a new value and updating corresponding variables
        score += (int)(ADD_VALUE * multiplier);
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("PlayerHighScore", (int)score);
            UpdateHighscoreUI();
        }
        UpdateScoreUI();
        UpdateAfterGameScoreText();
    }
    /// <summary>
    /// Updating highscore value shown in the gameplay
    /// </summary>
    private void UpdateHighscoreUI()
    {
        highScoreTextReference.text = "High Score: " + highscore.ToString();
    }

    /// <summary>
    /// Updating the score value shown in the gameplay
    /// </summary>
    private void UpdateScoreUI()
    {
        scoreTextReference.text = "Score: " + score.ToString();
    }

    /// <summary>
    /// Updating the win/lose screen value shown for the score
    /// </summary>
    private void UpdateAfterGameScoreText()
    {
        afterGameScoreTextReference.text = "Score: " + score.ToString();
    }

}
