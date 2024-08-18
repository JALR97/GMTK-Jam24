using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class HookSystem : MonoBehaviour
{
    //Components
    [SerializeField] private GameObject hookPrefab;
    [SerializeField] private DistanceJoint2D joint;
    
    //Balance Variables
    [SerializeField] private float launchSpeed = 25;
    [SerializeField] private float maxDistance = 6;
    [SerializeField] private float cooldown = 3;
    [SerializeField] private float ammo = 3;
    
    //Work Variables
    private bool _canShoot = true;
    private bool _hooked = false;
    
    //Functions
    private void LaunchHook()
    {
        GameObject hook = Instantiate(hookPrefab, transform.position, transform.rotation);
        hook.GetComponent<Rigidbody2D>().velocity = hook.transform.up * launchSpeed;
    }

    public void Connect(Rigidbody2D hit)
    {
        if (_hooked) //no more than one connection
            return;

        if ((hit.position - (Vector2)transform.position).magnitude > maxDistance)
        {
            Debug.Log("Debris too far");
            return;
        }
        
        joint.enabled = true;
        joint.connectedBody = hit;
        joint.distance = maxDistance;
        _hooked = true;
    }

    private void RenderRope()
    {
        
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_canShoot && !_hooked)
            {
                LaunchHook();
                _canShoot = false;
                StartCoroutine(Cooldown());
            }else if (_hooked)
            {
                Unhook();
            }
            
        }
    }

    private void Unhook()
    {   
        Debug.Log("Unhook()");
    }

    IEnumerator Cooldown()
    {
       yield return new WaitForSeconds(cooldown);
       _canShoot = true;
    }
    
}
