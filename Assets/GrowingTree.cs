using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTree : MonoBehaviour
{
    
    [SerializeField] private Animator animiate1;
    [SerializeField] private Collider2D myCollider;
    
    
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Hole")
        {
            animiate1.SetBool("Hole", true);
            myCollider.enabled = false;
        }
        
    }
}
