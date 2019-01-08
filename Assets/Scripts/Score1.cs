using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour
{
    public static Score1 instance = null;
    public int score = 0;
    public Text ScoreText1;
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
        ScoreText1.text = "" + 280;
    }

    public void AddScore1()
    {
        score++;
        score = score + 9;
        ScoreText1.text = "" + PlayerPrefs.GetInt("Player Score1");
        PlayerPrefs.SetInt("Player Score1", score + 280);

        if (PlayerPrefs.GetInt("Player Score1") > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
