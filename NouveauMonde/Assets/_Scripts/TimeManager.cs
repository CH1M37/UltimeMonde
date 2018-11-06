using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    private UIEndGame UIScript;

    [Header("Timer Display")]
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float initialTime = 180f;

    private float timer;
    [HideInInspector]
    public float timeSinceLastDestruction;
    [HideInInspector]
    public GameObject[] wasteArray;
    [HideInInspector]
    public bool checkWaste = false;

    // Use this for initialization
    void Start () {
        UIScript = GameObject.FindObjectOfType<UIEndGame>();

        wasteArray = null;
        timer = 0f;
        timeSinceLastDestruction = 0f;
    }
	
	void Update () {
        timer += Time.deltaTime;
        timeSinceLastDestruction += Time.deltaTime;

        DisplayTime();
        
        //Destroy Waste
        if (checkWaste)
        {
            DestroyWaste();
        }
      
    }

    private void DisplayTime()
    {
        float timeRemaining = initialTime - timer;
        int displayMinutes = (int)(timeRemaining / 60);
        int displaySeconds = (int) timeRemaining % 60;
        timerText.text = displayMinutes.ToString() + " : " + displaySeconds.ToString();  

        if(timeRemaining <= 0)
        {
            UIScript.GameOver();
        }
            
    }

    private void DestroyWaste()
    {
        wasteArray = GameObject.FindGameObjectsWithTag("waste");

        if (timeSinceLastDestruction > 2f && wasteArray.Length != 0)
        {
            foreach (GameObject waste in wasteArray)
            {
                Destroy(waste);
                checkWaste = false;
            }
        }
    }
}
