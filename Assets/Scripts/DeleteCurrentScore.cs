using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCurrentScore : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("Player Score");
        PlayerPrefs.DeleteKey("Player Score 1");
        PlayerPrefs.DeleteKey("Player Score 2");
    }
}