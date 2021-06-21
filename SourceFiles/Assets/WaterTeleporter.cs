using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTeleporter : MonoBehaviour
{
    public GameObject otherWater;
    public bool up = false; // up if camera has to go up

    private bool wingardiumLeviosa = false;
    [SerializeField]
    private Transform camera1;
    [SerializeField]
    private Transform camera2;

    private Vector3 move;


    void Start()
    {
        if (up)
        {
            move = new Vector3(0, 24, 0);
        }
        else
        {
            move = new Vector3(0, -24, 0);
        }
    }



    void OnTriggerEnter2D(Collider2D obj)
    {
        if (wingardiumLeviosa)
        {
            ;
        }
        else 
        { 
            if (obj.tag == "Player" &&
                obj.GetComponent<Player>().elementalsPossesed[obj.GetComponent<Player>().actualElementalIndex] ==
            Player.ElementalsAvailable.WATER)
            {
                otherWater.GetComponent<WaterTeleporter>().disableForAFewSeconds();
                obj.transform.position = otherWater.transform.position;
                camera1.position += move;
            }
            if (obj.gameObject.tag == "Player2" &&
            obj.GetComponent<Player>().elementalsPossesed[obj.GetComponent<Player>().actualElementalIndex] ==
            Player.ElementalsAvailable.WATER)
            {
                otherWater.GetComponent<WaterTeleporter>().disableForAFewSeconds();
                obj.transform.position = otherWater.transform.position;
                camera2.position += move;
            }
            
        } 
    }

    public void disableForAFewSeconds()
    {
        StartCoroutine(YouAreAWizardHarry());
    }


    IEnumerator YouAreAWizardHarry()
    {
        wingardiumLeviosa = true;
        WaitForSeconds pause = new WaitForSeconds(0.05f);
        yield return pause;
        wingardiumLeviosa = false;
    }
}
