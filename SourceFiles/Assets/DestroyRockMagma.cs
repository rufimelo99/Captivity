using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRockMagma : MonoBehaviour
{   

    [SerializeField] private Animator animate;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Magma")
        {
            animate.SetBool("destroy", true);
            StartCoroutine(GenocideMagma());
        }
        
    }


    IEnumerator GenocideMagma()
    {
        WaitForSeconds pause = new WaitForSeconds(1.5f);

        yield return pause;
        Destroy(gameObject);
    }

}
