using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool isPause = false;
    void Pause()
    {
        Time.timeScale = 0f;
    }

    void UnPause()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
            if (isPause)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }
}
