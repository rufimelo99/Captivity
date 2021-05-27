using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBullet : MonoBehaviour
{

    private float speed = 10f;
    private Vector3 playerPosition;

    public void assignPlayer(Transform player)
    {
        playerPosition = player.position;
    }


    void Start()
    {
        transform.rotation = Quaternion.LookRotation(playerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward towards the player's last known direction;
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
