using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDialogue : MonoBehaviour
{

    public GameObject DialogueToDisplay;

    public void displayDialogue()
    {
        Instantiate(DialogueToDisplay);
    }
}
