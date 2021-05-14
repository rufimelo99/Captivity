using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    private Player player;



    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;


    void Start()
    {
        player = gameObject.GetComponent<Player>();

    }


    // Update is called once per frame
    void Update()
    {
        move();
        animate();

    }


    void animate()
    {

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //healthBar.fillAmount = player.health / 10f;

        
    }


    void move()
    {
        movement.x = Input.GetAxisRaw(player.PlayerHorizontal);
        movement.y = Input.GetAxisRaw(player.PlayerVertical);
        if(movement.x < 0){
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        if (movement.y != 0||movement.x>0)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        rotate();
    }


    void rotate()
    {

        if (Input.GetAxisRaw(player.PlayerHorizontal) != 0 || Input.GetAxisRaw(player.PlayerVertical) != 0)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw(player.PlayerHorizontal));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw(player.PlayerVertical));
        }
    }


    
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Evil Touch")
        {
            player.health = player.health - 0.1f;
        }

        if (obj.gameObject.tag == "Bounce")
        {
            player.health = player.health - 2;
        }
    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Evil Touch")
        {
            player.health = player.health - 0.1f;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        //river
        if (col.tag == "Obstacle_blue" && player.elementalsPossesed[player.actualElementalIndex] != Player.ElementalsAvailable.WATER)
        {
            player.health = player.health - 0.2f;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //river
        if (col.tag == "Obstacle_blue" && player.elementalsPossesed[player.actualElementalIndex] != Player.ElementalsAvailable.WATER)
        {
            player.health = player.health - 0.1f;
        }

       
        if (col.tag == "Small Enemy Bullet")
        {
            player.health = player.health - 1;
        }
    }




}