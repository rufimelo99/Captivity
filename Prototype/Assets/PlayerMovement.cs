using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int player;

    public string PlayerColor = "Color";
    public string PlayerHorizontal = "Horizontal";
    public string PlayerVertical = "Vertical";

    private KeyCode heroGreen = KeyCode.Q;
    private KeyCode heroBlue = KeyCode.E;
    public KeyCode playerFire = KeyCode.Minus;
    public KeyCode playerCombination = KeyCode.RightShift;
    public bool tryingCombination = false;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public int playerColor = 0;

    Vector2 movement;


    void Start()
    {
<<<<<<< Updated upstream
        animator.SetInteger("Color", playerColor);
=======
        if (player == 2)
        {
            PlayerColor = "Color2";
            PlayerHorizontal = "Horizontal2";
            PlayerVertical = "Vertical2";
            heroBlue = KeyCode.K;
            heroGreen = KeyCode.L; 
            playerFire = KeyCode.Space; 
            playerCombination = KeyCode.V;
        }
        animator.SetInteger(PlayerColor, playerColor);
        healthBar.GetComponent<Image>().color = Color.green;
>>>>>>> Stashed changes
    }

    //void OnTriggerEnter2D(Collider2D obj)
    //{
    //    if (obj.tag == "endGame")
    //    {
    //        Application.Quit();
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream

        changeColor();
=======
        move();
        animate();
        changeColor();
        if (health <= 0.1)
        {
            die();
        }
    }
>>>>>>> Stashed changes

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
<<<<<<< Updated upstream
=======
        healthBar.fillAmount = health / 10f;
    }

    void move()
    {
        movement.x = Input.GetAxisRaw(PlayerHorizontal);
        movement.y = Input.GetAxisRaw(PlayerVertical);
>>>>>>> Stashed changes
    }

    //GOTTA CHANGE HERE
    void changeColor()
    {
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.Alpha0))
=======
        
        if (Input.GetKeyDown(heroGreen))
>>>>>>> Stashed changes
        {
            playerColor = 0;
        }
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.Alpha1))
=======
        if (Input.GetKeyDown(heroBlue))
>>>>>>> Stashed changes
        {
            playerColor = 1;
        }
<<<<<<< Updated upstream

        animator.SetInteger("Color", playerColor);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        if(Input.GetAxisRaw("Horizontal")!= 0 || Input.GetAxisRaw("Vertical") != 0)
=======

        animator.SetInteger("Color", playerColor);
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Evil Touch")
>>>>>>> Stashed changes
        {
            health = health - 0.1f;
        }
    }
<<<<<<< Updated upstream
=======

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Evil Touch")
        {
            health = health - 0.1f;
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rotate();
    }

    void rotate()
    {
        if (Input.GetAxisRaw(PlayerHorizontal) != 0 || Input.GetAxisRaw(PlayerVertical) != 0)
        {
            animator.SetFloat("lastMoveX", movement.x);//Input.GetAxisRaw("Horizontal2")
            animator.SetFloat("lastMoveY", movement.y);// Input.GetAxisRaw("Vertical2"));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Obstacle_blue" && playerColor != 1)
        {
            health = 0;
        }

        if (col.tag == "Vertical Room Changer")
        {
            roomMover = new Vector2(0, movement.y);
            gameObject.transform.position = rb.position + roomMover;
        }

        if (col.tag == "Horizontal Room Changer")
        {
            roomMover = new Vector2(movement.x, 0);
            gameObject.transform.position = rb.position + roomMover;
        }

        if (col.tag == "Small Enemy Bullet")
        {
            health = health - 1;
            healthBar.fillAmount = health / 10f;
        }

        if (col.tag == "endGame")
        {
            Application.Quit();
        }
    }

>>>>>>> Stashed changes
}

