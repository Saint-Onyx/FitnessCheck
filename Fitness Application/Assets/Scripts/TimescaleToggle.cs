using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimescaleToggle : MonoBehaviour
{

    private bool paused = false;


   public void PauseApplication()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
        }
    }

    public void PlayApplication()
    {
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
        }
    }
}
