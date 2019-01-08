using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance = null;
    public int score = 0;
    public Text ScoreText;
    // Use this for initialization

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


    }

    void Start()
    {
        ScoreText.text = PlayerPrefs.GetInt("Player Score").ToString();
    }

    public void AddScore()
    {
        score++;
        score = score + 9;
        ScoreText.text = "" + score;
        PlayerPrefs.SetInt("Player Score", score);
        PlayerPrefs.SetInt("Player Score1", score + 280);

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
