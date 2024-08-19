using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 0.5f)] private float sizeRange;
    [SerializeField] private Sprite[] graphics;
    [SerializeField] private float[] radius;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D circleCollider2D;
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
}
