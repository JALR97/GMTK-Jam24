using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    //Balance vars
    [SerializeField] private float breakSpeed = 5;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Speed: {other.relativeVelocity.magnitude}");
        if (other.gameObject.CompareTag("Debris"))
        {
            if(other.relativeVelocity.magnitude >= breakSpeed)
            {
                //Play break sound
                Destroy(gameObject);
            }
        }
    }
}
