using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeKey : MonoBehaviour
{

    private bool player1 = false;
    private bool player2 = false;

    public GlobalControl.KeysAvailable keyType;


    [SerializeField]
    private GameObject Key;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player1 || player2)
        {
            GlobalControl.Instance.addKey(keyType);
            gameObject.SetActive(false);
        }
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
