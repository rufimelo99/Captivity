using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{

    [SerializeField]
    private GameObject resume_button;
    [SerializeField]
    private bool menu; //this is cause I is slightly different in the menu and in the controls scene and i didn't wannna make 2 scripts

    // Start is called before the first frame update
    void Start()
    {
        if (menu) {

            if (GlobalControl.Instance.CompletedLevels == 0) //to destroy the resume button
            {
                Destroy(resume_button);
            }
        }
        else
        {
            if (GlobalControl.Instance.CompletedLevels >= 2) //to destroy the "you have no powers" button
            {
                Destroy(resume_button);
            }
        }

        
    }

}
