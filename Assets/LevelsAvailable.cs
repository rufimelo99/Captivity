using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsAvailable : MonoBehaviour
{

    public int CompletedLevels;
    public GameObject level2;
    public GameObject level3;
    //public GameObject level4;
    public GameObject level5;
    public GameObject level6;
    public GameObject level7;
    //public GameObject level8;
    public GameObject level9;
    //public GameObject level10;
    public GameObject level11;
    public GameObject level12;

    private List<GameObject> levels = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        getLevels();
        CompletedLevels = GlobalControl.Instance.CompletedLevels;
        for (int i = 7; i >= CompletedLevels; i--)
        {
            Destroy(levels[i]);
        }
    }

    void getLevels()
    {
        levels.Add(level2);
        levels.Add(level3);
        //levels.Add(level4);
        levels.Add(level5);
        levels.Add(level6);
        levels.Add(level7);
        //levels.Add(level8);
        levels.Add(level9);
        //levels.Add(level10);
        levels.Add(level11);
        levels.Add(level12);
    }

    // Update is called once per frame
    /*void Update()
    {
        if (CompletedLevels == 0)
        {
            Destroy(level2);
        }
    }*/
}
