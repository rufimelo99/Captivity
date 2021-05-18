using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    private Player player;



    

    public Rigidbody2D rb;
    public Animator animator;

    // to change when you change elemental
    private float damage = 0.1f; // damage that you take uppon inpact
    private float moveSpeed = 5f; // speed at which you move

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
        changeFeatures();
    }


    void changeFeatures()
    {
        
        Player.ElementalsAvailable playerElemental = player.elementalsPossesed[player.actualElementalIndex];
            
        if (playerElemental == Player.ElementalsAvailable.AIR) // air is faster but more fragile
        {
            damage = 1.5f;
            moveSpeed = 10f;
        }
        if (playerElemental == Player.ElementalsAvailable.GROUND)  // ground is more resistant
        {
            damage = 0.5f;
            moveSpeed = 5f;
        }
        if (playerElemental == Player.ElementalsAvailable.HUMAN) // human is normal
        {
            damage = 1f;
            moveSpeed = 5.5f;
        }
        if (playerElemental == Player.ElementalsAvailable.WATER) // water is normal
        {
            damage = 1f;
            moveSpeed = 5.5f;
        }
        if (playerElemental == Player.ElementalsAvailable.FIRE) // human is normal
        {
            damage = 1f;
            moveSpeed = 5.5f;
        }
        if (playerElemental == Player.ElementalsAvailable.ELECTRICITY) // human is normal
        {
            damage = 1f;
            moveSpeed = 6f;
        }

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
            player.health = player.health - 0.5f*damage;
        }

        if (obj.gameObject.tag == "Bounce")
        {
            player.health = player.health - 5f*damage;
        }
    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Evil Touch")
        {
            player.health = player.health - 0.5f*damage;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        //river - TODO - make this good
        if (col.tag == "Obstacle_blue" && player.elementalsPossesed[player.actualElementalIndex] != Player.ElementalsAvailable.WATER)
        {
            player.health = player.health - damage;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //river  - TODO - check the above todo ya dingus
        if (col.tag == "Obstacle_blue" && player.elementalsPossesed[player.actualElementalIndex] != Player.ElementalsAvailable.WATER)
        {
            player.health = player.health - damage;
        }

       
        if (col.tag == "Small Enemy Bullet")
        {
            player.health = player.health - 2f*damage;
        }
    }




}