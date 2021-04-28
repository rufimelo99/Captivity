using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{

    public Animator animator;
    public Animator animator2;
    public float health = 10f;
    public Image healthBar;
    public BoxCollider2D caveCollider;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {
            health = health - 1;

            if (health == 0)
            {
                animator2.SetBool("isEnemyDead", true);
                caveCollider.enabled = false;
            }

            animator.SetFloat("enemyHealth", health);
            healthBar.fillAmount = health / 10f;
        }
    }
}
