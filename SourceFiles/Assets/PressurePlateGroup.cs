using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PressurePlateGroup : MonoBehaviour
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
    bool allPressurePlatesActiovated = true;
        foreach(PressurePlate_v2 pressurePlate in pressurePlates)
        {
            if (!pressurePlate.activated)
            {
                allPressurePlatesActiovated = false;
                break;
            }
        }
        if (allPressurePlatesActiovated)
        {
            Destroy(grid);
        }
    }
}
