using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public int playerColor = 0;
    public BoxCollider2D collider;

    Vector2 movement;


    void Start()
    {
        animator.SetInteger("Color2", playerColor);
    }


    // Update is called once per frame
    void Update()
    {
        animate();
        move();
        changeColor();
    }

    void animate()
    {
        animator.SetFloat("Horizontal2", 1);
        animator.SetFloat("Vertical2", 0);
        animator.SetFloat("Speed2", movement.sqrMagnitude);
    }

    void move()
    {
        movement.x = Input.GetAxisRaw("Horizontal2");
        movement.y = Input.GetAxisRaw("Vertical2");
    }


    void changeColor()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerColor = 0;        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerColor = 1;
        }

        animator.SetInteger("Color2", playerColor);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rotate();
    }

    void rotate()
    {
        if (Input.GetAxisRaw("Horizontal2") != 0 || Input.GetAxisRaw("Vertical2") != 0)
        {
            animator.SetFloat("lastMoveX2", 1);//Input.GetAxisRaw("Horizontal2")
            animator.SetFloat("lastMoveY2", 0);// Input.GetAxisRaw("Vertical2"));
        }
    }


    //void OnCollisionEnter2D(Collision2D obj)
    //{
    //    if (obj.gameObject.tag == "Obstacle_blue" && playerColor == 1)
    //   {
    //        collider.isTrigger = true;
    //    }
    //}

}

