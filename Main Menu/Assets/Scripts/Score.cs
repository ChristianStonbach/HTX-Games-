using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform Lærer;
    public Text ScoreText;
    int ScoreCount = 1;
    public bool isRunning = true;
    public Text HighScore;

    void Start()
    {
        HighScore.text = "Highscore: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime.ToString());
        ScoreText.text = "Score: " + ScoreCount.ToString("0");

        if (isRunning == true)
        {
            ScoreCount++;
        }

        if (Input.GetKey("space"))
        {
            isRunning = false;

        }

        if (Input.GetKey("a"))
        {
            isRunning = true;
        }

        PlayerPrefs.SetInt("HighScore", ScoreCount);
    }
    public void Highscore()
    {
        if (ScoreCount > PlayerPrefs.GetInt("HighScore", ScoreCount))
        {
            PlayerPrefs.SetInt("HighScore", ScoreCount);
            HighScore.text = ScoreText.text.ToString();
        }
        
    }
    
}
