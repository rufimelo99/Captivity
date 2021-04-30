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

    public void makeColor(int bulletcolor)
    {
        color = bulletcolor;

        if (bulletcolor == 1)
        {
            spriteRenderer.color = Color.blue;
        }
        if (bulletcolor == 0)
        {
            spriteRenderer.color = Color.green;
        }
        if (bulletcolor == 2)
        {
            spriteRenderer.color = Color.red;
        }

    }
}
