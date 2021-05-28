using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : MonoBehaviour
{

    private bool left = true;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());

    }


    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            animator.SetBool("Attack", true);
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("Attack", false);
        }
        
    }
}
