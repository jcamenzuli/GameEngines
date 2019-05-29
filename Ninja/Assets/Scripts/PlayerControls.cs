﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public KeyCode action;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private Switch switchInRange;
   
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

        if (Input.GetKeyDown(action) && switchInRange != null)
        {
            switchInRange.Toggle();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform" && other.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            if (rb.velocity.y > 0) return;
            Platforms platformScript = other.gameObject.GetComponent<Platforms>();
            if (platformScript != null) platformScript.ChangeLayer(gameObject.layer);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            if (other.gameObject.tag == "Switch")
            {
                Switch switchScript = other.GetComponent<Switch>();
                // for buttons
                // if (switchScript != null) switchScript.Toggle();

                if (switchScript != null) switchInRange = switchScript;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactables"))
        {
            if (other.gameObject.tag == "Switch")
            {
                Switch switchScript = other.GetComponent<Switch>();
                if (switchScript == switchInRange) switchInRange = null;
            }
        }
    }


    private void OnBecameInvisible()
    {
        Vector3 cameraBounds = Camera.main.ViewportToWorldPoint(Vector3.zero);

        if (transform.position.y < cameraBounds.y)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
