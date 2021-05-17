using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public int level;
    public int element;

    private bool player1;
    private bool player2;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            player1 = true;
        }
            
        if(obj.tag == "Player2")
        {
            player2 = true;
        }

        if(player1 && player2)
        {
            giveElemental();
            GlobalControl.Instance.CompletedLevels = level;
            SceneManager.LoadScene(3);
        }
    }


    void OnTriggerExit2D(Collider2D obj) //WE STILL NEED TO DISABLE THE PLAYER OR DO SOMETHING - maybe
    {
        if (obj.tag == "Player")
        {
            player1 = false;
        }

        if (obj.tag == "Player2")
        {
            player2 = false;
        }
    }


    void giveElemental()
    {
        if (element == 1)
        {
            GlobalControl.Instance.elementalsPossesed.Add(Player.ElementalsAvailable.WATER);
        }
        if (element == 2)
        {
            GlobalControl.Instance.elementalsPossesed.Add(Player.ElementalsAvailable.GROUND);
        }
        if (element == 3)
        {
            GlobalControl.Instance.elementalsPossesed.Add(Player.ElementalsAvailable.FIRE);
        }
        if (element == 4)
        {
            GlobalControl.Instance.elementalsPossesed.Add(Player.ElementalsAvailable.AIR);
        }
        if (element == 5)
        {
            GlobalControl.Instance.elementalsPossesed.Add(Player.ElementalsAvailable.ELECTRICITY);
        }
        else
        {
            ;
        }
    }
}
