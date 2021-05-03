using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTree : MonoBehaviour
{
    
    [SerializeField] private Animator animiate1;
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private SpriteRenderer rend;



    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Hole")
        {
            animiate1.SetBool("Hole", true);
            myCollider.enabled = false;
            obj.collider.enabled = false;
            gameObject.layer = 10;
            rend.sortingOrder = -1;
        }
        
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet" || obj.tag == "Small Enemy Bullet")
        {
            Destroy(gameObject);
        }
    }
}
