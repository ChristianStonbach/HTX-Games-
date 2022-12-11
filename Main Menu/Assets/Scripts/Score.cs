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
    public Text highScore;
    

    void Start()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if (ScoreCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ScoreCount);
            highScore.text = ScoreCount.ToString();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GameLose" && isRunning == true)
        {
            Application.Quit();
            Debug.Log("Game Over");
        }
    }
}
