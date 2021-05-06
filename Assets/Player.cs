using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool DEBUG = false;
    public int playerId;
    public int actualElementalIndex = 0;
    //not used for the moment
    public float speed = 5.0f;
    public float damagePower = 5.0f;
    [SerializeField]
    public List<ElementalsAvailable> elementalsPossesed = new List<ElementalsAvailable>();

    //need to be editable after during the game play
    [SerializeField]
    public KeyCode selectNextElemental = KeyCode.L;
    [SerializeField]
    public KeyCode selectPreviousElemental = KeyCode.K;
    [SerializeField]
    public KeyCode playerFire = KeyCode.Minus;
    [SerializeField]
    public KeyCode playerCombination = KeyCode.RightShift;

    //animator and controls
    [SerializeField]
    public string PlayerColor = "Color";
    [SerializeField]
    public string PlayerHorizontal = "Horizontal";
    [SerializeField]
    public string PlayerVertical = "Vertical";

    public Rigidbody2D rb;
    public Animator animator;

    public float health = 10f;
    public Image healthBar = null;

    //check both
    public bool isCharging = false;
    public bool tryingCombination = false;

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

        //Elements that player have
        elementalsPossesed.Add(ElementalsAvailable.HUMAN);
        elementalsPossesed.Add(ElementalsAvailable.WATER);
        /*
        elementalsPossesed.Add(ElementalsAvailable.FIRE);
        elementalsPossesed.Add(ElementalsAvailable.GROUND);
        elementalsPossesed.Add(ElementalsAvailable.ELECTRICITY);
        elementalsPossesed.Add(ElementalsAvailable.DARK);
        elementalsPossesed.Add(ElementalsAvailable.LIGHT);
        */
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
        healthBar.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
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
