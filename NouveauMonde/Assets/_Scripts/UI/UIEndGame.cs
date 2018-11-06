using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndGame : MonoBehaviour {

    public GameObject GameOverScreen;
    public GameObject WinScreen;

    public void GameOver()
    {
        if (GameOverScreen.activeSelf == false)
        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Win()
    {
        if (GameOverScreen.activeSelf == false)
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        /*
        //Game Over
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GameOverScreen.activeSelf == false)
            {
                GameOverScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }

        //Win
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (GameOverScreen.activeSelf == false)
            {
                WinScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
        */
    }
}
