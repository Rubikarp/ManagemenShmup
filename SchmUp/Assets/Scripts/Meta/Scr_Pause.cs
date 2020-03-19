using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Pause : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject textPause = null;

    private void Start()
    {
        textPause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            isPaused = true;
            textPause.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            isPaused = false;
            textPause.SetActive(false);
        }

        if (!isPaused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        Debug.Log(Time.timeScale);
    }
}
