using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private Player player;
    //TODO
    public Player otherPlayer;
    [SerializeField]
    private Player playerObject;
    private int bulletColor = 0;

	private Vector3 offset;
    private float distanceToOtherPlayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
	public GameObject combiningTreePrefab;

    private bool pressedKey = false;
    private float startTime = 0;

	void Start()
	{
		offset = new Vector3(2, 0, 0);
        playerObject = gameObject.GetComponent<Player>();
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
        bulletColor = player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]];
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
        }

    }
    void Shoot()
    {
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Bullet>().makeColor(bulletColor);
    }

    void Combine()
    {
        if (distanceToOtherPlayer <= 5) {
            //check if their colors are different only
            if (player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] != player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] )
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
    }


    void turnWeapon()
    {
        if (Input.GetAxisRaw(playerObject.PlayerHorizontal) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            offset = new Vector3(2, 0, 0);
        }

        if (Input.GetAxisRaw(playerObject.PlayerHorizontal) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            offset = new Vector3(-2, 0, 0);
        }

        if (Input.GetAxisRaw(playerObject.PlayerVertical) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
            offset = new Vector3(0, 2, 0);
        }

        if (Input.GetAxisRaw(playerObject.PlayerVertical) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
            offset = new Vector3(0, -2, 0);
        }
    }
}
