using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraNextRoom : MonoBehaviour
{

    [SerializeField]
    private Transform camera1;
    [SerializeField]
    private Transform camera2;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            camera1.position += new Vector3(27, 0, 0);
        }
        if (collision.tag == "Player2")
        {
            camera2.position += new Vector3(27, 0, 0);
        }
    }

}
