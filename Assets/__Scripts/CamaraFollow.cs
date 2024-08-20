using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    // Components
    [SerializeField] private Transform target;
    [SerializeField] private GameObject enoughmsj;
    
    private AudioSource audio;
    private Camera cam;
    // private Vector3 speed = Vector3.zero;
    // private Vector3 offset = new Vector3(0f, 0f, -10f);
    //[SerializeField] private float smoothTime = 0.25f;

    //private void FixedUpdate()
    // {
    //     Vector3 targetPos = target.position + offset;
    //     transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothTime);
    //     
    // }

    private void Start()
    {
        cam = GetComponent<Camera>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Asteroid.Connections > 1)
        {
            cam.orthographicSize = 10 + Asteroid.Connections * 0.2f;
        }
        if (Asteroid.Connections > 85)
        {
            enoughmsj.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            audio.mute = !audio.mute;
        }
        
    }
}
