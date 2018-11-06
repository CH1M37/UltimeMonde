using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

    private UIEndGame UIScript;

    void Start () {
        UIScript = GameObject.FindObjectOfType<UIEndGame>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIScript.Win();
        }
    }

    
}
