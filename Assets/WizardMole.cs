using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardMole : MonoBehaviour
{
    public float speed;

    private bool frozen = false;

    private float startTime;

    public Animator animator;


    public Transform Player1;
    public Transform Player2;
    private Transform closestPlayer;

    private float distance1;
    private float distance2;
    private Vector3 direction;

    public GameObject bulletPrefab;

    public float health = 19f;
    public Image healthBar;

    public int shoot;
    public bool isJustStandinThere;

    private bool iHaveThemPLayers = false;
    public float maxRange = 100000;

    void Start()
    {
        if (isJustStandinThere)
        {
            iHaveThemPLayers = true;
            animator.SetFloat("Health", 10);
            animator.SetFloat("Speed", 0);
            speed = 3.0f;
            StartCoroutine(ShotTimer());
        }
    }


    public void addPlayers(GameObject p1, GameObject p2)
    {
        Player1 = p1.transform;
        Player2 = p2.transform;
        iHaveThemPLayers = true;

        animator.SetFloat("Health", 10);
        animator.SetFloat("Speed", 0);
        speed = 3.0f;
        StartCoroutine(ShotTimer());
    }


    IEnumerator ShotTimer()
    {
        WaitForSeconds pause = new WaitForSeconds(1f);
        while (true)
        {
            yield return pause;
            if (!frozen & iHaveThemPLayers && (distance1 <= maxRange || distance2 <= maxRange))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (!iHaveThemPLayers)
        {
            return;
        }
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
            if (obj.tag == "Magma")
            {
                health = health - 0.2f;
            }
        }
        healthBar.fillAmount = health / 10f;
        animator.SetFloat("Health", health);
    }


    // Update is called once per frame
    void Update()
    {
        if (!iHaveThemPLayers)
        {
            return;
        }

        distance1 = (Player1.position - transform.position).sqrMagnitude;
        distance2 = (Player2.position - transform.position).sqrMagnitude;

        if (distance1>maxRange && distance2 > maxRange)
        {

            animator.SetFloat("Speed", 0);
            return;
        }
            
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
            StartCoroutine(freeze());
        }

    }

    Quaternion GetRotationTo(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void animate()
    {
        animator.SetFloat("Horizontal2", direction.x);
        animator.SetFloat("Vertical2", direction.y);
    }


    void FixedUpdate()
    {

        if (!iHaveThemPLayers)
        {
            return;
        }
        if (distance1 > maxRange && distance2 > maxRange)
        {

            animator.SetFloat("Speed", 0);
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

    

    IEnumerator freeze()
    {
        frozen = true;
        speed = 0f;
        yield return new WaitForSeconds(1f);
        frozen = false;
        speed = 2f;
    }
}
