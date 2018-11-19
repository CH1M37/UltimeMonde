using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagController : MonoBehaviour {

    private Vector3 moveDirection;
    

    public GameObject CubeController;
    public GameObject Animation;
    //public GameObject BodyToRotate;

    public float speed = 0.1f;
    public float rotationSpeed = 20f;

	void Update () {
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveDirection = (v * transform.forward + h * transform.right).normalized;

        CubeController.transform.Translate(moveDirection * speed);
        CubeController.transform.RotateAround(CubeController.transform.position, CubeController.transform.up, Time.deltaTime * Input.GetAxisRaw("Camera") * rotationSpeed);
        
        // Déclancher animations pieds si MOVE
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
