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
    public Rigidbody2D rb;
    public int color;
    public bool finished = false;
    // Start is called
    void Start()
    {
        rb.velocity = transform.right * speed;
        damage = 3f;
        color = 0;
    }

    /*void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag != "Player" && obj.tag!="Player2")
        {
            Destroy(gameObject);
        }
    }*/

    public void makeColor(Color tornadoColor)
    {
        rendTornado.color = tornadoColor;
    }

}