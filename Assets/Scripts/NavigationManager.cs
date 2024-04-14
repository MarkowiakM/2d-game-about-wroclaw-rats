using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public void GoToLevelsMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GoToLevel1()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void GoToLevel2()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void GoToLevel3()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void GoToLevel4()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void GoToLevel5()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void GoToLevel6()
    {
        SceneManager.LoadSceneAsync(7);
    }
}
