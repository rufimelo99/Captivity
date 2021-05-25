using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPiecesTrigger : MonoBehaviour
{
    public int pageId = -1;
    public GlobalControl globalControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        DisplayDialogue displayDialogue = gameObject.GetComponent<DisplayDialogue>();
        if (displayDialogue)
        {
            displayDialogue.displayDialogue();
        }
        Destroy(gameObject);
        if (pageId != -1 && globalControl!=null)
        {
            globalControl.pagesCollected[pageId] = true;

        }
    }
}
