using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;


    public int CompletedLevels;
    public List<Player.ElementalsAvailable> elementalsPossesed = new List<Player.ElementalsAvailable>();

    //public List<Player.ElementalsAvailable> elementalsPossesed2 = new List<Player.ElementalsAvailable>();

    

    void Awake()
    {
        elementalsPossesed.Add(Player.ElementalsAvailable.HUMAN);

        //FOR FIRE TESTS
        //elementalsPossesed.Add(Player.ElementalsAvailable.WATER);
        //elementalsPossesed.Add(Player.ElementalsAvailable.GROUND);
        //elementalsPossesed.Add(Player.ElementalsAvailable.FIRE);

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

