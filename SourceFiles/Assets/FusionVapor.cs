using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionVapor : MonoBehaviour
{

    [SerializeField] private Animator vapor;
    [SerializeField] private Collider2D myColliderVapor;
    [SerializeField] private SpriteRenderer rendVapor;

    public float speed = 1f;  
    public float damage = 0.2f;
    private float moveSpeed = 15f;
    public Rigidbody2D rb;
    public int color = 0;
    public bool finished = false;

    private GameObject player1;
    private GameObject player2;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.right * speed;
        //StartCoroutine(ShotTimer());
        StartCoroutine(destoryAfterAFewSecond(4.0f));
    }

    // Update is called once per frame
    void Update()
    {
        player1.gameObject.transform.position = vapor.transform.position;
        player2.gameObject.transform.position = vapor.transform.position;
    }


    void OnTriggerEnter2D(Collider2D obj) //maybe comment this one still dont know
    {
        if (obj.tag == "Small Enemy Bullet" || obj.tag == "Bounce")
        {
            GenocideBaby();
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Small Enemy Bullet" || obj.gameObject.tag == "Bounce")
        {
            GenocideBaby();
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical2");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator destoryAfterAFewSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GenocideBaby();
    }


    public void assignPlayers(Player player, Player otherPlayer)
    {
        player1 = player.gameObject;
        player2 = otherPlayer.gameObject;


        player1.GetComponent<SpriteRenderer>().enabled = false; //make them invisible
        player2.GetComponent<SpriteRenderer>().enabled = false;

        player1.GetComponent<Collider2D>().enabled = false; //make them ghosts
        player2.GetComponent<Collider2D>().enabled = false;

    }

    public void GenocideBaby()
    {
        player1.GetComponent<SpriteRenderer>().enabled = true; 
        player1.transform.position = vapor.transform.position;
        player1.GetComponent<Player>().putTheRightColor();
        player1.GetComponent<Collider2D>().enabled = true;


        player2.GetComponent<SpriteRenderer>().enabled = true; 
        player2.transform.position = vapor.transform.position;
        player2.GetComponent<Player>().putTheRightColor();
        player2.GetComponent<Collider2D>().enabled = true;


        Destroy(gameObject);
    }
}
