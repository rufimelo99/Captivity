using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public int level;
    public int element;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player" || obj.tag == "Player2")
        {
            // SceneManager.LoadScene(0);

            giveElemental();
            GlobalControl.Instance.CompletedLevels = level;
            //GlobalControl.Instance.player2.elementalsPossesed.Add(Player.ElementalsAvailable.WATER);

            SceneManager.LoadScene(3);

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
