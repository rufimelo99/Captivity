using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraNextRoom : MonoBehaviour
{

    [SerializeField]
    private Transform camera1;
    [SerializeField]
    private Transform camera2;
    [SerializeField]
    private Transform nextPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (gameObject.tag == "Room Changer Next")
        {
            if (collision.tag == "Player")
            {

                camera1.position += new Vector3(27, 0, 0);
                collision.gameObject.transform.position = nextPosition.position;

            }
            if (collision.tag == "Player2")
            {

                camera2.position += new Vector3(27, 0, 0);
                collision.gameObject.transform.position = nextPosition.position;

            }
        }
        if (gameObject.tag == "Room Changer Back")
        {
            if (collision.tag == "Player")
            {

                camera1.position += new Vector3(-27, 0, 0);
                collision.gameObject.transform.position = nextPosition.position;

            }
            if (collision.tag == "Player2")
            {

                camera2.position += new Vector3(-27, 0, 0);
                collision.gameObject.transform.position = nextPosition.position;

            }
            if (collision.tag == "Evil Touch")
            {
                collision.gameObject.transform.position = nextPosition.position;

            }
        }

    }

       
    

}
