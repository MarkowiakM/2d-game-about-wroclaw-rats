using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentSceneIndex;
    public int[] unlockedLevelsToSave;
    public float[,] timeAndCoinsToSave;

    public PlayerData(LevelManager levelManager, int[] unlockedLevels, float[,] timeAndCoins)
    {
        currentSceneIndex = levelManager.currentSceneIndex;
        unlockedLevelsToSave = unlockedLevels;
        timeAndCoinsToSave = timeAndCoins;
    }
}
