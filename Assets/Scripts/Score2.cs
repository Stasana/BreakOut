using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{
    public static Score2 instance = null;
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
        ScoreText1.text = "" + 560;
    }

    public void AddScore2()
    {
        score++;
        score = score + 9;
        ScoreText1.text = "" + PlayerPrefs.GetInt("Player Score2");
        PlayerPrefs.SetInt("Player Score2", score + 560);

        if (PlayerPrefs.GetInt("Player Score2") > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
