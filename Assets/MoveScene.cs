using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveScene : MonoBehaviour
{

    public void goMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void goControls()
    {
        SceneManager.LoadScene(2);
    }

    public void goGame()
    {
        SceneManager.LoadScene(2);
    }

    public void goInstructions()
    {
        SceneManager.LoadScene(3);
    }

}
