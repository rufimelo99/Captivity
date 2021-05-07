using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseElemental : MonoBehaviour
{
    public bool DEBUG = false;
    private Player player;


    private Animator animator;
    [SerializeField]
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        
        animator = player.GetComponent<Player>().animator;
    }
    private void Update()
    {
        ChangeElemental();
    }

    void ChangeElemental()
    {
        
        if (Input.GetKeyDown(player.selectPreviousElemental))
        {
            if(DEBUG) Debug.Log("Changing to previous elemental"); 
            if (player.elementalsPossesed.Count == 1)
            {
                //do nothing cause that player only has 1 elemental available
            }
            else
            {
                if (player.actualElementalIndex == 0)
                {
                    player.actualElementalIndex = player.elementalsPossesed.Count - 1;
                }
                else
                {
                    player.actualElementalIndex -= 1;
                }

                if (DEBUG)
                {
                    Debug.Log("ActualElementalIndex" + player.actualElementalIndex);
                    Debug.Log("ActualElemental" + player.elementalsPossesed[player.actualElementalIndex]);

                }
            }

            changeColor();
        }
        if (Input.GetKeyDown(player.selectNextElemental))
        {
            if (DEBUG) Debug.Log("Changing to next elemental");
            if (player.elementalsPossesed.Count == 1)
            {
                //do nothing cause that player only has 1 elemental available
            }
            else
            {
                if (player.actualElementalIndex == player.elementalsPossesed.Count - 1)
                {
                    player.actualElementalIndex = 0;
                }
                else
                {
                    player.actualElementalIndex += 1;
                }
            }
            if (DEBUG)
            {
                Debug.Log("ActualElementalIndex" + player.actualElementalIndex);
                Debug.Log("ActualElemental" + player.elementalsPossesed[player.actualElementalIndex]);

            }
            changeColor();
        }

    }


    void changeColor()
    {
        if (!player.isCharging)
        {
           
            //animator.SetInteger(player.PlayerColor, player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]]);
            sr.color = player.ElementalsTOColorRGB[player.elementalsPossesed[player.actualElementalIndex]];
            if (DEBUG) Debug.Log("Shoud be color: " + player.ElementalsTOColor[player.elementalsPossesed[player.actualElementalIndex]]);
        }


    }
    
}
