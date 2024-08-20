using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour
{
    [SerializeField] private int AsteroidsToWin = 85;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject moarMessage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Debris"))
        {
            if (Asteroid.Connections >= AsteroidsToWin)
                winScreen.SetActive(true);
            
        }
    }
}
