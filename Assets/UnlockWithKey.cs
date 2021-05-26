using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWithKey : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private Player otherPlayer;

    private float distanceToPlayer1;
    private float distanceToPlayer2;

    [SerializeField]
    private GameObject locker;
    [SerializeField]
    private GameObject grid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer1 = (transform.position - player.transform.position).sqrMagnitude;
        distanceToPlayer2 = (transform.position - otherPlayer.transform.position).sqrMagnitude;
        
        if((distanceToPlayer1 < 2 || distanceToPlayer2 < 2)){
            GlobalControl.Instance.deleteKey(GlobalControl.KeysAvailable.KEYELECT1);
            Destroy(grid);
            Destroy(locker);
        }
    }
}
//&& (GlobalControl.Instance.keysCollected.Contains(GlobalControl.KeysAvailable.KEYELECT1)