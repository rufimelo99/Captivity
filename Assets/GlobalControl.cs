using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;


    public int CompletedLevels;
    public List<Player.ElementalsAvailable> elementalsPossesed = new List<Player.ElementalsAvailable>();

    public List<GemsAvailable> gemsCollected = new List<GemsAvailable>();
    public List<KeysAvailable> keysCollected = new List<KeysAvailable>();
    public bool[] pagesCollected;
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

    [HideInInspector]
    public enum KeysAvailable
    {
        KEYELECT1
    }




    public void addGemWithoutRepetition(GemsAvailable gem)
    {
        //if (!gemsCollected.Contains(gem))
        //{
        //Debug.Log('g');
        gemsCollected.Add(gem);
        //}
    }

    public void addKey(KeysAvailable key)
    {
        keysCollected.Add(key);
    }

    public void deleteKey(KeysAvailable key)
    {
        keysCollected.Remove(key);
    }


    

    void Awake()
    {
        elementalsPossesed.Add(Player.ElementalsAvailable.HUMAN);

        CompletedLevels = 0;

        //THESE ARE NOT THE GEMS YOU ARE LOOKING FOR
        /*gemsCollected.Add(GlobalControl.GemsAvailable.WATER);
        gemsCollected.Add(GlobalControl.GemsAvailable.FIRE);
        gemsCollected.Add(GlobalControl.GemsAvailable.GROUND);
        gemsCollected.Add(GlobalControl.GemsAvailable.AIR);
        gemsCollected.Add(GlobalControl.GemsAvailable.ELECTRICITY);
        gemsCollected.Add(GlobalControl.GemsAvailable.WIZARD);
        */

        //FOR TESTS - DO NOT FORGET TO COMMENT FOR THE BUILD 
        elementalsPossesed.Add(Player.ElementalsAvailable.WATER);
        elementalsPossesed.Add(Player.ElementalsAvailable.GROUND);
        elementalsPossesed.Add(Player.ElementalsAvailable.FIRE);
        elementalsPossesed.Add(Player.ElementalsAvailable.AIR);
        elementalsPossesed.Add(Player.ElementalsAvailable.ELECTRICITY);
        pagesCollected = new bool[16]; //needs to be equal to the number of pages on the book
        /*#To allow all the pages on the diary
        for (int i=0; i<pagesCollected.Length; i++)
        {
            pagesCollected[i] = true;
        }*/
        

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

