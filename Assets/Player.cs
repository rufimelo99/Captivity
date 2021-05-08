using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public KeyCode playerFire = KeyCode.Minus; //KeyCode
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
        HUMAN,
        FIRE,
        WATER,
        GROUND,
        AIR,
        ELECTRICITY,
        DARK,
        LIGHT
    }
    public Dictionary<ElementalsAvailable, int> ElementalsTOColor = new Dictionary<ElementalsAvailable, int>();

    public Dictionary<ElementalsAvailable, Color> ElementalsTOColorRGB = new Dictionary<ElementalsAvailable, Color>();

    // Start is called before the first frame update
    void Start()
    {
        if (playerId == 2)
        {
            selectPreviousElemental = KeyCode.Q;
            selectNextElemental = KeyCode.E;
            playerFire = KeyCode.Space;
            playerCombination = KeyCode.V;


            PlayerColor = "Color2";
            PlayerHorizontal = "Horizontal2";
            PlayerVertical = "Vertical2";

        }

        //initialize dictionary that converts element to integer
        ElementalsTOColor.Add(ElementalsAvailable.HUMAN, 0);
        ElementalsTOColor.Add(ElementalsAvailable.WATER, 1);
        ElementalsTOColor.Add(ElementalsAvailable.FIRE, 2);
        ElementalsTOColor.Add(ElementalsAvailable.GROUND, 3);
        ElementalsTOColor.Add(ElementalsAvailable.ELECTRICITY, 4);
        ElementalsTOColor.Add(ElementalsAvailable.DARK, 5);
        ElementalsTOColor.Add(ElementalsAvailable.LIGHT, 6);


        ElementalsTOColorRGB.Add(ElementalsAvailable.HUMAN, Color.green);
        ElementalsTOColorRGB.Add(ElementalsAvailable.WATER, Color.blue );
        ElementalsTOColorRGB.Add(ElementalsAvailable.FIRE, Color.red); //vermelho new Color(0.7f, 0.2f, 1)
        ElementalsTOColorRGB.Add(ElementalsAvailable.GROUND, Color.green /*new Color(0.9f, 0.3f, 0.3f)*/);//castanho
        ElementalsTOColorRGB.Add(ElementalsAvailable.ELECTRICITY, new Color(0.6f, 0.6f, 1)/*new Color(0, 0.9f, 0.1f)*/);//amarelo kinda
        ElementalsTOColorRGB.Add(ElementalsAvailable.DARK, Color.black /*new Color(0.3f, 0.9f, 1)*/);//preto 
        ElementalsTOColorRGB.Add(ElementalsAvailable.LIGHT, Color.yellow /*new Color(0, 0.1f, 1)*/);//branco

        //Elements that player have
        elementalsPossesed.Add(ElementalsAvailable.HUMAN);
        elementalsPossesed.Add(ElementalsAvailable.WATER);
        //elementalsPossesed.Add(ElementalsAvailable.FIRE);
        //elementalsPossesed.Add(ElementalsAvailable.GROUND);
        //elementalsPossesed.Add(ElementalsAvailable.ELECTRICITY);
        //elementalsPossesed.Add(ElementalsAvailable.DARK);
        //elementalsPossesed.Add(ElementalsAvailable.LIGHT);
        
        if (DEBUG)
        {
            for(int i=0; i<elementalsPossesed.Count; i++)
            {
                Debug.Log("elemntalsPossesed: "+ elementalsPossesed[i]);
            }
            Debug.Log("ActualElementalIndex" + actualElementalIndex);
            Debug.Log("ActualElemental" + elementalsPossesed[actualElementalIndex]);

        }
        
        

        animator.SetInteger(PlayerColor, ElementalsTOColor[elementalsPossesed[actualElementalIndex]]);
        
        hpBar.SetMaxHealth(health);

    }

    // Update is called once per frame
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
