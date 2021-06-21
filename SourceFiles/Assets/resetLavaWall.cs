using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class resetLavaWall : MonoBehaviour
{
    public GameObject lavaWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        lavaWall.GetComponent<BoxCollider2D>().enabled = true;
    }
}
