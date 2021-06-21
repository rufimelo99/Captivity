using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPiecesTrigger : MonoBehaviour
{
    public int pageId = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
                DisplayDialogue displayDialogue = gameObject.GetComponent<DisplayDialogue>();
            if (displayDialogue)
            {
                displayDialogue.displayDialogue();
            }
            Destroy(gameObject);
            if (pageId != -1 )
            {
                GlobalControl.Instance.pagesCollected[pageId] = true;
                //Debug.Log("adding to diary");
            }
        }
    }
}
