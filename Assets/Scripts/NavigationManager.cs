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
        if (GameStateManager.unlockedLevels[1] == 1)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }

    public void GoToLevel3()
    {
        if (GameStateManager.unlockedLevels[2] == 1)
        {
            SceneManager.LoadSceneAsync(4);
        }
    }

    public void GoToLevel4()
    {
        if (GameStateManager.unlockedLevels[3] == 1)
        {
            SceneManager.LoadSceneAsync(5);
        }
    }

    public void GoToLevel5()
    {
        if (GameStateManager.unlockedLevels[4] == 1)
        {
            SceneManager.LoadSceneAsync(6);
        }
    }

    public void GoToLevel6()
    {
        if (GameStateManager.unlockedLevels[5] == 1)
        {
            SceneManager.LoadSceneAsync(7);
        }
    }

    public void GoToTutorial()
    {
        SceneManager.LoadSceneAsync(9);
    }

    public void LoadState()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log("loaded state: "+ data.unlockedLevelsToSave[0] + " " + data.unlockedLevelsToSave[1] + " " + data.unlockedLevelsToSave[2] + " " + data.unlockedLevelsToSave[3] + " " + data.unlockedLevelsToSave[4] + " " + data.unlockedLevelsToSave[5]);
        Debug.Log("loaded times and coins: " + data.timeAndCoinsToSave[0, 0] + " " + data.timeAndCoinsToSave[0, 1] + " " + data.timeAndCoinsToSave[1, 0] + " " + data.timeAndCoinsToSave[1, 1] + " " + data.timeAndCoinsToSave[2, 0] + " " + data.timeAndCoinsToSave[2, 1] + " " + data.timeAndCoinsToSave[3, 0] + " " + data.timeAndCoinsToSave[3, 1] + " " + data.timeAndCoinsToSave[4, 0] + " " + data.timeAndCoinsToSave[4, 1] + " " + data.timeAndCoinsToSave[5, 0] + " " + data.timeAndCoinsToSave[5, 1]);
        for (int i = 0; i < data.unlockedLevelsToSave.Length; i++)
        {
            if (data.unlockedLevelsToSave[i] == 1)
            {
                GameStateManager.UnlockLevel(i+2);
            }
        }
        GameStateManager.SetLevelRatings(data.timeAndCoinsToSave);
    }
}
