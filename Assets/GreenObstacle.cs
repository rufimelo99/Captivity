using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenObstacle : MonoBehaviour
{

    public int color;


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet" && obj.gameObject.GetComponent<Bullet>().color == color && obj.gameObject.GetComponent<Bullet>().isBigger)
        {
            Destroy(gameObject);
        }
    }


    public void KillMePLease()
    {
        Destroy(gameObject);
    }
}
    