using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDoor : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator.SetBool("isEnemyDead", false);
    }

}
