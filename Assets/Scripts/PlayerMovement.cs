using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f; // Controls the smoothness of rotation

    private Rigidbody rb;
    private Vector2 moveInput;
    public bool isMoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); // Read movement input
        isMoving = moveInput != Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized * speed * Time.deltaTime;
        transform.Translate(move, Space.World); // Move in world space

        // Smoothly rotate towards movement direction
        if (move.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
