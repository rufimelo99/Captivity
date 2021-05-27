using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBoss : MonoBehaviour
{
    public float speed;
    public float range = 150f;

    private bool frozen = false;

    public Animator animator;

    public Transform Player1;
    public Transform Player2;

    public float distance1;
    public float distance2;
    public Vector3 direction;

    public GameObject bulletPrefab;

    public float health = 10f;
    public Image healthBar;

    public int shoot;

    void Start()
    {
        animator.SetFloat("Health", 10);
        animator.SetFloat("Speed", 0);
        speed = 2.0f;

        if (shoot == 1)
        {
            speed = 1.0f;
            StartCoroutine(ShotTimer());
        }
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
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 180f, 0f));
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, 90f));
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, 270f));
    }


    // Update is called once per frame
    void Update()
    {
        distance1 = (Player1.position - transform.position).sqrMagnitude;
        distance2 = (Player2.position - transform.position).sqrMagnitude;

        if (distance1 <= distance2)
        {
            direction = Player1.position - transform.position;
        }
        else
        {
            direction = Player2.position - transform.position;
        }

        animate();

        if (health <= 0)
        {
            StartCoroutine(freeze());
        }

    }

    void animate()
    {
        animator.SetFloat("Horizontal2", direction.x);
        animator.SetFloat("Vertical2", direction.y);
    }


    void FixedUpdate()
    {
        if ((distance1 <= range || distance2 <= range) && !frozen)
        {
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
        else
        {
            animator.SetFloat("Speed", 0);
            //speed = 0f;
        }
    }


    void DecreaseLife()
    {

        health = health - 0.1f;


        healthBar.fillAmount = health / 10f;
        animator.SetFloat("Health", health);
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
