using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : MonoBehaviour
{

    private bool moveTo = false;
    private bool moveBack = false;
    private bool shoot = false;
    private bool inBase = true;
    private bool madeMore = true;

    public Transform target; 
    public Transform Base;

    private bool left = true;
    private Vector3 offset = new Vector3(-3f, 0f, 0f);
    private float health = 30f;

    public Animator animator;

    public GameObject player1;
    public GameObject player2;


    public GameObject molePrefab;
    public GameObject EvilTreePrefab;
    public GameObject WaterBossPrefab;
    public GameObject FireBall;

    private int stage = 0;
    private float attackTime = 2.0f;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("Health", health);
        StartCoroutine(Attack());
    }


    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            offset = new Vector3(-3f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            offset = new Vector3(3f, 0f, 0f);
        }

        if (health <= 15)
        {
            stage = 1;
        }

        if (moveTo)
        {
            animator.SetBool("Move", true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, 10 * Time.deltaTime);           
            if (transform.position == target.position)
            {
                animator.SetBool("Move", false);
                moveTo = false;
                StartCoroutine(waitAndMoveBack());
            }
        }
        if (moveBack)
        {
            animator.SetBool("Move", true);
            transform.position = Vector3.MoveTowards(transform.position, Base.position, 10 * Time.deltaTime);
            if (transform.position == Base.position)
            {
                animator.SetBool("Move", false);
                moveBack = false;
                inBase = true;
            }
        }

        manageTime();
    }

    void manageTime()
    {
        switch (stage)
        {
            case 0:
                attackTime = 2.0f;  // shoot some balls
                break;
            case 1:
                attackTime = 1.0f;  // shoot lots of enemies and balls
                break;
        }
    }


    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackTime);
            animator.SetBool("Attack", true);
            manageAttacks();
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("Attack", false);
        }
    }

    void manageAttacks()
    {
        /*if (stage == 0)
        {
            Attack0();
        }
        else
        {*/
        Attack0();
        //}
    }


    void Attack0()
    {

        if (count < 4 & inBase)
        {
            GameObject moly = Instantiate(WaterBossPrefab, transform.position + offset, transform.rotation * Quaternion.Euler(0, 180, 0));
            moly.SetActive(true);
            moly.GetComponent<WizardMole>().addPlayers(player1, player2);
            madeMore = true;
            count += 1;
        }

        if (GameObject.FindWithTag("Evil Touch") == null && madeMore)
        {
            moveTo = true;
            inBase = false;
            count = 0;
            madeMore = false;
        }
         //Instantiate(EvilTreePrefab, transform.position + offset, transform.rotation);
        
    }

    IEnumerator waitAndMoveBack()
    {
        WaitForSeconds pause = new WaitForSeconds(3f);
        shoot = true;
        StartCoroutine(moveAttack());
        yield return pause;
        shoot = false;
        moveTo = false;
        moveBack = true;
    }


    IEnumerator moveAttack()
    {

        WaitForSeconds pause = new WaitForSeconds(0.2f);

        while (shoot)
        {
            GameObject bull1 = Instantiate(FireBall, transform.position, transform.rotation);
            bull1.GetComponent<FollowingBullet>().addPlayer(player1.transform);
            bull1.GetComponent<FollowingBullet>().makeFaster();

            yield return pause;


            GameObject bull2 = Instantiate(FireBall, transform.position, transform.rotation);
            bull2.GetComponent<FollowingBullet>().addPlayer(player2.transform);
            bull2.GetComponent<FollowingBullet>().makeFaster();

            yield return pause;

        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        //river - TODO - make this good
        if (col.tag == "Bullet")
        {
            health = health - 1f;
            animator.SetFloat("Health", health);
        }
    }
}
