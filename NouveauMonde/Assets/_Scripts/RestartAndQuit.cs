using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndQuit : MonoBehaviour {

	public void RestartLevel ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GravityWorld");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Ça quitte là normalement");
    }

}
