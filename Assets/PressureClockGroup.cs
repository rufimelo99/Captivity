using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PressureClockGroup : MonoBehaviour
{
    public List<PressurePlate_v2> pressurePlates;
    
    [SerializeField]
    private GameObject Chest;
    [SerializeField]
    private GameObject Key;

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
            Chest.GetComponent<Animator>().Play("ChestOpen");
            Key.GetComponent<Animator>().Play("KeyOpening"); 
        }
        else
        {
            Chest.GetComponent<Animator>().Play("ChestClose");
            Key.GetComponent<Animator>().Play("KeyClose");
        }
    }
}

