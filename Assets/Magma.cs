using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(freeze());
    }

    IEnumerator freeze()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
