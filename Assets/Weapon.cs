using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private Player player;
    [SerializeField]
    private Player otherPlayer;

    private Player playerObject;
    private Color bulletColor;

	private Vector3 offset;
    private float distanceToOtherPlayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
	public GameObject combiningTreePrefab;

    private bool pressedKey = false;
    private float startTime = 0;
    private float amountTimePressed = 0;
    private HP_Bar chargingBar;

    private string attack = "Attack1";
    private string combine = "Combine1";

    void Start()
	{
		offset = new Vector3(2, 0, 0);
        playerObject = gameObject.GetComponent<Player>();

        chargingBar = gameObject.GetComponent<Player>().chargingBar;
        //1 sec max
        chargingBar.SetMaxHealth(1);
        chargingBar.SetHealth(0);

        if (player.playerId==1)
        {
            attack = "Attack2";
            combine = "Combine2";
        }

    }

    // Update is called once per frame
    void Update()
    {

        turnWeapon();
        changeBulletColor();
        chargeCombination();

        //if (Input.GetKeyDown(player.playerFire))
        if (GameInputManager.GetKeyDown(attack))
        {
            Shoot();
        }

        distanceToOtherPlayer = (transform.position - otherPlayer.transform.position).sqrMagnitude;

    }


    void changeBulletColor()
    {
        bulletColor = player.ElementalsTOColorRGB[player.elementalsPossesed[player.actualElementalIndex]];
    }

    void chargeCombination()
    {
        
        if (GameInputManager.GetKeyDown(combine))
        {
            startTime = Time.time;
            pressedKey = true;
        }
        //cancel
        if (GameInputManager.GetKeyUp(combine))
        {
            player.tryingCombination = false;
            pressedKey = false;
            startTime = 0;
            //Debug.Log("canceled");
            amountTimePressed = 0;
            chargingBar.SetHealth(amountTimePressed);
        }

        if (pressedKey)
        {
            amountTimePressed = (Time.time - startTime);
            chargingBar.SetHealth(amountTimePressed);
            if (amountTimePressed >= 1)
            {
                player.tryingCombination = true;
                if (otherPlayer.tryingCombination)
                {
                    Combine();
                    player.tryingCombination = false;
                    otherPlayer.tryingCombination = false;
                    pressedKey = false;
                    startTime = 0;

                    chargingBar.SetHealth(amountTimePressed);
                }
            }
        }
        //chargingBar
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
