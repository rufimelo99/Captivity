using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public int playerColor = 0;
    public BoxCollider2D collider;

    public float health = 10f;
    public Image healthBar;

    Vector2 movement;
    Vector2 roomMover;

    void Start()
    {
        animator.SetInteger("Color", playerColor);
        healthBar.GetComponent<Image>().color = Color.green;
    }


    // Update is called once per frame
    void Update()
    {
        changeColor();
        move();
        animate();
        if (health == 0)
        {
            die();
        }
    }

    void die()
    {
        health = 10f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    void animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        healthBar.fillAmount = health / 10f;
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
            healthBar.GetComponent<Image>().color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerColor = 1;
            healthBar.GetComponent<Image>().color = Color.blue;
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

        if (col.tag == "Obstacle_blue" && playerColor != 1)
        {
            health = 0;
        }

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

        if (col.tag == "Small Enemy Bullet")
        {
            health = health - 1;
            healthBar.fillAmount = health / 10f;
        }
    }

}
