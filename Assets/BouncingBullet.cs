using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBullet : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 20f;
    private Vector2 right;
    private Vector2 left;

    // Start is called before the first frame update
    void Start()
    {

        right = new Vector2(-1f, 0f);
        left = new Vector2(1f, 0f);

        rb.velocity = right * speed;
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        rb.velocity = -1f * rb.velocity;
    }
}
