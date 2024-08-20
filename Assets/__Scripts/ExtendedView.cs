using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedView : MonoBehaviour {

    //[SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    
    //Balance
    [SerializeField] private float inactiveRadius;
    [SerializeField] private float maxExtension;
    [SerializeField] private float viewChangeSpeed;
    
    //Vars
    private Vector3 mouseVector;
    private Vector3 distanceVector;
    private Vector3 targetPos;
    private float mouseDistance;

    private void FixedUpdate() {
        mouseVector = Input.mousePosition; 
        mouseVector.x -= Screen.width/2f; 
        mouseVector.y -= Screen.height/2f;
        
        mouseDistance = mouseVector.magnitude;
        if (mouseDistance > inactiveRadius) {
            targetPos = player.position +
                                 mouseVector.normalized * Mathf.Min((mouseDistance - inactiveRadius), maxExtension);
        }
        else
            targetPos = player.position;

        targetPos.z = -10f;
        
        transform.position = Vector3.Lerp(transform.position, targetPos, viewChangeSpeed * Time.deltaTime);
    }
}
