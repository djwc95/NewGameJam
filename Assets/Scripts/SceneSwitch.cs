using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadStore1()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLvl1()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadStore2() 
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLvl2()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadStore3()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadLvl3()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadDeathScene()
    {
        SceneManager.LoadScene(8);
    }

    public void LoadInstructs()
    {
        SceneManager.LoadScene(9);
    }
}