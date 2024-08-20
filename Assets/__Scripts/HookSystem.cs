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
    [SerializeField] private SpriteRenderer ropeRenderer;
    
    //Balance Variables
    [SerializeField] private float launchSpeed = 25;
    [SerializeField] private float maxDistance = 9;
    [SerializeField] private float cooldown = 3;
    //[SerializeField] private float ammo = 3;
    
    //Work Variables
    private bool _canShoot = true;
    private bool _hooked = false;
    
    //Functions
    private void LaunchHook()
    {
        GameObject hook = Instantiate(hookPrefab, transform.position, transform.rotation);
        hook.GetComponent<Rigidbody2D>().velocity = hook.transform.up * launchSpeed;
    }

    public bool Connect(Rigidbody2D hit)
    {
        if (_hooked) //no more than one connection
            return false;

        if ((hit.position - (Vector2)transform.position).magnitude > maxDistance)
        {
            Debug.Log("Debris too far");
            return false;
        }
        
        joint.enabled = true;
        joint.connectedBody = hit;
        joint.distance = maxDistance;
        _hooked = true;
        hit.GetComponent<Asteroid>().Hooked();
        RenderRope();
        ropeRenderer.enabled = true;
        return true;
    }

    private void RenderRope()
    {
        Transform hookTransform = ropeRenderer.transform;
        Vector2 dirConnection = joint.connectedBody.position - (Vector2)transform.position;
        hookTransform.position = (Vector2)transform.position + (dirConnection / 2);
        hookTransform.right = (Vector2)transform.position - joint.connectedBody.position;
        ropeRenderer.size = new Vector2(Math.Clamp(dirConnection.magnitude - 2f, 1.5f,maxDistance), 0.14f);
        //ropeRenderer.size.Set(dirConnection.magnitude, 0.14f);
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

        if (_hooked)
        {
            RenderRope();
        }

        if (Asteroid.Connections > 1)
        {
            maxDistance = 9 + Asteroid.Connections * 0.2f;
        }
    }

    private void Unhook()
    {
        //joint.connectedBody.GetComponent<Asteroid>()
        joint.connectedBody.GetComponent<Asteroid>().UnHooked();
        joint.connectedBody = null;
        joint.enabled = false;
        //Asteroid.UnhookAll();
        _hooked = false;
        ropeRenderer.enabled = false;
    }

    IEnumerator Cooldown()
    {
       yield return new WaitForSeconds(cooldown);
       _canShoot = true;
    }

}
