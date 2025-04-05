using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody rb;
    private bool isGrounded;

    public float coyoteTime = 0.2f; 
    private float coyoteTimeCounter;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;
    }

    public void Jump()
    {
        if (coyoteTimeCounter > 0f)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
