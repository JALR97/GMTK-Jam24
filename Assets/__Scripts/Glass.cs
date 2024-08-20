using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Glass : MonoBehaviour
{
    //Components
    [SerializeField] private SpriteRenderer closeSprite;
    [SerializeField] private SpriteRenderer openSprite;

    [SerializeField] private GameObject message;
    [SerializeField] private GameObject speedMessage;
    [SerializeField] private GameObject quantityMessage;
    [SerializeField] private GameObject walls;
    //Balance vars
    [SerializeField] private float breakSpeed = 5;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Debris"))
        {
            if (other.relativeVelocity.magnitude < breakSpeed)
            {
                speedMessage.SetActive(true);
            }
            else if (Asteroid.Connections < 5)
            {
                quantityMessage.SetActive(true);
            }
            
            if(other.relativeVelocity.magnitude >= breakSpeed && Asteroid.Connections >= 5)
            {
                //Play break sound
                closeSprite.enabled = false;
                openSprite.enabled = true;
                message.SetActive(true);
                Destroy(walls);
                Destroy(gameObject);
            }
        }
    }
}
