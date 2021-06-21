using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D obj){
        
        if (obj.gameObject.tag == "Player") {
            Player player1 = obj.gameObject.GetComponent<Player>();
            if(player1.elementalsPossesed[player1.actualElementalIndex] == Player.ElementalsAvailable.AIR)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

                //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (obj.gameObject.tag == "Player2")
        {
            Player player2 = obj.gameObject.GetComponent<Player>();
            if (player2.elementalsPossesed[player2.actualElementalIndex] == Player.ElementalsAvailable.AIR)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

                //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if(obj.gameObject.tag == "Fusion"){
            
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

        }
    }

    /*void OnCollisionStay2D(Collision2D obj){
        if (obj.gameObject.tag == "Player") {
            Player player1 = obj.gameObject.GetComponent<Player>();
            if(player1.elementalsPossesed[player1.actualElementalIndex] == Player.ElementalsAvailable.AIR)
            {

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (obj.gameObject.tag == "Player2")
        {
            Player player2 = obj.gameObject.GetComponent<Player>();
            if (player2.elementalsPossesed[player2.actualElementalIndex] == Player.ElementalsAvailable.AIR)
            {

                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if(obj.gameObject.tag == "Fusion"){
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }*/
    
    void OnTriggerExit2D(Collider2D obj){

                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }

}
