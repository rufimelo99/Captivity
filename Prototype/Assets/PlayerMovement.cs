using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public int playerColor = 0;

    Vector2 movement;


    void Start()
    {
        animator.SetInteger("Color", playerColor);
    }


    // Update is called once per frame
    void Update()
    {

        changeColor();

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    void changeColor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            playerColor = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerColor = 1;
        }

        animator.SetInteger("Color", playerColor);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        if(Input.GetAxisRaw("Horizontal")!= 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
