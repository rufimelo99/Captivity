using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{

    [SerializeField]
    private GameObject resume_button;

    // Start is called before the first frame update
    void Start()
    {

        if (GlobalControl.Instance.CompletedLevels == 0) { 
            Destroy(resume_button);
        }
    }

}
