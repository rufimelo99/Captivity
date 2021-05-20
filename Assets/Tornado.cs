﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
	    
    [SerializeField] private Animator tornado;
    [SerializeField] private Collider2D myColliderTornado;
    [SerializeField] private SpriteRenderer rendTornado;

    public float speed = 5f;  
    public float damage = 3f;
    public float moveSpeed = 8f;
    public Rigidbody2D rb;
    public int color;
    public bool finished = false;
    // Start is called

    private Vector2 movement;


    void Start()
    {
        rb.velocity = transform.right * speed;
        damage = 3f;
        color = 0;
        StartCoroutine(destoryAfterAFewSecond(10.0f));
    }

    /*void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "Player" && obj.tag!="Player2")
        {
            Destroy(gameObject);
        }
    }*/

        
    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    IEnumerator destoryAfterAFewSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    public void makeColor(Color tornadoColor)
    {
        rendTornado.color = tornadoColor;
    }

}