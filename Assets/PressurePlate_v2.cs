using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate_v2 : MonoBehaviour
{

    private SpriteRenderer PressurePlate1_sr;
    private SpriteRenderer Door_sr;
    [SerializeField]
    private Sprite PressurePlateNonActivated_Sprite;
    [SerializeField]
    private Sprite PressurePlateActivated_Sprite;
    [SerializeField]
    private GameObject DoorToBeOpened;
    [SerializeField]
    private Player.ElementalsAvailable elementalToUnlock; 

    // Start is called before the first frame update
    void Start()
    {
        PressurePlate1_sr = gameObject.GetComponent<SpriteRenderer>();
        Door_sr = DoorToBeOpened.GetComponent<SpriteRenderer>();

        switch (elementalToUnlock)
        {
            case Player.ElementalsAvailable.HUMAN:
                PressurePlate1_sr.color = GlobalControl.ElementalsTOColorRGB[Player.ElementalsAvailable.HUMAN];
                break;
            case Player.ElementalsAvailable.GROUND:
                PressurePlate1_sr.color = GlobalControl.ElementalsTOColorRGB[Player.ElementalsAvailable.GROUND];
                break;
            case Player.ElementalsAvailable.WATER:
                PressurePlate1_sr.color = GlobalControl.ElementalsTOColorRGB[Player.ElementalsAvailable.WATER];
                break;
            case Player.ElementalsAvailable.FIRE:
                PressurePlate1_sr.color = GlobalControl.ElementalsTOColorRGB[Player.ElementalsAvailable.FIRE];
                break;
            case Player.ElementalsAvailable.ELECTRICITY:
                PressurePlate1_sr.color = GlobalControl.ElementalsTOColorRGB[Player.ElementalsAvailable.ELECTRICITY];
                break;
            case Player.ElementalsAvailable.AIR:
                PressurePlate1_sr.color = GlobalControl.ElementalsTOColorRGB[Player.ElementalsAvailable.AIR];
                break;
            default:
                break;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "Player" || obj.tag == "Player2")
        {
            Player.ElementalsAvailable playerElemental = obj.GetComponent<Player>().elementalsPossesed[obj.GetComponent<Player>().actualElementalIndex];

            if (playerElemental == elementalToUnlock)
            {
                PressurePlate1_sr.sprite = PressurePlateActivated_Sprite;

                DoorToBeOpened.GetComponent<BoxCollider2D>().enabled = false;
                Door_sr.sprite = null;
            }

        }
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.tag == "Player" || obj.tag == "Player2")
        {
            Player.ElementalsAvailable playerElemental = obj.GetComponent<Player>().elementalsPossesed[obj.GetComponent<Player>().actualElementalIndex];

            if (playerElemental == elementalToUnlock)
            {
                PressurePlate1_sr.sprite = PressurePlateActivated_Sprite;

                DoorToBeOpened.GetComponent<BoxCollider2D>().enabled = false;
                Door_sr.sprite = null;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {

        PressurePlate1_sr.sprite = PressurePlateNonActivated_Sprite;

    }
}
