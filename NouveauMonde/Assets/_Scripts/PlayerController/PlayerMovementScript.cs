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

    private Vector3 moveDirection;
    private Camera mainCamera;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        Vector3 cameraForwardDir = mainCamera.transform.forward.normalized;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //moveDirection = new Vector3(h, 0, v).normalized;
        moveDirection = (v * cameraForwardDir + h * mainCamera.transform.right).normalized;

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(transform.up * jumpForce);
        }
     
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        if(rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveDirection * moveSpeed);
        }
    }
}
               
            