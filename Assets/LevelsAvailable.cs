using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsAvailable : MonoBehaviour
{

    public int CompletedLevels;
    public GameObject level2;

    // Start is called before the first frame update
    void Start()
    {
        CompletedLevels = GlobalControl.Instance.CompletedLevels;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompletedLevels == 0)
        {
            Destroy(level2);
        }
    }
}
