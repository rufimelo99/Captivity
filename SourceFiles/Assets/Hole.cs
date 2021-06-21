using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public BoxCollider2D rb;

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Comb Tree")
        {
            StartCoroutine(disableColliderLikeYesImABigTitleDealWithIt());
        }
    }


    IEnumerator disableColliderLikeYesImABigTitleDealWithIt()
    {
        WaitForSeconds pause = new WaitForSeconds(10f);
        rb.enabled = false;
        yield return pause;
        rb.enabled = true;

    }
}
