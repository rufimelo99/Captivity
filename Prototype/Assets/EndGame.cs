using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
