using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magma : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destoryAfterAFewSecond(10f));
    }

    IEnumerator destoryAfterAFewSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GenocideBaby();
    }


    public void GenocideBaby()
    {
        Destroy(gameObject);
    }
}
