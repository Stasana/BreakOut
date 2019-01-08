using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Manager.instance.LoseLife();
    }
}