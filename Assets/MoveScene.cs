using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveScene : MonoBehaviour
{

    private void go(int n)
    {
        SceneManager.LoadScene(n-1); // ok i know this is stupid but i made a mistake and didn't want to put it all back
    }

    public void goMenu()
    {
        go(1);
    }

    public void goControls()
    {
        go(2);
    }

    public void goInstructions()
    {
        go(3);
    }

    public void goMap()
    {
        go(4);
    }

    public void goWater1()
    {
        go(5);
    }

    public void goWater2()
    {
        go(6);
    }

    public void goEarth1()
    {
        go(7);
    }

    public void goEarth2()
    {
        go(8);
    }

    public void goFire1()
    {
        go(9);
    }

    public void goFire2()
    {
        go(10);
    }

    public void goAir1()
    {
        go(11);
    }

    public void goAir2()
    {
        go(12);
    }

    public void goElec1()
    {
        go(13);
    }

    public void goElec2()
    {
        go(14);
    }

    public void goWizard1()
    {
        go(15);
    }

    public void goWizard2()
    {
        go(16);
    }
    public void goDiary()
    {
        go(17);
    }

    public void restart()
    {
        Destroy(GlobalControl.Instance);
        goMap();
    }

    public void Quit()
    {
        Application.Quit();
    }

}
