using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagesCollected : MonoBehaviour
{
    public GlobalControl globalControl;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<globalControl.pagesCollected.Length; i++)
        {
            if (!globalControl.pagesCollected[i])
            {
                gameObject.GetComponent<Book>().bookPages[i] = gameObject.GetComponent<Book>().background;
            }
        }        
    }
    private void Update()
    {
        for (int i = 0; i < globalControl.pagesCollected.Length; i++)
        {
            if (!globalControl.pagesCollected[i])
            {
                gameObject.GetComponent<Book>().bookPages[i] = gameObject.GetComponent<Book>().background;
            }
        }
    }
}
