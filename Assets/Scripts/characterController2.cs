using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    private Rigidbody2D r2d;
    private SpriteRenderer _spriteRenderer;
    private characterController controller;
    private Animator anim; // Animator reference

    // Jump related variables
    public float jumpForce = 7f; // Adjust as needed
    private bool isGrounded = true; // Check if the player is grounded

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<characterController>();
        anim = GetComponent<Animator>(); // Get the Animator component
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Move with A and D keys

        // Apply movement
        r2d.velocity = new Vector2(moveInput * controller.currentSpeed, r2d.velocity.y);

        // Flip character sprite
        if (moveInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (moveInput > 0)
        {
            _spriteRenderer.flipX = false;
        }

        // Jump logic
        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
            isGrounded = false; // Prevent double jumps
            anim.SetTrigger("jump"); // Trigger jump animation
            anim.SetBool("grounded", false); // Set grounded to false when jumping
        }

        // Update Animator parameters
        anim.SetFloat("speed", Mathf.Abs(moveInput)); // Control run animation
        anim.SetBool("grounded", isGrounded); // Control grounded status
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player landed on the ground
        if (other.gameObject.CompareTag("Zemin")) // "Zemin" is the ground tag
        {
            isGrounded = true;
            anim.SetBool("grounded", true); // Confirm character is grounded
        }
    }
}


