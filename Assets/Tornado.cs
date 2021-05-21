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

    private int rotation = 0;

    private bool blue = true;
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

    /*void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "Player" && obj.tag!="Player2")
        {
            Destroy(gameObject);
        }
    }*/

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
            //Rotate();
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    IEnumerator destoryAfterAFewSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    public void makeColor(Color tornadoColor)
    {
        rendTornado.color = tornadoColor;
    }

    /*void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }*/

    /*void Rotate()
    {
        if (rotation == 0)
        {
            angle = Quaternion.Euler(0f, 180f, 0f);
            rotation = 1;
        }
        else
        {
            if (rotation == 1)
            {
                angle = Quaternion.Euler(0f, 180f, 330f);
                rotation = 2;
            }
            else
            {
                if (rotation == 2)
                {
                    angle = Quaternion.Euler(0f, 180f, 290f);
                    rotation = 3;
                }
                else
                {
                    angle = Quaternion.Euler(0f, 0f, 270f);
                    rotation = 0;
                }
            }
        }
    }*/

}