using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverColliderManager : MonoBehaviour
{

    public BoxCollider2D collider;

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            collider.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            collider.enabled = false;
        }
    }
}
