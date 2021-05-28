using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRockMagma : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Magma")
        {
            StartCoroutine(GenocideMagma());
        }
    }


    IEnumerator GenocideMagma()
    {
        WaitForSeconds pause = new WaitForSeconds(1f);

        yield return pause;
        Destroy(gameObject);
    }

}
