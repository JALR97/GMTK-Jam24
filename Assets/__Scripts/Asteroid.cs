using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public static int Connections = 0;
    public static List<FixedJoint2D> Joints = new List<FixedJoint2D>();
    //Components
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private Sprite[] graphics;
    
    //Balance vars
    [SerializeField] private float[] radius;
    [SerializeField] [Range(0.0f, 0.5f)] private float sizeRange;
    
    //Work vars
    private bool hooked = false;

    public void Hooked()
    {
        if (!hooked)
        {
            Connections += 1;
            Debug.Log(Connections);
        }
        hooked = true;
    }
    public void UnHooked()
    {
        hooked = false;
    }
    private void Awake()
    {
        int rand = Random.Range(0, 4);
        spriteRenderer.sprite = graphics[rand];
        circleCollider2D.radius = radius[rand];
        if (rand == 1)
        {
            circleCollider2D.offset = new Vector2(0.06f, -0.15f);
        }
        transform.Rotate(transform.forward, Random.Range(0f, 360f));

        float scale = Random.Range(-sizeRange, sizeRange);
        transform.localScale = new Vector3(1+scale, 1+scale, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (hooked && other.gameObject.CompareTag("Debris"))
        {
            var joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = other.rigidbody;
            other.gameObject.GetComponent<Asteroid>().Hooked();
            other.gameObject.GetComponent<Rigidbody2D>().mass = 0.1f;
            //NewHooked();
            //Joints.Add(joint);
            
        }
    }

    public static void UnhookAll()
    {
        if (Joints.Count == 0)
            return;

        if (Connections < 5)
            foreach (var joint in Joints)
            {
                joint.connectedBody.GetComponent<Asteroid>().UnHooked();
                Destroy(joint);
            }
        
        Joints = new List<FixedJoint2D>();
        Connections = 1;
    }
    
    // static void NewHooked()
    // {
    //     Connections += 1;
    //     Debug.Log(Connections);
    // }
}
