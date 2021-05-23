using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsFound : MonoBehaviour
{

    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;
    public GameObject gem4;
    public GameObject gem5;
    public GameObject gem6;



    // Start is called before the first frame update
    void Start()
    {
        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.WATER)){
            gem1.GetComponent<Gem>().notFoundShowInMenu();   //Destroy(gem1);
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.GROUND)){
            gem2.GetComponent<Gem>().notFoundShowInMenu(); // Destroy(gem2);
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.FIRE)){
            gem3.GetComponent<Gem>().notFoundShowInMenu();
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.AIR)){
            gem4.GetComponent<Gem>().notFoundShowInMenu();
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.ELECTRICITY)){
            gem5.GetComponent<Gem>().notFoundShowInMenu();
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.WIZARD)){
            gem6.GetComponent<Gem>().notFoundShowInMenu();
        }
    }

}
