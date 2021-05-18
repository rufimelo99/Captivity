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
    public int rotation;

    void Start()
    {
        firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
        rotation = 1;
        StartCoroutine(ShotTimer());
    }

    //Doors kinda
    [SerializeField]
    private Tilemap tileMap;
    [SerializeField]
    private Tile tileExample;


    IEnumerator ShotTimer()
    {
        WaitForSeconds pause = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return pause;
            Shoot();
            Rotate();
        }
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bullet")
        {
            health = health - obj.GetComponent<Bullet>().damage;  // obj.gameObject.GetComponent<Bullet>().color == 0

            if (health <= 0 && tileMap != null)
            {

          

                Vector3Int wallLocation0_0Doorlayer = new Vector3Int(-5, -15, 0);
                Vector3Int wallLocation0_1Doorlayer = new Vector3Int(-5, -14, 0);
                Vector3Int wallLocation0_2Doorlayer = new Vector3Int(-5, -13, 0);
                Vector3Int wallLocation0_3Doorlayer = new Vector3Int(-4, -13, 0);
                Vector3Int wallLocation0_4Doorlayer = new Vector3Int(-4, -14, 0);
                Vector3Int wallLocation0_5Doorlayer = new Vector3Int(-4, -15, 0);
                Vector3Int wallLocation0_6Doorlayer = new Vector3Int(-3, -13, 0);
                Vector3Int wallLocation0_7Doorlayer = new Vector3Int(-3, -14, 0);
                Vector3Int wallLocation0_8Doorlayer = new Vector3Int(-3, -15, 0);
                tileMap.SetTile(wallLocation0_0Doorlayer, null);
                tileMap.SetTile(wallLocation0_1Doorlayer, null);
                tileMap.SetTile(wallLocation0_2Doorlayer, null);
                tileMap.SetTile(wallLocation0_3Doorlayer, null);
                tileMap.SetTile(wallLocation0_4Doorlayer, null);
                tileMap.SetTile(wallLocation0_5Doorlayer, null);
                tileMap.SetTile(wallLocation0_6Doorlayer, null);
                tileMap.SetTile(wallLocation0_7Doorlayer, null);
                tileMap.SetTile(wallLocation0_8Doorlayer, null);
            }
            
            animator.SetFloat("enemyHealth", health);
            healthBar.fillAmount = health / 10f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Rotate()
    {
        if (rotation == 0)
        {
            firePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            rotation = 1;
        }
        else
        {
            if (rotation == 1)
            {
                firePoint.rotation = Quaternion.Euler(0f, 180f, 330f);
                rotation = 2;
            }
            else
            {
                if (rotation==2)
                {
                    firePoint.rotation = Quaternion.Euler(0f, 180f, 290f);
                    rotation = 3;
                }
                else 
                {
                    firePoint.rotation = Quaternion.Euler(0f, 0f, 270f);
                    rotation = 0;
                }
            }
        }
    }
}
