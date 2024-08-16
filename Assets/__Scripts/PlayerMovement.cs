using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    //Components
    [SerializeField] private Rigidbody2D rb;
    
    //Balance
    [SerializeField] private float acceleration = 1;
    [SerializeField] private float maxSpeed = 50;

    //Work vars
    private Vector2 inputDirection = Vector2.zero;
    
    //Functions
    private void Update()
    {
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        if (inputDirection.magnitude > 0)
        {
            rb.AddForce(inputDirection.normalized * acceleration, ForceMode2D.Impulse);
        }

        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
            Debug.Log($"Max speed reached : {rb.velocity.magnitude}");
        }
    }
}
