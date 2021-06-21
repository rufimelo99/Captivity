using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Enemy2Main : MonoBehaviour
{

    public Animator animator;
    //public Animator animator2;
    public float health = 10f;
    public Image healthBar;
    

    public GameObject bulletPrefab;
    public GameObject projectile;
    public Transform firePoint;
    private int actualDirection;
    private bool shock = false;
    public List<Direction> DirectionsSupported = new List<Direction>();
    public enum Direction
    {
        N,
        N_E,
        N_E1,
        N_E2,
        E,
        E_S1,
        E_S2,
        E_S,
        S,
        S_W1,
        S_W2,
        S_W,
        W,
        W_N1,
        W_N2,
        W_N,
    }


    void Start()
    {
        firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
        actualDirection = 0;
        StartCoroutine(ShotTimer());
    }

    //Doors kinda
    [SerializeField]
    private Tilemap tileMap;
    [SerializeField]
    private Tile tileExample;


    IEnumerator ShotTimer()
    {
        WaitForSeconds pause = new WaitForSeconds(0.9f);
        while (true)
        {
            yield return pause;
            if (!shock)
            {
                Shoot();
            }
            Rotate();
        }
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {

            if (obj.GetComponent<Bullet>().shock)
            {
                StartCoroutine(freeze());
            }



            health = health - obj.GetComponent<Bullet>().damage;  // obj.gameObject.GetComponent<Bullet>().color == 0

            if (health <= 0 && tileMap != null)
            {

          
                
                Vector3Int wallLocation0_0Doorlayer = new Vector3Int(-5, -15, 0); //5
                Vector3Int wallLocation0_1Doorlayer = new Vector3Int(-5, -14, 0);
                Vector3Int wallLocation0_2Doorlayer = new Vector3Int(-5, -13, 0);
                Vector3Int wallLocation0_9Doorlayer = new Vector3Int(-5, -12, 0);

                Vector3Int wallLocation0_3Doorlayer = new Vector3Int(-4, -13, 0); //4
                Vector3Int wallLocation0_4Doorlayer = new Vector3Int(-4, -14, 0);
                Vector3Int wallLocation0_5Doorlayer = new Vector3Int(-4, -15, 0);
                Vector3Int wallLocation0_10Doorlayer = new Vector3Int(-4, -12, 0);

                Vector3Int wallLocation0_6Doorlayer = new Vector3Int(-3, -13, 0); //3
                Vector3Int wallLocation0_7Doorlayer = new Vector3Int(-3, -14, 0);
                Vector3Int wallLocation0_8Doorlayer = new Vector3Int(-3, -15, 0);
                Vector3Int wallLocation0_11Doorlayer = new Vector3Int(-3, -12, 0);

                tileMap.SetTile(wallLocation0_0Doorlayer, null);
                tileMap.SetTile(wallLocation0_1Doorlayer, null);
                tileMap.SetTile(wallLocation0_2Doorlayer, null);
                tileMap.SetTile(wallLocation0_3Doorlayer, null);
                tileMap.SetTile(wallLocation0_4Doorlayer, null);
                tileMap.SetTile(wallLocation0_5Doorlayer, null);
                tileMap.SetTile(wallLocation0_6Doorlayer, null);
                tileMap.SetTile(wallLocation0_7Doorlayer, null);
                tileMap.SetTile(wallLocation0_8Doorlayer, null);
                tileMap.SetTile(wallLocation0_9Doorlayer, null);
                tileMap.SetTile(wallLocation0_10Doorlayer, null);
                tileMap.SetTile(wallLocation0_11Doorlayer, null);
            }
            
            animator.SetFloat("enemyHealth", health);
            healthBar.fillAmount = health / 10f;
        }
    }

    IEnumerator freeze()
    {
        shock = true;
        yield return new WaitForSeconds(1f);
        shock = false;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
    void Rotate()
    {


        //clockwise

        if (DirectionsSupported[actualDirection] == Direction.N)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        
        else if (DirectionsSupported[actualDirection] == Direction.N_E1)
        {

            firePoint.rotation = Quaternion.Euler(0f, 0f, 60f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.N_E)
        {

            firePoint.rotation = Quaternion.Euler(0f, 0f, 45f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.N_E2)
        {

            firePoint.rotation = Quaternion.Euler(0f, 0f, 30f);
        }
        else if(DirectionsSupported[actualDirection] == Direction.E)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //correct

        else if (DirectionsSupported[actualDirection] == Direction.E_S1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, -30f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.E_S)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, -45f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.E_S2)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, -60f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.S)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 270);
        }



        else if (DirectionsSupported[actualDirection] == Direction.W_N1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 330f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.W_N)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 315f);

        }
        else if (DirectionsSupported[actualDirection] == Direction.W_N2)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 300f);

        }
        else if (DirectionsSupported[actualDirection] == Direction.W)
        {

            firePoint.rotation = Quaternion.Euler(0f, 0f, 180f);
        }


        else if (DirectionsSupported[actualDirection] == Direction.S_W1)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 240f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.S_W)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 225f);
        }
        else if (DirectionsSupported[actualDirection] == Direction.S_W2)
        {
            firePoint.rotation = Quaternion.Euler(0f, 0f, 205f);
        }
        if (actualDirection == DirectionsSupported.Count - 1)
        {
            actualDirection = 0;
        }
        else
        {
            actualDirection++;
        }

    }
}
