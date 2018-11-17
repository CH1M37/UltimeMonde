using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndGame : MonoBehaviour {

    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public GameObject PauseMenu;

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
        if (WinScreen.activeSelf == false)
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void PauseGame()
    {
        if (Time.timeScale != 0 && GameOverScreen.activeSelf == false && WinScreen.activeSelf == false)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0 && GameOverScreen.activeSelf == false && WinScreen.activeSelf == false)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }

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
