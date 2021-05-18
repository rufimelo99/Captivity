using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenObstacle : MonoBehaviour
{

    public float health = 5.0f;
    public SpriteRenderer spriteRenderer;


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet" && obj.gameObject.GetComponent<Bullet>().color == 1 && obj.gameObject.GetComponent<Bullet>().isBigger)
        {
            Destroy(gameObject);
        }
    }
}
    