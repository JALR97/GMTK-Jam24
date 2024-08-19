using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private  SpriteRenderer _Sprite;
    [SerializeField] private Sprite shipOff, shipOn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _Sprite.sprite = shipOn;
        }else if (Input.GetKeyUp(KeyCode.W))
        {
            _Sprite.sprite = shipOff;
        }
    }
}
