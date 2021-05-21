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
    public int color;
    public bool finished = false;
    public GameObject bulletPrefab;

    private Quaternion angle = Quaternion.Euler(0, 0, 0);
    private Quaternion angle2 = Quaternion.Euler(0, 180, 0);

    public bool noMoreTornados = false; // so we can instantiate the players and destroy the torando

    // Start is called

    private Vector2 movement;


    void Start()
    {
        rb.velocity = transform.right * speed;
        damage = 3f;
        color = 0;
        StartCoroutine(ShotTimer());
        StartCoroutine(destoryAfterAFewSecond(10.0f));
    }

    void OnTriggerEnter2D(Collider2D obj) //maybe comment this one still dont know
    {
        if (obj.tag == "Small Enemy Bullet" || obj.tag == "Bounce")
        {
            noMoreTornados = true;
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Small Enemy Bullet" || obj.gameObject.tag == "Bounce")
        {
            noMoreTornados = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab, transform.position, angle);
        GameObject projectile2 = Instantiate(bulletPrefab, transform.position, angle2);
        
        angle *= Quaternion.Euler(0,0, 10);
        angle2 *= Quaternion.Euler(0, 0, -10);

        projectile.GetComponent<Bullet>().makeColor(Color.blue);
        projectile2.GetComponent<Bullet>().makeColor(Color.red);
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


    public void GenocideBaby()
    {
        Destroy(gameObject);
    }

    public void makeColor(Color tornadoColor)
    {
        rendTornado.color = tornadoColor;
    }

}