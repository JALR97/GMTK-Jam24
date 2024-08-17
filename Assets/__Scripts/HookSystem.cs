using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookSystem : MonoBehaviour
{
    //Components
    [SerializeField] private GameObject HookPrefab;

    //Balance Variables
    [SerializeField] private float launchSpeed = 50;
    [SerializeField] private float maxDistance = 10;
    [SerializeField] private float cooldown = 5;
    [SerializeField] private float ammo = 3;
    
    //Work Variables
    private bool canShoot = true;
    
    //Functions
    private void LaunchHook()
    {
        GameObject hook = Instantiate(HookPrefab, transform.position, transform.rotation);
        hook.GetComponent<Rigidbody2D>().velocity = hook.transform.up * launchSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            LaunchHook();
            canShoot = false;
            StartCoroutine(Cooldown());
        }
    }
    
    IEnumerator Cooldown()
    {
       yield return new WaitForSeconds(cooldown);
       canShoot = true;
    }
    
}
