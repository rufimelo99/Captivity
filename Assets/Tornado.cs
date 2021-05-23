using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
	    
    [SerializeField] private Animator tornado;
    [SerializeField] private Collider2D myColliderTornado;
    [SerializeField] private SpriteRenderer rendTornado;

    public float speed = 5f;  
    public float damage = 3f;
    private float moveSpeed = 15f;
    public Rigidbody2D rb;
    public int color = 0;
    public bool finished = false;
    public GameObject bulletPrefab;

    private Quaternion angle = Quaternion.Euler(0, 0, 0);
    private Quaternion angle2 = Quaternion.Euler(0, 180, 0);

    private GameObject player1;
    private GameObject player2;

    // Start is called

    private Vector2 movement;


    void Start()
    {
        rb.velocity = transform.right * speed;
        damage = 1f;
        StartCoroutine(ShotTimer());
        StartCoroutine(destoryAfterAFewSecond(5.0f));
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

    void Update()
    {
        player1.gameObject.transform.position = tornado.transform.position;
        player2.gameObject.transform.position = tornado.transform.position;
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab, transform.position, angle);
        GameObject projectile2 = Instantiate(bulletPrefab, transform.position, angle2);
        
        angle *= Quaternion.Euler(0,0, 10);
        angle2 *= Quaternion.Euler(0, 0, -10);

        if (color == 0)
        {
            projectile.GetComponent<Bullet>().makeColor(Color.blue);
            projectile2.GetComponent<Bullet>().makeColor(Color.white);
        }
        else{
            projectile.GetComponent<Bullet>().makeColor(Color.red);
            projectile2.GetComponent<Bullet>().makeColor(Color.white);
        }
    }


    public void red() // its just to change the colors of the bullets so what
    {
        color = 1;
    }

    IEnumerator ShotTimer()
    {
        WaitForSeconds pause = new WaitForSeconds(0.05f);
        while (true)
        {
            yield return pause;
            Shoot();
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

        //player1.gameObject.SetActive(false);
        //player2.gameObject.SetActive(false);
    }


    public void GenocideBaby()
    {
        player1.GetComponent<SpriteRenderer>().enabled = true; //player1.gameObject.SetActive(true); //put back player 1
        player1.transform.position = tornado.transform.position;
        player1.GetComponent<Player>().putTheRightColor();
        player1.GetComponent<Collider2D>().enabled = true;


        player2.GetComponent<SpriteRenderer>().enabled = true;  //put back player 1
        player2.transform.position = tornado.transform.position;
        player2.GetComponent<Player>().putTheRightColor();
        player2.GetComponent<Collider2D>().enabled = true;


        Destroy(gameObject);
    }

    public void makeColor(Color tornadoColor)
    {
        rendTornado.color = tornadoColor;
    }

}