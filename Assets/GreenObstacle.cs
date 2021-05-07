using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenObstacle : MonoBehaviour
{

    public float health = 5.0f;
    public SpriteRenderer spriteRenderer;


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet" && obj.gameObject.GetComponent<Bullet>().color == 0 && obj.gameObject.GetComponent<Bullet>().isBigger)
        {
            health = health - 5;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        spriteRenderer.color = new Color(0f, 1f, 0f, health/5.0f);
    }
}
