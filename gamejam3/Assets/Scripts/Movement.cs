using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f;

    [SerializeField] private Rigidbody2D rb;  // Reference to the Rigidbody2D component
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if ((IsGrounded()) && (Input.GetKey(KeyCode.D))) // Prevent player from moving in air
        {
            MovePlayer(1f);
        }
        else if ((IsGrounded()) && (Input.GetKey(KeyCode.A)))
        {
            MovePlayer(-1f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void MovePlayer(float direction)
    {
        float verticalVelocity = rb.velocity.y; // store the current vertical velocity of the player
        rb.velocity = new Vector2(direction * moveSpeed, verticalVelocity); // only modify the horizontal velocity
    }
}





