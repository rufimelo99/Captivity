using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int player;

    public string PlayerColor = "Color";
    public string PlayerHorizontal = "Horizontal";
    public string PlayerVertical = "Vertical";


    private KeyCode heroBlue = KeyCode.L;
    private KeyCode heroGreen = KeyCode.K;
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



    //Pressure Plate lvl1
    //Objects on Ground
    bool door0_opened = false;
    [SerializeField]
    private Tilemap tileMap;
    [SerializeField]
    private Tilemap doorsToUnlock;
    [SerializeField]
    private Tile tilePlateNotActive;
    [SerializeField]
    private Tile tilePlateActive;

    //otherPlayer
    public Rigidbody2D rb2;
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
        checkPressurePlates();
        if (health <= 0.1)
        {
            die();
        }
        
    }

    void checkPressurePlates()
    {
        if (!door0_opened)
        {
            bool firstPressurePlateActive = false;
            bool secondPressurePlateActive = false;
            Vector3Int playerPosition = new Vector3Int(Mathf.RoundToInt(rb.position.x), Mathf.RoundToInt(rb.position.y), 0);
            Vector3Int otherPlayerPosition = new Vector3Int(Mathf.RoundToInt(rb2.position.x), Mathf.RoundToInt(rb2.position.y), 0);

            Vector3Int gridPosition = tileMap.WorldToCell(playerPosition);
            Vector3Int gridPosition2 = tileMap.WorldToCell(otherPlayerPosition);

            Vector3Int firstPressurePlateReal = new Vector3Int(-4, -20, 0);//onTileMap
            float distanceTofirstPressurePlate = Mathf.Sqrt((rb.position.x - (-4.0f)) * (rb.position.x - (-4.0f)) + (rb.position.y - (-20.0f+1)) * (rb.position.y - (-20.0f + 1)));
            float distanceTofirstPressurePlate2 = Mathf.Sqrt((rb2.position.x - (-4.0f)) * (rb2.position.x - (-4.0f)) + (rb2.position.y - (-20.0f + 1)) * (rb2.position.y - (-20.0f + 1)));

            if ((distanceTofirstPressurePlate <= 1.0f && rb.position.x > -4 && rb.position.y > -20) ||
                (distanceTofirstPressurePlate2 <= 1.0f && rb2.position.x > -4 && rb2.position.y > -20))
            {
                tileMap.SetTile(firstPressurePlateReal, null);
                tileMap.SetTile(firstPressurePlateReal, tilePlateActive);
                firstPressurePlateActive = true;
            }
            else
            {
                tileMap.SetTile(firstPressurePlateReal, null);
                tileMap.SetTile(firstPressurePlateReal, tilePlateNotActive);

            }

            Vector3Int secondPressurePlateReal = new Vector3Int(49, -23, 0);//onTileMap
            float distanceToSecondPressurePlate = Mathf.Sqrt((rb.position.x - (49.0f)) * (rb.position.x - (49.0f)) + (rb.position.y - (-22.0f)) * (rb.position.y - (-22.0f)));
            float distanceToSecondPressurePlate2 = Mathf.Sqrt((rb2.position.x - (49.0f)) * (rb2.position.x - (49.0f)) + (rb2.position.y - (-22.0f)) * (rb2.position.y - (-22.0f)));
            if ((distanceToSecondPressurePlate <= 1.0f && rb.position.x > 49 && rb.position.y > -22) ||
                (distanceToSecondPressurePlate2 <= 1.0f && rb2.position.x > 49 && rb2.position.y > -22))
            {
                tileMap.SetTile(secondPressurePlateReal, null);
                tileMap.SetTile(secondPressurePlateReal, tilePlateActive);

                secondPressurePlateActive = true;
            }
            else
            {
                tileMap.SetTile(secondPressurePlateReal, null);
                tileMap.SetTile(secondPressurePlateReal, tilePlateNotActive);

            }

            if(secondPressurePlateActive && firstPressurePlateActive)
            {
                Vector3Int wallLocation0_0Doorlayer = new Vector3Int(48, -15, 0);
                Vector3Int wallLocation0_1Doorlayer = new Vector3Int(48, -14, 0);
                Vector3Int wallLocation0_2Doorlayer = new Vector3Int(48, -13, 0);
                Vector3Int wallLocation0_3Doorlayer = new Vector3Int(50, -13, 0);
                Vector3Int wallLocation0_4Doorlayer = new Vector3Int(50, -14, 0);
                Vector3Int wallLocation0_5Doorlayer = new Vector3Int(50, -15, 0);
                Vector3Int wallLocation0_6Doorlayer = new Vector3Int(49, -13, 0);
                Vector3Int wallLocation0_7Doorlayer = new Vector3Int(49, -14, 0);
                Vector3Int wallLocation0_8Doorlayer = new Vector3Int(49, -15, 0);
                doorsToUnlock.SetTile(wallLocation0_0Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_1Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_2Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_3Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_4Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_5Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_6Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_7Doorlayer, null);
                doorsToUnlock.SetTile(wallLocation0_8Doorlayer, null);
                door0_opened = true;
            }

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
        //river
        if (col.tag == "Obstacle_blue" && playerColor != 1)
        {
            health = 0;
        }

        if (col.tag == "Room Changer Next")
        {
            roomMover = new Vector2(27, -1);
            gameObject.transform.position = rb.position + roomMover;

            //TODO
        }
        if (col.tag == "Room Changer Back")
        {
            roomMover = new Vector2(-27, -1);
            gameObject.transform.position = rb.position + roomMover;

            //TODO
        }
        if (col.tag == "Small Enemy Bullet")
        {
            health = health - 1;
            healthBar.fillAmount = health / 10f;
        }
    }

}