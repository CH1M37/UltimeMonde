using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagController : MonoBehaviour {

    public GameObject CubeController;
    public GameObject Animation;

    public float speed = 0.1f;
    
	void Update () {

        // Control by translation
        /*
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(Vector3.forward * speed);
        }
        */

        // Control by animation
        
        if (Input.GetKey(KeyCode.Z))
        {
            Animation.GetComponent<Animator>().enabled = true;
            CubeController.transform.Translate(Vector3.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Animation.GetComponent<Animator>().enabled = true;
            CubeController.transform.Translate(Vector3.back * speed);
        }
        else
        {
            Animation.GetComponent<Animator>().enabled = false;
        }

    }
}
