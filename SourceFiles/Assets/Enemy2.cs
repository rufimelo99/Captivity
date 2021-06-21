using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{

    public Animator animator;
    //public Animator animator2;
    public float health = 10f;
    public Image healthBar;
    //public BoxCollider2D caveCollider;

    public GameObject bulletPrefab;
    public GameObject projectile;
    public Transform firePoint;
    public bool right;

    void Start()
    {
        firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        right = false;
        StartCoroutine(ShotTimer());
    }

    

    IEnumerator ShotTimer()
    {
        WaitForSeconds pause = new WaitForSeconds(0.8f);
        while (true)
        {
            yield return pause;
            Shoot();
            //Rotate();
        }
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {
            health = health - 1;

            //if (health == 0)
            //{
                //animator2.SetBool("isEnemyDead", true);
                //caveCollider.enabled = false;
            //}

            animator.SetFloat("enemyHealth", health);
            healthBar.fillAmount = health / 10f;
        }
    }

    void Shoot()
    {
        projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Rotate()
    {
        if (right)
        {
            firePoint.rotation = Quaternion.Euler(0f, 60f, 0f);
            right = false;
        }
        else
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            right = true;
        }
        
    }
}
