using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int player;

    public string PlayerColor = "Color";
    public string PlayerHorizontal = "Horizontal";
    public string PlayerVertical = "Vertical";


    private KeyCode heroBlue = KeyCode.K;
    private KeyCode heroGreen = KeyCode.L;
    public KeyCode playerFire = KeyCode.Minus;
    public KeyCode playerCombination = KeyCode.RightShift;
    public bool tryingCombination = false;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public int playerColor = 0;

    Vector2 movement;
    Vector2 roomMover;

    public float health = 10f;
    public Image healthBar = null;


    void Start()
    {
        if (player == 2)
        {
            PlayerColor = "Color2";
            PlayerHorizontal = "Horizontal2";
            PlayerVertical = "Vertical2";


            heroGreen = KeyCode.Q;
            heroBlue = KeyCode.E;



            playerFire = KeyCode.Space;
            playerCombination = KeyCode.V;
        }
        animator.SetInteger(PlayerColor, playerColor);
        healthBar.GetComponent<Image>().color = Color.green;
    }


    // Update is called once per frame
    void Update()
    {
        changeColor();
        move();
        animate();
        if (health <= 0.1)
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
        movement.x = Input.GetAxisRaw(PlayerHorizontal);
        movement.y = Input.GetAxisRaw(PlayerVertical);
    }


    void changeColor()
    {
        if (Input.GetKeyDown(heroGreen))
        {
            playerColor = 0;
            healthBar.GetComponent<Image>().color = Color.green;
        }
        if (Input.GetKeyDown(heroBlue))
        {
            playerColor = 1;
            healthBar.GetComponent<Image>().color = Color.blue;
        }
        animator.SetInteger(PlayerColor, playerColor);
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
            animator.SetFloat("lastMoveX", Input.GetAxisRaw(PlayerHorizontal));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw(PlayerVertical));
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Evil Touch")
        {
            health = health - 0.1f;
        }
    }

    void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Evil Touch")
        {
            health = health - 0.1f;
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
            roomMover = new Vector2(0, 2 * movement.y);
            gameObject.transform.position = rb.position + roomMover;
        }

        if (col.tag == "Horizontal Room Changer")
        {
            roomMover = new Vector2(2 * movement.x, 0);
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

}