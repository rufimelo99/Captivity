using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightTeleporter : MonoBehaviour
{


    public GameObject otherLight;
    public CircleCollider2D outerLimit;
    public Light2D myLight;


    private bool wingardiumLeviosa = false;


    void Start()
    {
        myLight.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player" || obj.gameObject.tag == "Player2")
        {
            myLight.enabled = true;
        }
    }


    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "Player" || obj.tag == "Player2")
        {
            myLight.enabled = false;
        }
    }


    void OnCollisionEnter2D(Collision2D obj)
    {
        if (wingardiumLeviosa)
        {
            ;
        }
        else if ((obj.gameObject.tag == "Player" || obj.gameObject.tag == "Player2") &&
            obj.gameObject.GetComponent<Player>().elementalsPossesed[obj.gameObject.GetComponent<Player>().actualElementalIndex] == Player.ElementalsAvailable.ELECTRICITY)
        {
            otherLight.GetComponent<LightTeleporter>().disableForAFewSeconds();
            obj.gameObject.transform.position = otherLight.transform.position;
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
