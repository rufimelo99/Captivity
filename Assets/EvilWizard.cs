using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : MonoBehaviour
{

    private bool left = true;
    private Vector3 offset = new Vector3(-3f, 0f, 0f);
    private float health = 10f;

    public Animator animator;

    public GameObject player1;
    public GameObject player2;


    public GameObject molePrefab;
    public GameObject EvilTreePrefab;
    public GameObject WaterBossPrefab;
    public GameObject FireBall;

    private int stage = 0;
    private float attackTime = 2.0f;

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
                attackTime = 1.0f;   // shoot lots of balls
                break;
            case 2:
                attackTime = 2.0f;   // shoot some enemies
                break;
            case 3:
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
        //Instantiate(EvilTreePrefab, transform.position + offset, transform.rotation);
        GameObject moly = Instantiate(WaterBossPrefab, transform.position + offset, transform.rotation*Quaternion.Euler(0, 180, 0));
        moly.SetActive(true);
        moly.GetComponent<WizardMole>().addPlayers(player1, player2);
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
