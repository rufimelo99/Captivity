using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{

    public Animator animator;
    public float health = 10f;
    public Image healthBar;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {
            health = health - 1;
            animator.SetFloat("enemyHealth", health);
            healthBar.fillAmount = health / 10f;
        }
    }
}
