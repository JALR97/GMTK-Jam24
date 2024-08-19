using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private HookSystem hs;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Debris"))
        {
            bool res = GameObject.FindWithTag("Player").GetComponent<HookSystem>().Connect(other.GetComponent<Rigidbody2D>());
            if (res)
            {
                Destroy(gameObject);
            }
        }
    }
}
