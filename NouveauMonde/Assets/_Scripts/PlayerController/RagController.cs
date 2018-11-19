using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagController : MonoBehaviour {

    private Vector3 moveDirection;

    public GameObject CubeController;
    public GameObject Animation;

    public float speed = 0.5f;

	void Update () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDirection = (v * transform.forward + h * transform.right).normalized;

        CubeController.transform.Translate(moveDirection * speed);

        // Déclancher animation pieds si ZQSD
        //if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))
        if (moveDirection.magnitude > 0)
        {   
            Animation.GetComponent<Animator>().enabled = true;
        }
        else
        {
            Animation.GetComponent<Animator>().enabled = false;
        }

    }
}
