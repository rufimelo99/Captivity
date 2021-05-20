using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{


    [SerializeField] private int color;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool player1 = false;
    private bool player2 = false;

    // Start is called before the first frame update
    void Start()
    {
        switch (color)
        {
            case 0:
                spriteRenderer.color = Color.blue;  //blue color
                break;
            case 1:
                spriteRenderer.color = Color.green;  //green color
                break;
            case 2:
                spriteRenderer.color = Color.red;  //red color
                break;
            case 3:
                spriteRenderer.color = Color.gray;  //white-gray color
                break;
            case 4:
                spriteRenderer.color = Color.yellow;  //yellow color
                break;
            case 5:
                spriteRenderer.color = new Color(210, 81, 176);//purple color
                break;
        }
    }

    void Update()
    {
        if(player1 && player2)
        {
            //GlobalControl.Instance.gemsCollected.Add(gameObject);
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //river  - TODO - check the above todo ya dingus
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
        //river  - TODO - check the above todo ya dingus
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
