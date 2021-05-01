using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{


    public float speed;
    public float range;

    public Animator animator;

    public Transform Player1;
    public Transform Player2;

    public float distance1;
    public float distance2;
    public Vector3 direction;

    public float health = 10f;
    public Image healthBar;


    void Start()
    {
        animator.SetFloat("Health", 10);
        animator.SetFloat("Speed", 0);
    }


    // Update is called once per frame
    void Update()
    {
        distance1 = (Player1.position - transform.position).sqrMagnitude;
        distance2 = (Player2.position - transform.position).sqrMagnitude;
        if(distance1 <= distance2)
        {
            direction = Player1.position - transform.position;
        }
        else
        {
            direction = Player2.position - transform.position;
        }

        animate();

    }

    void animate()
    {
        animator.SetFloat("Horizontal2", direction.x);
        animator.SetFloat("Vertical2", direction.y);
    }


    void FixedUpdate()
    {
        if (distance1 <= range || distance2 <= range)
        {
            animator.SetFloat("Speed", 2);
            speed = 2.0f;
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
            speed = 0f;
        }
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {
            health = health - 1;
            animator.SetFloat("Health", health);
            healthBar.fillAmount = health / 10f;
        }
    }


}
