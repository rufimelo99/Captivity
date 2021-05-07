using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    public Transform Camera1;
    public Transform Camera2;
    private Vector3 movement;

    [SerializeField]
    private int direction = 0;
    

    void Start()
    {
        if (direction == 0)
        {
            movement = new Vector3(0, 12, 0);
        }
        if (direction == 1)
        {
            movement = new Vector3(0, -12, 0);
        }
        if (direction == 2)
        {
            movement = new Vector3(17, 0, 0);
        }
        if (direction == 3)
        {
            movement = new Vector3(-17, 0, 0);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            Camera1.position = Camera1.position + movement; 
        }

        if (col.tag == "Player2")
        {
            Camera2.position = Camera2.position + movement;
        }
    }
}
