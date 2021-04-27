using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public SpriteRenderer spriteRenderer;

    // Start is called
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

    public void makeColor(int bulletcolor)
    {
        if (bulletcolor == 1)
        {
            spriteRenderer.color = Color.blue;
        }
        if (bulletcolor == 0)
        {
            spriteRenderer.color = Color.green;
       }
    }
}
