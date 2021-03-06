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
    public bool shock = false;
    // Start is called
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player" || obj.tag=="Player2" || obj.tag=="Fusion" || obj.tag=="Bullet")
        {
            ;
        }
        else {
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
        damage = 10f;
    }

    public void electricity()
    {
        transform.localScale = new Vector3(2f, 0.5f, 0);
        if (damage != 10f)
        {
            damage = 1f;
        }
        speed = 50f;
        damage = 1.5f;
        shock = true;
    }


    public void fire()
    {
        transform.localScale = new Vector3(1.5f, 0.8f, 0);
        if (damage != 10f)
        {
            damage = 1f;
        }
        damage = 3f;
    }

    public void ground()
    {
        if (damage != 10f)
        {
            damage = 1f;
        }
        color = 1;
    }

    public void air()
    {
        if (damage != 10f)
        {
            damage = 1f;
        }
        damage = 0.9f;
    }

    public void water()
    {
        if (damage != 10f)
        {
            damage = 1f;
        }
        damage = 1f;
    }
}
