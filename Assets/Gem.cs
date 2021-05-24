using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{


    //[SerializeField] private int color;
    [SerializeField] private Image image;

    private bool player1 = false;
    private bool player2 = false;

    public GlobalControl.GemsAvailable gemType;

    public void notFoundShowInMenu()
    {
        image.color = Color.black;
    }

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        assignColor();

        if (GlobalControl.Instance.gemsCollected.Contains(gemType) && SceneManager.GetActiveScene().buildIndex != 3)
        {
            gameObject.SetActive(false); //Destroy(gameObject);
        }

        if (GlobalControl.Instance.gemsCollected.Contains(gemType) && SceneManager.GetActiveScene().buildIndex == 3)
        {
            gameObject.SetActive(true);
        }
    }

    void assignColor()
    {
        int color = 0;
        switch (gemType)
        {
            case GlobalControl.GemsAvailable.WATER:
                color = 0;  //blue color
                break;
            case GlobalControl.GemsAvailable.GROUND:
                color = 1;  //blue color
                break;
            case GlobalControl.GemsAvailable.FIRE:
                color = 2;  //blue color
                break;
            case GlobalControl.GemsAvailable.AIR:
                color = 3;  //blue color
                break;
            case GlobalControl.GemsAvailable.ELECTRICITY:
                color = 4;  //blue color
                break;
            case GlobalControl.GemsAvailable.WIZARD:
                color = 5;  //blue color
                break;
        }
        animator.SetInteger("Color", color);
    }

    void Update()
    {
        if(player1 && player2)
        {
            GlobalControl.Instance.addGemWithoutRepetition(gemType);
            gameObject.SetActive(false);

            DisplayDialogue displayDialogue = gameObject.GetComponent<DisplayDialogue>();
            if (displayDialogue)
            {
                displayDialogue.displayDialogue();
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player1 = true;

        }
        if(col.gameObject.tag == "Player2")
        {
            player2 = true;//
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player1 = false;

        }
        if (col.gameObject.tag == "Player2")
        {
            player2 = false;//
        }
    }
}
