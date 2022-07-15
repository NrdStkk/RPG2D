using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public static bool paused = false;
    public GameObject saveMenu;
    public static bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused || saveMenu.active == true || gameOver)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    
    public static void Pause()
    {
        Time.timeScale = 0;
    }

    public static void Resume()
    {
        Time.timeScale = 1;
    }
}
