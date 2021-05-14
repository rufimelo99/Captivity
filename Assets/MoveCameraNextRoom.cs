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
    [SerializeField]
    private bool vertical;

    private Vector3 right;
    private Vector3 left;
    private Vector3 up;
    private Vector3 down;


    void Start()
    {
        right = new Vector3(27, 0, 0);
        left = new Vector3(-27, 0, 0);
        up = new Vector3(0, 24, 0);
        down = new Vector3(0, -24, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (gameObject.tag == "Room Changer Next")
        {
            if (vertical)
            {
                if (collision.tag == "Player")
                {

                    camera1.position += up;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Player2")
                {

                    camera2.position += up;
                    collision.gameObject.transform.position = nextPosition.position;

                }
            }
            else
            {
                if (collision.tag == "Player")
                {

                    camera1.position += right;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Player2")
                {

                    camera2.position += right;
                    collision.gameObject.transform.position = nextPosition.position;

                }
            }
        }
        if (gameObject.tag == "Room Changer Back")
        {
            if (vertical)
            {
                if (collision.tag == "Player")
                {

                    camera1.position += down;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Player2")
                {

                    camera2.position += down;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Evil Touch")
                {
                    collision.gameObject.transform.position = nextPosition.position;

                }
            }
            else
            {
                if (collision.tag == "Player")
                {

                    camera1.position += left;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Player2")
                {

                    camera2.position +=  left;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Evil Touch")
                {
                    collision.gameObject.transform.position = nextPosition.position;

                }
            }
        }

    }

       
    

}
