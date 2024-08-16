using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    // Components
    [SerializeField] private Transform target;

    private Vector3 speed = Vector3.zero;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] private float smoothTime = 0.25f;

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothTime);
        
    }
}
