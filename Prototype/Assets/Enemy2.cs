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

    public GameObject bulletPrefab;
    public GameObject projectile;
    public Transform firePoint;
    public bool left;

    void Start()
    {
        left = true;
        StartCoroutine(ShotTimer());
    }

    //void Update()
    //{
        
    //}

    IEnumerator ShotTimer()
    {
        WaitForSeconds pause = new WaitForSeconds(0.5f);
        while (true)
        {
            yield return pause;
            Shoot();
            Rotate();
        }
    }


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

    void Shoot()
    {
        projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Rotate()
    {
        if (left)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            left = false;
        }
        else
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
            left = true;
        }
        
    }
}
