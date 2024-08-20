using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : MonoBehaviour
{
    [SerializeField] private int AsteroidsToWin = 85;
    [SerializeField] private GameObject winScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Debris") && Asteroid.Connections >= AsteroidsToWin)
        {
            winScreen.SetActive(true);
        }
    }
}
