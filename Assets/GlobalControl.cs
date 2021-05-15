using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{

    public static GlobalControl Instance;


    public int CompletedLevels;
    public List<Player.ElementalsAvailable> elementalsPossesed = new List<Player.ElementalsAvailable>();

    //public List<Player.ElementalsAvailable> elementalsPossesed2 = new List<Player.ElementalsAvailable>();

    public static Dictionary<Player.ElementalsAvailable, Color> ElementalsTOColorRGB = new Dictionary<Player.ElementalsAvailable, Color>();

    void Awake()
    {
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.HUMAN, Color.grey);
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.WATER, new Color(0, 0, 233));
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.FIRE, Color.red); //vermelho new Color(0.7f, 0.2f, 1)
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.GROUND, Color.green);//castanho
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.ELECTRICITY, new Color(255, 233, 0));//amarelo kinda
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.AIR, new Color(255, 255, 255));
        //ElementalsTOColorRGB.Add(ElementalsAvailable.DARK, Color.black);//preto 
        //ElementalsTOColorRGB.Add(ElementalsAvailable.LIGHT, Color.yellow);//branco



        elementalsPossesed.Add(Player.ElementalsAvailable.HUMAN);

        //FOR FIRE TESTS
        elementalsPossesed.Add(Player.ElementalsAvailable.WATER);
        elementalsPossesed.Add(Player.ElementalsAvailable.GROUND);
        elementalsPossesed.Add(Player.ElementalsAvailable.FIRE);

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
}

