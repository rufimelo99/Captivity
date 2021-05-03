using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraPreviousRoom : MonoBehaviour
{
    [SerializeField]
    private Transform camera1;
    [SerializeField]
    private Transform camera2;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 roomMover = new Vector3(-27, -1, 0);
            camera1.position += roomMover;
        }
    
        if (collision.tag == "Player2")
        {
            Vector3 roomMover = new Vector3(-27, -1, 0);
            camera2.position += roomMover;
        }
    }
    

}
