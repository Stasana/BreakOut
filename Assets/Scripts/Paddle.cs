using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{

    public float paddleSpeed = 0.5f;
    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    void Update()
    {
        float xPox = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPox, -7.1f, 7.1f), -4.7f, 0f);
        transform.position = playerPos;
    }

}
