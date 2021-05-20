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
	public GameObject fusionTornadoPrefab;
    public GameObject magmaPrefab;
	

    private bool pressedKey = false;
    private float startTime = 0;
    private float amountTimePressed = 0;
    private HP_Bar chargingBar;

    //private string attack = "Attack1";
    //private string combine = "Combine1";
	
	public float timer = 0.0f;

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
        if(Input.GetKeyDown(player.playerCombination))
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
        if (distanceToOtherPlayer <= 5) {
            //check if their colors are different only
            if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 1 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 3 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 3 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 1)
            {
                GameObject tree = Instantiate(combiningTreePrefab, firePoint.position + offset, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 1 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 5 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 5 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 1)
            {
                /*while (timer >= 0){*/
					//Player.ElementalsTOColor[player.active] = false;
					//Player.ElementalsTOColor[otherPlayer.active] = false;
                	GameObject tornado = Instantiate(fusionTornadoPrefab, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
					//tornado.active = true;
				//}else{
					//Player.ElementalsTOColor[player.active] = true;
					//Player.ElementalsTOColor[otherPlayer.active] = true;
					//tornado.active = false;
				//}
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 2 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 5 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 5 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 2)
            {
                
                GameObject tornado = Instantiate(fusionTornadoPrefab, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 3 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 5 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 5 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 3)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 4 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 5 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 5 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 4)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 2 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 3 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 3 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 2)
            {
                Instantiate(magmaPrefab, firePoint.position + offset, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 3 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 4 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 4 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 3)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 1 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 2 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 2 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 1)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 2 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 4 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 4 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 2)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 1 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 4 || 
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 4 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 1)
            {
                
                //GameObject XXXXX = Instantiate(XXXXXXXX, firePoint.position /*+ offset*/, Quaternion.Euler(0f, 0f, 0f));
            }
			if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 1 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 1 ||
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 2 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 2 ||
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 3 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 3 ||
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 4 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 4 ||
                Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 5 && Player.ElementalsTOColor[otherPlayer.elementalsPossesed[otherPlayer.actualElementalIndex]] == 5)
            {
                GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                projectile.GetComponent<Bullet>().makeColor(bulletColor);
                projectile.GetComponent<Bullet>().makeBigger();

                if (Player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]] == 3)
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
