using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{

    public bool DEBUG = false;
    public int playerId;
    [HideInInspector]
    public int actualElementalIndex = 0;
    [HideInInspector]
    public List<ElementalsAvailable> elementalsPossesed = new List<ElementalsAvailable>();

    //need to be editable after during the game play
    [HideInInspector]
    public KeyCode selectNextElemental = KeyCode.L;
    [HideInInspector]
    public KeyCode selectPreviousElemental = KeyCode.K;
    [HideInInspector]
    public KeyCode playerFire = KeyCode.Minus;
    [HideInInspector]
    public KeyCode playerCombination = KeyCode.RightShift;

    //animator and controls
    [HideInInspector]
    public string PlayerColor = "Color";
    [HideInInspector]
    public string PlayerHorizontal = "Horizontal";
    [HideInInspector]
    public string PlayerVertical = "Vertical";

    public Rigidbody2D rb;
    public Animator animator;

    [HideInInspector]
    public float health = 10f;
    public Image healthBar = null;

    //check both
    [HideInInspector]
    public bool isCharging = false;
    [HideInInspector]
    public bool tryingCombination = false;

    public HP_Bar hpBar;
    public HP_Bar chargingBar;

    //duplicated
    //also on ChooseElemental.cs 
    [SerializeField]
    public enum ElementalsAvailable
    {
        HUMAN, //0
        WATER, //1
        FIRE, //2
        GROUND, //3
        ELECTRICITY, //4
        AIR //5
        //DARK, //6
        //LIGHT //7
    }
    public static Dictionary<ElementalsAvailable, int> ElementalsTOColor = new Dictionary<ElementalsAvailable, int> 
    {
        {ElementalsAvailable.HUMAN, 0 },
        {ElementalsAvailable.WATER, 1 },
        {ElementalsAvailable.FIRE, 2 },
        {ElementalsAvailable.GROUND, 3 },
        {ElementalsAvailable.ELECTRICITY, 4 },
        {ElementalsAvailable.AIR, 5 },


    };


    public static Dictionary<Player.ElementalsAvailable, Color> ElementalsTOColorRGB = new Dictionary<Player.ElementalsAvailable, Color>
    {
        {ElementalsAvailable.HUMAN, Color.white},
        {ElementalsAvailable.WATER, new Color(0, 0, 233)},
        {ElementalsAvailable.FIRE, Color.red},
        {ElementalsAvailable.GROUND, Color.green},
        {ElementalsAvailable.ELECTRICITY, new Color(255, 233, 0)},
        {ElementalsAvailable.AIR, new Color(255, 255, 255)},
    };

    // Start is called before the first frame update
    void Start()
    {
        if (playerId == 2)
        {
            selectPreviousElemental = KeyCode.Q;
            selectNextElemental = KeyCode.E;
            playerFire = KeyCode.Space;
            playerCombination = KeyCode.V; // V


            PlayerColor = "Color2";
            PlayerHorizontal = "Horizontal2";
            PlayerVertical = "Vertical2";

        }

        //initialize dictionary that converts element to integer
        //ElementalsTOColor.Add(ElementalsAvailable.HUMAN, 0);
        //ElementalsTOColor.Add(ElementalsAvailable.WATER, 1);
        //ElementalsTOColor.Add(ElementalsAvailable.FIRE, 2);
        //ElementalsTOColor.Add(ElementalsAvailable.GROUND, 3);
        //ElementalsTOColor.Add(ElementalsAvailable.ELECTRICITY, 4);
        //ElementalsTOColor.Add(ElementalsAvailable.AIR, 5);
        //ElementalsTOColor.Add(ElementalsAvailable.DARK, 5);
        //ElementalsTOColor.Add(ElementalsAvailable.LIGHT, 6);

        /*
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.HUMAN, Color.grey);
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.WATER, new Color(0, 0, 233));
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.FIRE, Color.red); //vermelho new Color(0.7f, 0.2f, 1)
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.GROUND, Color.green);//castanho
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.ELECTRICITY, new Color(255, 233, 0));//amarelo kinda
        ElementalsTOColorRGB.Add(Player.ElementalsAvailable.AIR, new Color(255, 255, 255));*/
        //ElementalsTOColorRGB.Add(ElementalsAvailable.DARK, Color.black);//preto 
        //ElementalsTOColorRGB.Add(ElementalsAvailable.LIGHT, Color.yellow);//branco



        //Elements that player have

        elementalsPossesed = GlobalControl.Instance.elementalsPossesed;
        //elementalsPossesed.Add(ElementalsAvailable.HUMAN);
        //elementalsPossesed.Add(ElementalsAvailable.WATER);
        //elementalsPossesed.Add(ElementalsAvailable.FIRE);
        //elementalsPossesed.Add(ElementalsAvailable.GROUND);
        //elementalsPossesed.Add(ElementalsAvailable.ELECTRICITY);
        //elementalsPossesed.Add(ElementalsAvailable.AIR);
        //elementalsPossesed.Add(ElementalsAvailable.DARK);
        //elementalsPossesed.Add(ElementalsAvailable.LIGHT);


        //PlayerColor
        animator.SetInteger("Color", Player.ElementalsTOColor[elementalsPossesed[actualElementalIndex]]);
        
        hpBar.SetMaxHealth(health);
    }


    public void putTheRightColor()
    {
        animator.SetInteger("Color", Player.ElementalsTOColor[elementalsPossesed[actualElementalIndex]]);
    }


    void Update()
    {

        hpBar.SetHealth(health);
        if (health <= 0.1)
        {
            die();
        }
        goToMenu();
    }

    void die()
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent("PlayerDied");
        Debug.Log("analyticsResult: " + analyticsResult);
        health = 10f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }



    void goToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
