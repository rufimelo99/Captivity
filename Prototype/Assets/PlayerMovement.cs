using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public int playerColor = 0;
    public BoxCollider2D collider;

    Vector2 movement;
    Vector2 roomMover;

    void Start()
    {
        animator.SetInteger("Color", playerColor);
    }


    // Update is called once per frame
    void Update()
    {
        changeColor();
        move();
        animate();
    }


    void animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    void move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    void changeColor()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerColor = 0;
            collider.isTrigger = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerColor = 1;
        }
        animator.SetInteger("Color", playerColor);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        rotate();
    }

    
    void rotate()
    {

        if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    //void OnCollisionEnter2D(Collision2D obj)
    //{
    //    if (obj.gameObject.tag == "Obstacle_blue" && playerColor == 1)
    //   {
    //        collider.isTrigger = true;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Vertical Room Changer")
        {
            roomMover = new Vector2(0, 2 * movement.y);
            gameObject.transform.position = rb.position + roomMover;
        }

        if (col.tag == "Horizontal Room Changer")
        {
            roomMover = new Vector2(2 * movement.x,0);
            gameObject.transform.position = rb.position + roomMover;
        }
    }

}
