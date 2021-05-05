using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private PlayerMovement player;
    private int bulletColor = 0;

	private Vector3 offset;
    private float distanceToOtherPlayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
	public GameObject combiningTreePrefab;

    private bool pressedKey = false;
    private float startTime = 0;
    //TODO
    public PlayerMovement otherPlayer;

	void Start()
	{
		offset = new Vector3(2, 0, 0);
    }

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

        distanceToOtherPlayer = (transform.position - otherPlayer.transform.position).sqrMagnitude;

    }

    

    void changeBulletColor()
    {
        bulletColor = player.playerColor;
    }
    void chargeCombination()
    {
        
        if (Input.GetKeyDown(player.playerCombination))
        {
            startTime = Time.time;
            pressedKey = true;
        }
        //cancel
        if (Input.GetKeyUp(player.playerCombination))
        {
            player.tryingCombination = false;
            pressedKey = false;
            startTime = 0; 
            //Debug.Log("canceled");
        }

        if (pressedKey)
        {
            if ((Time.time - startTime) >= 1)
            {
                player.tryingCombination = true;
                if (otherPlayer.tryingCombination)
                {
                    Combine();
                    player.tryingCombination = false;
                    otherPlayer.tryingCombination = false;
                    pressedKey = false;
                    startTime = 0;
                    //Debug.Log("combine pls");
                }
            }
            /*else
            {
                Debug.Log((Time.time - startTime).ToString("00:00.00"));
            }*/

        }

    }
    void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Bullet>().makeColor(bulletColor);
    }

    void Combine()
    {
        if (player.playerColor != otherPlayer.playerColor)
        {
            GameObject tree = Instantiate(combiningTreePrefab, firePoint.position + offset, Quaternion.Euler(0f, 0f, 0f));
        }
        else
        {
            GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Bullet>().makeColor(bulletColor);
            projectile.GetComponent<Bullet>().makeBigger();
        }
    }


    void turnWeapon()
    {
        if (Input.GetAxisRaw(player.PlayerHorizontal) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            offset = new Vector3(2, 0, 0);
        }

        if (Input.GetAxisRaw(player.PlayerHorizontal) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            offset = new Vector3(-2, 0, 0);
        }

        if (Input.GetAxisRaw(player.PlayerVertical) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
            offset = new Vector3(0, 2, 0);
        }

        if (Input.GetAxisRaw(player.PlayerVertical) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
            offset = new Vector3(0, -2, 0);
        }
    }
}
