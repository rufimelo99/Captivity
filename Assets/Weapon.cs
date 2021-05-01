using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private PlayerMovement player;
    private int bulletColor = 0;


    public Transform firePoint;
    public GameObject bulletPrefab;

    //TODO
    public PlayerMovement otherPlayer;


    // Update is called once per frame
    void Update()
    {

        turnWeapon();
        changeBulletColor();
        chargeCombination();

        if (Input.GetKeyDown(player.playerFire))
        {
            Shoot();
        }

    }



    void changeBulletColor()
    {
        bulletColor = player.playerColor;
    }
    void chargeCombination()
    {
        if (Input.GetKeyDown(player.playerCombination))
        {
            float timeForCombinationToCharge = 2;
            while (timeForCombinationToCharge > 0)
            {
                timeForCombinationToCharge -= Time.deltaTime;

            }
            if (timeForCombinationToCharge <= 0)
            {
                player.tryingCombination = true;
                if (otherPlayer.tryingCombination)
                {
                    Debug.Log("explosion");
                    player.tryingCombination = false;
                    otherPlayer.tryingCombination = false;
                }
            }
            if (Input.GetKeyUp(player.playerCombination))
            {
                player.tryingCombination = false;
                timeForCombinationToCharge = 2;
            }
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Bullet>().makeColor(bulletColor);
    }


    void turnWeapon()
    {
        if (Input.GetAxisRaw(player.PlayerHorizontal) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetAxisRaw(player.PlayerHorizontal) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetAxisRaw(player.PlayerVertical) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (Input.GetAxisRaw(player.PlayerVertical) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
    }

}
