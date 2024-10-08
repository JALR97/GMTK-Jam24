using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    //Components
    [SerializeField] private Rigidbody2D rb;
    
    //Balance
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float accelerationForw = 50f;
    [SerializeField] private float accelerationBack = 50f;
    [SerializeField] private float maxSpeed = 50f;

    //Work variables
    private Vector2 inputDirection = Vector2.zero;
    private Vector3 eulerAngle;
    
    //Functions
    private void Update()
    {
        //Lee los ejes de movimiento, aka WASD y arrow keys.
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        //Rotacion
        if (inputDirection.x != 0)
        {
            rb.rotation += rotationSpeed * Time.deltaTime * (inputDirection.x > 0 ? -1.0f : 1.0f);
        }
        //Aceleracion y freno
        if (inputDirection.y > 0)
        {
            rb.AddForce(transform.up * (accelerationForw * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }else if (inputDirection.y < 0)
        {
            rb.AddForce(-transform.up * (accelerationBack * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }

        //Limitador de velocidad
        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
