﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{   
    // The player's movement speed
    public float speed = 10f;
    
    // The player's jump speed
    public float jumpSpeed = 20f;

    
    // A reference to the character's rigidbody
    private Rigidbody2D rb;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
   
    void Awake() 
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // Player will not spam jump
        // Checking the player's position
        // Will draw a circle to check if player is on ground, if it is not, it will say isGrounded = False
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
    }

    void FixedUpdate()
    {
        if(Input.GetKey(left))
        {
            // Negative number on X axis
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if(Input.GetKey(right))
        {
            // Postive number on X axis
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else 
        {
            // Created this so the character does not slide
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        // If player presses jump and is on the ground, he jumps
        if(Input.GetKeyDown(jump) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
}
