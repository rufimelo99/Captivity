using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 20f;
    private Vector2 right;
    private Vector2 left;
    private bool isLeft;

    // Start is called before the first frame update
    void Start()
    {

        right = new Vector2(1f, 0f) * speed;
        left = new Vector2(-1f, 0f) * speed;
        isLeft = false;
        rb.velocity = right;
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(isLeft) {
            rb.velocity = right;
            isLeft = false;
        }
        else
        {
            rb.velocity = left;
            isLeft = true;
        }
            
    }
}
