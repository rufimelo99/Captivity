using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // to change when you cahnge stuff
    public float speed = 20f;  // faster when you are the elcetricyt guy
    public float damage = 1f;  // more when you are the fire guy


    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public int color;
    public bool isBigger = false;
    // Start is called
    void Start()
    {
        rb.velocity = transform.right * speed;
        damage = 1f;
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
        damage = 5f;
    }

    public void electricity()
    {
        transform.localScale = new Vector3(1f, 0.2f, 0);
        speed = 30f;
    }


    public void fire()
    {
        transform.localScale = new Vector3(1.5f, 0.8f, 0);
        damage = 10f;
    }
}
