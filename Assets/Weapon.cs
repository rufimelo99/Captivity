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

    private GameObject tornado;
    private bool isThereATornado = false;  // to know if there is a tornado daaa

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

        if (isThereATornado)  // THIS STIL DOESN'T WORK BU I DONNON WHY DAFUCK
        {
            if (tornado.GetComponent<Tornado>().noMoreTornados) // set the players to active again and then destory the sucker
            {
                tornado.GetComponent<Tornado>().GenocideBaby();
                ShowPlayers();      
            }
        }

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

        Player.ElementalsAvailable myElement = player.elementalsPossesed[player.actualElementalIndex];
        Player.ElementalsAvailable otherElement = player.elementalsPossesed[otherPlayer.actualElementalIndex];

        if (distanceToOtherPlayer <= 5) {
            //check if their colors are different only
            if (myElement == Player.ElementalsAvailable.WATER && otherElement == Player.ElementalsAvailable.GROUND ||
                myElement == Player.ElementalsAvailable.GROUND && otherElement == Player.ElementalsAvailable.WATER)
            {
                GameObject tree = Instantiate(combiningTreePrefab, firePoint.position + offset, Quaternion.Euler(0f, 0f, 0f));
            }
			if (myElement == Player.ElementalsAvailable.WATER && otherElement == Player.ElementalsAvailable.AIR ||
                myElement == Player.ElementalsAvailable.AIR && otherElement == Player.ElementalsAvailable.WATER)
            {
                isThereATornado = true;
                tornado = Instantiate(fusionTornadoPrefab, player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                HideAndShow(10.0f);
            }
			if (myElement == Player.ElementalsAvailable.FIRE && otherElement == Player.ElementalsAvailable.AIR ||
                myElement == Player.ElementalsAvailable.AIR && otherElement == Player.ElementalsAvailable.FIRE)
            {
                isThereATornado = true;
                tornado = Instantiate(fusionTornadoPrefab, player.transform.position, Quaternion.Euler(0f, 0f, 0f));
                HideAndShow(10.0f);
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
			if (myElement == otherElement)
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


    private void HideAndShow(float delay)
    {
        player.gameObject.SetActive(false);
        otherPlayer.gameObject.SetActive(false);

        // Call Show after delay seconds
        if (isThereATornado)
        {
            Invoke(nameof(ShowPlayers), delay);
        }
    }

    private void ShowPlayers()
    {
        isThereATornado = false;

        player.gameObject.SetActive(true); //put back player 1
        player.gameObject.transform.position = tornado.transform.position;
        player.putTheRightColor();

        otherPlayer.gameObject.SetActive(true);  //put back player 1
        otherPlayer.gameObject.transform.position = tornado.transform.position;
        otherPlayer.putTheRightColor();
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
