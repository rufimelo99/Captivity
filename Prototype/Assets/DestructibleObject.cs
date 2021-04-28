using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructibleObject : MonoBehaviour
{
    public Animator animator;
    public float health = 3F;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {
            health = health - 1;
        }
    }
}
