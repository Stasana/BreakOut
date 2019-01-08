using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float ballInitialVelocity = 300f;

    private Rigidbody rb;
    private bool ballInPlay;
    public static Ball instance = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (instance == null)
            instance = this;
        else if (instance != this)
            return;
    }
    public void SlowBall()
    {
        transform.parent = null;
        ballInPlay = true;
        rb.isKinematic = false;
        rb.AddForce(new Vector3(-100, -100, 0));
    }
    public void FastBall()
    {
        transform.parent = null;
        ballInPlay = true;
        rb.isKinematic = false;
        rb.AddForce(new Vector3(+100, +100, 0));
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
    }
}
