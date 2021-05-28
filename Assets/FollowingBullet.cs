using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBullet : MonoBehaviour
{

    public float bulletDamage;

    private float bulletSpeed = 9.5f;
    private float spriteWithDelta;
    //private Rigidbody2D bulletBody;
    private Transform playerTransform;
    private Transform selfTransform;
    private Vector3 playerPosition;

    public SpriteRenderer sp;


    // Use this for initialization
    void Start()
    {
        //bulletBody = GetComponent<Rigidbody2D>();
        //playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        bulletSpeed = 20f;      
        selfTransform = GetComponent<Transform>();
        makeBigger();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Enemies" || obj.tag == "Evil Touch" || obj.tag == "Small Enemy Bullet")
        {
            ;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void makeBigger()
    {
        transform.localScale = new Vector3(2.0f, 2.0f, 0);
    }

    public void addPlayer(Transform player)
    {
        playerTransform = player;
        playerPosition = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.position = Vector3.MoveTowards(selfTransform.position, playerPosition, bulletSpeed * Time.deltaTime);
        if (selfTransform.position == playerPosition)
        {
            StartCoroutine(expelliarmus());
        }
        
    }


    IEnumerator expelliarmus()
    {
        WaitForSeconds pause = new WaitForSeconds(0.5f);
        sp.color = Color.red;
        yield return pause;
        Destroy(gameObject);
    }
}

