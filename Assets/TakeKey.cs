using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeKey : MonoBehaviour
{

    private bool player1 = false;
    private bool player2 = false;
    //private bool boolrock = false;

    //public Collider2D rock;

    public GlobalControl.KeysAvailable keyType;

    //private float distanceToRock;

    //[SerializeField] private GameObject key;


    // Start is called before the first frame update
    void Start()
    {
        //distanceToRock = (transform.position - rock.transform.position).sqrMagnitude;

    }

    // Update is called once per frame
    void Update()
    {
        if(player1 || player2)
        {
            GlobalControl.Instance.addKey(keyType);
            gameObject.SetActive(false);
        }

        /*if(boolrock)
        {
            key.layer = 1;
        }*/
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player1 = true;

        }
        if(col.gameObject.tag == "Player2")
        {
            player2 = true;//
        }
        /*if(col.gameObject.tag == "rockcave")
        {
            boolrock = true;//
        }*/
    }

    void OnCollisionStay2D(Collision2D col)
    {
        
        /*if(col.gameObject.tag == "rockcave")
        {
            boolrock = true;//
        }*/
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player1 = false;

        }
        if (col.gameObject.tag == "Player2")
        {
            player2 = false;//
        }
    }


}
