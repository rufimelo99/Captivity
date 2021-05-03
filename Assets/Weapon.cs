using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            float timeForCombinationToCharge = 2;
            while (timeForCombinationToCharge > 0)
            {
                timeForCombinationToCharge -= Time.deltaTime;

            }
            if (timeForCombinationToCharge <= 0 && distanceToOtherPlayer <= 5)
            {
                player.tryingCombination = true;
                if (otherPlayer.tryingCombination)
                {
                    Combine();
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

	void Combine()
    {
        GameObject tree = Instantiate(combiningTreePrefab, firePoint.position + offset, Quaternion.Euler(0f, 0f, 0f));
        //tree.GetComponent<GrowingTree>().animate();
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
