using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : MonoBehaviour
{

    private bool left = true;
    private float health = 10f;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("Health", health);
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


    private void OnTriggerEnter2D(Collider2D col)
    {
        //river - TODO - make this good
        if (col.tag == "Bullet")
        {
            health = health - 1f;
            animator.SetFloat("Health", health);
        }
    }
}
