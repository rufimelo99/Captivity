using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{


    public float speed;
    public Animator animator;
    public Transform Player1;
    public Transform Player2;
    public float distance1;
    public float distance2;
    public Vector3 direction;


    void Start()
    {
        animator.SetFloat("Speed", 2);
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
        if (distance1 <= distance2)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player1.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player2.position, Time.deltaTime * speed);
        }
    }
}
