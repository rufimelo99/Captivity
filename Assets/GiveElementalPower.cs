using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveElementalPower : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public Player.ElementalsAvailable newShittyPower;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {

            GlobalControl.Instance.addWithoutRepetition(newShittyPower);
            player1.elementalsPossesed.Add(newShittyPower);
            player2.elementalsPossesed.Add(newShittyPower);
        }
    }


}
