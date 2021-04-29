using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject projectile;
    public int bulletColor = 0;

    // Update is called once per frame
    void Update()
    {

        turnWeapon();
        changeBulletColor();


        if (Input.GetKeyDown(KeyCode.Minus))
        {
            Shoot();
        }
    }

    void changeBulletColor()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            bulletColor = 0;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            bulletColor = 1;
        }
    }

    void Shoot()
    {
        projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Bullet>().makeColor(bulletColor);
    }


    void turnWeapon()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
    }

}
