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
        if(level != -1)
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
                endTheLevel();
            }
        }
        else
        {
            giveElemental();
        }
    }


    void endTheLevel()
    {
        giveElemental();
        if (level != -1)
        {
            if (GlobalControl.Instance.CompletedLevels <= level)
            {
                GlobalControl.Instance.CompletedLevels = level;
            }

            if (level == 9)
            {
                SceneManager.LoadScene(14);
            }
            else
            {
                SceneManager.LoadScene(3);
            }

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
            GlobalControl.Instance.addWithoutRepetition(Player.ElementalsAvailable.WATER);
        }
        if (element == 2)
        {
            GlobalControl.Instance.addWithoutRepetition(Player.ElementalsAvailable.GROUND);
        }
        if (element == 3)
        {
            GlobalControl.Instance.addWithoutRepetition(Player.ElementalsAvailable.FIRE);
        }
        if (element == 4)
        {
            GlobalControl.Instance.addWithoutRepetition(Player.ElementalsAvailable.AIR);
        }
        if (element == 5)
        {
            GlobalControl.Instance.addWithoutRepetition(Player.ElementalsAvailable.ELECTRICITY);
        }
        else
        {
            ;
        }
    }
}
