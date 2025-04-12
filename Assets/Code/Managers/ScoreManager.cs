using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //Score Data Variables
    private float score;
    private float highscore;
    private float multiplier;
    private const int ADD_VALUE = 100;
    [SerializeField]
    private TextMeshProUGUI scoreTextReference = null;

    [SerializeField]
    private TextMeshProUGUI highScoreTextReference = null;

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
    }

    private void IntializeVariables()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("PlayerHighScore");

    }

    public void UpdateScore()
    {
        score = ApplyScoreFunction();
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("PlayerHighScore", (int)score);
            UpdateHighscoreUI();
        }
        UpdateScoreUI();
    }

    private int ApplyScoreFunction()
    {
        return (int)(score + ADD_VALUE * multiplier);
    }

    private void UpdateHighscoreUI()
    {
        highScoreTextReference.text = "High Score: " + highscore;
    }

    private void UpdateScoreUI()
    {
        scoreTextReference.text = "Score: " + score;
    }

}
