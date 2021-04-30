using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void changeBulletColor()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletColor = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
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
        if (Input.GetAxisRaw("Horizontal2") == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetAxisRaw("Horizontal2") == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetAxisRaw("Vertical2") == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (Input.GetAxisRaw("Vertical2") == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
    }

}
