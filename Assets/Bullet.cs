using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public int color;
    public bool isBigger = false;
    // Start is called
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "Player" && obj.tag!="Player2")
        {
            Destroy(gameObject);
        }
    }

    public void makeColor(Color bulletcolor)
    {
        spriteRenderer.color = bulletcolor;
        
    }

    public void makeBigger()
    {
        transform.localScale = new Vector3(4.0f, 2.0f, 0);
        isBigger = true;
    }
}
