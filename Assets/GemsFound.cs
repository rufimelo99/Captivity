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
            Destroy(gem1);
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.GROUND)){
            Destroy(gem2);
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.FIRE)){
            Destroy(gem3);
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.AIR)){
            Destroy(gem4);
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.ELECTRICITY)){
            Destroy(gem5);
        }

        if (!GlobalControl.Instance.gemsCollected.Contains(GlobalControl.GemsAvailable.WIZARD)){
            Destroy(gem6);
        }
    }

}
