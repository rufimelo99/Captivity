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
    Vector2 roomMover;

    void Start()
    {
        roomMover = new Vector2(0, 1);
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

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Vertical Room Changer")
        {
            roomMover = new Vector2(0, 2*movement.y);
            gameObject.transform.position = rb.position + roomMover;
        }

        if (col.tag == "Horizontal Room Changer")
        {
            roomMover = new Vector2(2 * movement.x, 0);
            gameObject.transform.position = rb.position + roomMover;
        }
    }

}

