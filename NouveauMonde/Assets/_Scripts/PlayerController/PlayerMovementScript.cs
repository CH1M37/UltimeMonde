using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool canJump = false;
    [SerializeField]
    private float rotationSpeed;

    private Vector3 moveDirection;
    private Vector3 cameraForward;
    private Camera mainCamera;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        cameraForward = mainCamera.transform.forward;
        moveDirection = (v * transform.forward + h * mainCamera.transform.right).normalized;

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        //Rotate
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * Input.GetAxisRaw("Camera") * rotationSpeed);
    }

    void FixedUpdate()
    {
        //move
        if(rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveDirection * moveSpeed);
        }
    }
}
               
            