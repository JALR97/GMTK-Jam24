using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    //Components
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    //Balance vars
    [SerializeField] private float breakSpeed = 5;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Debris"))
        {
            if(other.relativeVelocity.magnitude >= breakSpeed)
            {
                //Play break sound
                spriteRenderer.enabled = false;
                Destroy(gameObject);
            }
        }
    }
}
