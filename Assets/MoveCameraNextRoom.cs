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

    private Vector3 next;
    private Vector3 previous;

    public int color = 0; // so it only works with a specific element

    public bool onlyTrigger = false;

    public int amountRoomsX = 0;
    public int amountRoomsY = 0; 

    void Start()
    {
        if (vertical)
        {
            next = new Vector3(0, 24, 0);
            previous = new Vector3(0, -24, 0);
        }
        else
        {
            next = new Vector3(27, 0, 0);
            previous = new Vector3(-27, 0, 0);
        }
        
        
    }
    public void TpHero(GameObject gameObject)
    {
        if (gameObject.tag == "Player")
        {
            camera1.position += (amountRoomsX * new Vector3(27, 0, 0)) + (amountRoomsY * new Vector3(0, 24, 0));
        }
        if (gameObject.tag == "Player2")
        {
            camera2.position += (amountRoomsX * new Vector3(27, 0, 0)) + (amountRoomsY * new Vector3(0, 24, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!onlyTrigger)
        {
            if(color == 1 && (collision.tag=="Player" || collision.tag=="Player2") &&
            collision.GetComponent<Player>().elementalsPossesed[collision.GetComponent<Player>().actualElementalIndex] !=
            Player.ElementalsAvailable.WATER)
            {
                ;
            }
       
            else if (gameObject.tag == "Room Changer Next")
            {
            
            
                if (collision.tag == "Player")
                {

                    camera1.position += next;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Player2")
                {

                    camera2.position += next;
                    collision.gameObject.transform.position = nextPosition.position;

                }

                if (collision.tag == "Fusion")
                {
                    camera1.position += next;
                    camera2.position += next;
                    collision.gameObject.transform.position = nextPosition.position;

                }

            }
            else if (gameObject.tag == "Room Changer Back")
            {
            
                if (collision.tag == "Player")
                {

                    camera1.position += previous;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Player2")
                {

                    camera2.position +=  previous;
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Evil Touch")
                {
                    collision.gameObject.transform.position = nextPosition.position;

                }
                if (collision.tag == "Fusion")
                {
                    camera1.position += previous;
                    camera2.position += previous;
                    collision.gameObject.transform.position = nextPosition.position;

                }

            }

            }
       
    }

       
    

}
