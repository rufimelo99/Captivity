using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBoss : MonoBehaviour
{
    public float speed;

    private bool frozen = false;
    private bool destroyed = false;

    private float startTime;
    private bool isIn = true;

    public Animator animator;

    public GameObject doorToDestroy;
    public GameObject ball1;
    public GameObject ball2;

    public Transform Player1;
    public Transform Player2;
    private Transform closestPlayer;

    private float distance1;
    private float distance2;
    private Vector3 direction;

    public GameObject bulletPrefab;

    public float health = 10f;
    public Image healthBar;

    public int shoot;


    public GameObject plate1;
    public GameObject plate2;
    public GameObject plate3;
    public GameObject plate4;


    private bool left = true;


    void Start()
    {
        animator.SetFloat("Health", 10);
        animator.SetFloat("Speed", 0);
        speed = 3.0f;
        StartCoroutine(ShotTimer());
        left = true;
    }


    IEnumerator ShotTimer()
    {
        WaitForSeconds pause = new WaitForSeconds(2f);
        while (true)
        {
            yield return pause;
            if (!frozen)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (health >= 5)
        {
            GameObject bull = Instantiate(bulletPrefab, transform.position, transform.rotation); // follow the player
            bull.GetComponent<FollowingBullet>().addPlayer(closestPlayer);
        }
        else
        {
            GameObject bull1 = Instantiate(bulletPrefab, transform.position, transform.rotation); // follow the player
            bull1.GetComponent<FollowingBullet>().addPlayer(Player1);
            GameObject bull2 = Instantiate(bulletPrefab, transform.position, transform.rotation); // follow the player
            bull2.GetComponent<FollowingBullet>().addPlayer(Player2);
        }

        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {
            health = health - obj.GetComponent<Bullet>().damage;

            if (obj.GetComponent<Bullet>().shock)
            {
                StartCoroutine(freeze());
            }
        }

        if (obj.tag == "Magma")
        {
            health = health - 0.2f;
        }


        healthBar.fillAmount = health / 10f;
        animator.SetFloat("Health", health);
    }


    // Update is called once per frame
    void Update()
    {
        distance1 = (Player1.position - transform.position).sqrMagnitude;
        distance2 = (Player2.position - transform.position).sqrMagnitude;

        if (distance1 <= distance2)
        {
            direction = Player1.position - transform.position;
            closestPlayer = Player1;
        }
        else
        {
            direction = Player2.position - transform.position;
            closestPlayer = Player2;
        }

        animate();

        if (health <= 0)
        {
            if (!destroyed)
            {
                Destroy(doorToDestroy);
                Destroy(ball1);
                Destroy(ball2);
                destroyed = true;
            }     
            StartCoroutine(freeze());
        }

        checkPlates();

    }

    Quaternion GetRotationTo(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }


    void checkPlates()
    {
        if(plate1.GetComponent<PressurePlate_v2>().activated && plate2.GetComponent<PressurePlate_v2>().activated & left)      
        {
            DecreaseLife();
        }       

        if (plate3.GetComponent<PressurePlate_v2>().activated && plate4.GetComponent<PressurePlate_v2>().activated && !left)
        {
            DecreaseLife();
        }
    }

    void animate()
    {
        animator.SetFloat("Horizontal2", direction.x);
        animator.SetFloat("Vertical2", direction.y);
    }


    void FixedUpdate()
    {
        if (frozen) // if he was shocked, do noting
        {
            animator.SetFloat("Speed", speed);
            return;
        }

        animator.SetFloat("Speed", speed);
        if (distance1 <= distance2)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player1.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player2.position, Time.deltaTime * speed);
        }

    }

    void DecreaseLife()
    {
        if (isIn)
        {
            startTime = Time.time;
            isIn = false;
        }

        if (left & (!plate1.GetComponent<PressurePlate_v2>().activated || !plate2.GetComponent<PressurePlate_v2>().activated))
        {
            //Debug.Log("Left");
            left = false;
            isIn = true;
            return;
        }

        if (!left & (!plate3.GetComponent<PressurePlate_v2>().activated || !plate4.GetComponent<PressurePlate_v2>().activated))
        {
            //Debug.Log("right");
            left = true;
            isIn = true;
            return;
        }

        if (Time.time - startTime >= 1f)
        {
            StartCoroutine(BananaMan());
            if (left)
            {
                left = false;
                isIn = true;
            }
            else
            {
                left = true;
                isIn = true;
            }
        }        
    }

    IEnumerator BananaMan()
    {
        healthBar.color = Color.black;  // just to animate the health bar
        health = health - 3f;
        healthBar.fillAmount = health / 10f;
        animator.SetFloat("Health", health);
        yield return new WaitForSeconds(0.5f);
        healthBar.color = Color.white;
    }



    IEnumerator freeze()
    {
        frozen = true;
        speed = 0f;
        yield return new WaitForSeconds(1f);
        frozen = false;
        speed = 2f;
    }
}
