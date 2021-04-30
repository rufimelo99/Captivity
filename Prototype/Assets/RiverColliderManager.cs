using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverColliderManager : MonoBehaviour
{

    public BoxCollider2D collider;
    public GameObject player1;
    public GameObject player2;

    
    void Update()
    {
        if (player1.GetComponent<PlayerMovement>().playerColor == 1 && player2.GetComponent<PlayerMovement2>().playerColor == 1)
        {
            collider.enabled = false;
        }
        else
        {
           collider.enabled = true;
        }
    }


    //void OnCollisionEnter2D(Collision2D obj)
    //{
    //    if (obj.gameObject.tag == "Player" && player1.GetComponent<PlayerMovement>().playerColor==1)
    //    {
    //        collider.enabled = false; 
    //   }
    //    if (obj.gameObject.tag == "Player2" && player2.GetComponent<PlayerMovement2>().playerColor == 1)
    //    {
    //        collider.enabled = false;
    //    }
    //}

   
}
