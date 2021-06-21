using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyObstacle : MonoBehaviour
{

    public Rigidbody2D rb;

    private bool player1 = false;
    private bool player2 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

    }

    // Update is called once per frame
    void Update()
    {
        if (player1 && player2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            player1 = true;
        }
        if (obj.gameObject.tag == "Player2")
        {
            player2 = true;
        }
    }

    void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            player1 = false;
        }
        if (obj.gameObject.tag == "Player2")
        {
            player2 = false;
        }
    }
}
