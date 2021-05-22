using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;


    public int CompletedLevels;
    public List<Player.ElementalsAvailable> elementalsPossesed = new List<Player.ElementalsAvailable>();

    public List<GemsAvailable> gemsCollected = new List<GemsAvailable>();
    
    [HideInInspector]
    public enum GemsAvailable
    {
        WATER, //1
        FIRE, //2
        GROUND, //3
        ELECTRICITY, //4
        AIR,
        WIZARD
    }



    public void addGemWithoutRepetition(GemsAvailable gem)
    {
        //if (!gemsCollected.Contains(gem))
        //{
        Debug.Log('g');
        gemsCollected.Add(gem);
        //}
    }



    void Awake()
    {
        elementalsPossesed.Add(Player.ElementalsAvailable.HUMAN);

        //THESE ARE NOT THE GEMS YOU ARE LOOKING FOR
        //gemsCollected.Add(GlobalControl.GemsAvailable.WATER);


        //FOR TESTS - DO NOT FORGET TO COMMENT FOR THE BUILD 
        elementalsPossesed.Add(Player.ElementalsAvailable.WATER);
        elementalsPossesed.Add(Player.ElementalsAvailable.GROUND);
        elementalsPossesed.Add(Player.ElementalsAvailable.FIRE);
        elementalsPossesed.Add(Player.ElementalsAvailable.AIR);
        elementalsPossesed.Add(Player.ElementalsAvailable.ELECTRICITY);

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void addWithoutRepetition(Player.ElementalsAvailable elemental)
    {
        if (!elementalsPossesed.Contains(elemental))
        {
            elementalsPossesed.Add(elemental);
        }
    }
}

