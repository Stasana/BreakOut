using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public int lives = 3;
    public int bricks = 28;
    public float ballInitialVelocity = 300f;
    public int i = 0;
    public int p = 1;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddle;
    public GameObject deathParticles;
    public GameObject CountDown1;
    public GameObject CountDown2;
    public GameObject CountDown3;
    public GameObject CountDownStart;
    //public int score = 0;
    //public Text ScoreText;
    public static Manager instance = null;

    private GameObject clonePaddle;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();
    }

    public void Setup()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = .15f;
            Invoke("LoadNextLevel", resetDelay);
            bricks = 28;
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("LoadMenu", resetDelay);
        }

    }

    void LoadNextLevel()
    {
        youWon.SetActive(false);
        if (i == 28)
        {
            Application.LoadLevel("Gameplay 2");
        }
        if (i == 56)
        {
            Application.LoadLevel("Gameplay 3");
        }
        if (i == 84)
        {
            Application.LoadLevel("Menu");
        }
        Time.timeScale = 1f;
        if (lives < 3)
        {
            lives++;
        }
    }

    void LoadMenu()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 1f;
    }
    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        i++;
        CheckGameOver();
        if (Random.value < .2f)
        {
            BonusBiggerPaddle();
        }
        if (Random.value < .1f)
        {
            BonusSmallerPaddle();
        }
        if (Random.value > .8f)
        {
            BonusSlowerBall();
        }
        if (Random.value > .9f)
        {
            BonusFasterBall();
        }
    }

    public void Update()
    {
        //Count Down Timer(3..2..1..)
        if (Input.GetButtonDown("Fire1") && bricks == 28)
        {
            CountDown3.SetActive(true);
            Time.timeScale = 0.00001f;
            StartCoroutine(CountDownTimer());
        }
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(0.00001f);
        CountDown3.SetActive(false);
        CountDown2.SetActive(true);
        yield return new WaitForSeconds(0.00001f);
        CountDown2.SetActive(false);
        CountDown1.SetActive(true);
        yield return new WaitForSeconds(0.00001f);
        CountDown1.SetActive(false);
        CountDownStart.SetActive(true);
        yield return new WaitForSeconds(0.000005f);
        CountDownStart.SetActive(false);
        Time.timeScale = 1;
    }

    public void BonusSlowerBall()
    {
        Ball.instance.SlowBall();
    }

    public void BonusFasterBall()
    {
        Ball.instance.FastBall();
    }

    public void BonusBiggerPaddle()
    {
        clonePaddle.transform.localScale = new Vector3(3, 1, 1);
        StartCoroutine(TimerPaddleBig());
    }

    public void BonusSmallerPaddle()
    {
        if (p == 1)
        {
            return;
        }
        else
        {
            clonePaddle.transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(TimerPaddleSmall());
        }
    }

    IEnumerator TimerPaddleSmall()
    {
        yield return new WaitForSeconds(5f);
        clonePaddle.transform.localScale = new Vector3(2, 1, 1);
    }
    IEnumerator TimerPaddleBig()
    {
        p = 1;
        yield return new WaitForSeconds(5f);
        p++;
        clonePaddle.transform.localScale = new Vector3(2, 1, 1);
    }

}
