using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureCaptivityGroup : MonoBehaviour
{

    public List<PressurePlate_v2> pressurePlates;
    [SerializeField]
    private GameObject grid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allPressurePlatesActivated = true;
        foreach(PressurePlate_v2 pressurePlate in pressurePlates)
        {
            if (!pressurePlate.activated)
            {
                allPressurePlatesActivated = false;
                break;
            }
        }
        if (allPressurePlatesActivated)
        {
            Destroy(grid);
        }
    }
}
