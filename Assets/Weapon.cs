﻿using System.Collections;
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
	public GameObject fusionTornadoPrefab;
    public GameObject magmaPrefab;
	

    private bool pressedKey = false;
    private float startTime = 0;
    private float amountTimePressed = 0;
    private HP_Bar chargingBar;

    //private string attack = "Attack1";
    //private string combine = "Combine1";
	
	public float timer = 0.0f;

    private GameObject tornado;

    void Start()
	{

        offset = new Vector3(2, 0, 0);
        playerObject = gameObject.GetComponent<Player>();

        chargingBar = gameObject.GetComponent<Player>().chargingBar;
        //1 sec max
        chargingBar.SetMaxHealth(1);
        chargingBar.SetHealth(0);
    }

    // Update is called once per frame
    void Update()
    {

        turnWeapon();
        createOffset();
        changeBulletColor();
        chargeCombination();

        if (Input.GetKeyDown(player.playerFire) && player.elementalsPossesed[player.actualElementalIndex]!=0)
        //if (GameInputManager.GetKeyDown(attack))
        {
            Shoot();
        }

        distanceToOtherPlayer = (transform.position - otherPlayer.transform.position).sqrMagnitude;

    }


    void changeBulletColor()
    {
        bulletColor = Player.ElementalsTOColorRGB[player.elementalsPossesed[player.actualElementalIndex]];
    }

    void chargeCombination()
    {

        //if (GameInputManager.GetKeyDown(combine))
        if(Input.GetKeyDown(player.playerCombination) &&
            player.elementalsPossesed[player.actualElementalIndex] != Player.ElementalsAvailable.HUMAN &&
            otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex] != Player.ElementalsAvailable.HUMAN &&
            distanceToOtherPlayer <= 5)
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
            amountTimePressed = 0;
            chargingBar.SetHealth(amountTimePressed);
            
            
        }

        if (pressedKey && 
            player.elementalsPossesed[player.actualElementalIndex] != Player.ElementalsAvailable.HUMAN &&
            otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex] != Player.ElementalsAvailable.HUMAN &&
            distanceToOtherPlayer <= 5)
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
        Player.ElementalsAvailable playerElemental = player.elementalsPossesed[player.actualElementalIndex];
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Bullet>().makeColor(bulletColor);
        if (playerElemental == Player.ElementalsAvailable.FIRE) // fire makes more damage
        {
            projectile.GetComponent<Bullet>().fire();
        }
        if (playerElemental == Player.ElementalsAvailable.ELECTRICITY) // electricity makes faster shots
        {
            projectile.GetComponent<Bullet>().electricity();
        }
        if (playerElemental == Player.ElementalsAvailable.GROUND) // this is dumb but its for the rock
        {
            projectile.GetComponent<Bullet>().ground();
        }
        if (playerElemental == Player.ElementalsAvailable.AIR) // this is dumb but its for the rock
        {
            projectile.GetComponent<Bullet>().air();
        }
        if (playerElemental == Player.ElementalsAvailable.WATER) // this is dumb but its for the rock
        {
            projectile.GetComponent<Bullet>().water();
        }
    }

    void Combine()
    {

        Player.ElementalsAvailable myElement = player.elementalsPossesed[player.actualElementalIndex];
        Player.ElementalsAvailable otherElement = player.elementalsPossesed[otherPlayer.actualElementalIndex];

        if (distanceToOtherPlayer <= 5) {

            if (myElement == Player.ElementalsAvailable.WATER && otherElement == Player.ElementalsAvailable.GROUND ||
                myElement == Player.ElementalsAvailable.GROUND && otherElement == Player.ElementalsAvailable.WATER)
            {
                GameObject tree = Instantiate(combiningTreePrefab, firePoint.position + offset, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == Player.ElementalsAvailable.WATER && otherElement == Player.ElementalsAvailable.AIR ||
                myElement == Player.ElementalsAvailable.AIR && otherElement == Player.ElementalsAvailable.WATER)
            {
                tornado = Instantiate(fusionTornadoPrefab, player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                tornado.GetComponent<Tornado>().assignPlayers(player, otherPlayer);
            }
			if (myElement == Player.ElementalsAvailable.FIRE && otherElement == Player.ElementalsAvailable.AIR ||
                myElement == Player.ElementalsAvailable.AIR && otherElement == Player.ElementalsAvailable.FIRE)
            {
                tornado = Instantiate(fusionTornadoPrefab, player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                tornado.GetComponent<Tornado>().red();
                tornado.GetComponent<Tornado>().assignPlayers(player, otherPlayer);
            }
			if (myElement == Player.ElementalsAvailable.GROUND && otherElement == Player.ElementalsAvailable.AIR ||
                myElement == Player.ElementalsAvailable.AIR && otherElement == Player.ElementalsAvailable.GROUND)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == Player.ElementalsAvailable.ELECTRICITY && otherElement == Player.ElementalsAvailable.AIR ||
                myElement == Player.ElementalsAvailable.AIR && otherElement == Player.ElementalsAvailable.ELECTRICITY)
            {

                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
            if (myElement == Player.ElementalsAvailable.GROUND && otherElement == Player.ElementalsAvailable.FIRE ||
                myElement == Player.ElementalsAvailable.FIRE && otherElement == Player.ElementalsAvailable.GROUND)
            {
                Instantiate(magmaPrefab, firePoint.position + offset, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == Player.ElementalsAvailable.GROUND && otherElement == Player.ElementalsAvailable.ELECTRICITY ||
                myElement == Player.ElementalsAvailable.ELECTRICITY && otherElement == Player.ElementalsAvailable.GROUND)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == Player.ElementalsAvailable.WATER && otherElement == Player.ElementalsAvailable.FIRE ||
                myElement == Player.ElementalsAvailable.FIRE && otherElement == Player.ElementalsAvailable.WATER)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == Player.ElementalsAvailable.FIRE && otherElement == Player.ElementalsAvailable.ELECTRICITY ||
                myElement == Player.ElementalsAvailable.ELECTRICITY && otherElement == Player.ElementalsAvailable.FIRE)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == Player.ElementalsAvailable.WATER && otherElement == Player.ElementalsAvailable.ELECTRICITY ||
                myElement == Player.ElementalsAvailable.ELECTRICITY && otherElement == Player.ElementalsAvailable.WATER)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == otherElement && myElement != Player.ElementalsAvailable.HUMAN)
            {
                GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                projectile.GetComponent<Bullet>().makeColor(bulletColor);
                projectile.GetComponent<Bullet>().makeBigger();

                if (myElement == Player.ElementalsAvailable.GROUND)
                {
                    projectile.GetComponent<Bullet>().ground();
                }
            }
        }
    }




    void turnWeapon()
    {
        if (Input.GetAxisRaw(playerObject.PlayerHorizontal) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetAxisRaw(playerObject.PlayerHorizontal) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetAxisRaw(playerObject.PlayerVertical) == 1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        if (Input.GetAxisRaw(playerObject.PlayerVertical) == -1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
    }


    void createOffset()
    {
        if (Input.GetAxisRaw(playerObject.PlayerHorizontal) == 1)
        {
            offset = new Vector3(2, 0, 0);
        }

        if (Input.GetAxisRaw(playerObject.PlayerHorizontal) == -1)
        {
            offset = new Vector3(-2, 0, 0);
        }

        if (Input.GetAxisRaw(playerObject.PlayerVertical) == 1)
        {
            offset = new Vector3(0, 2, 0);
        }

        if (Input.GetAxisRaw(playerObject.PlayerVertical) == -1)
        {
            offset = new Vector3(0, -2, 0);
        }
    }
}
