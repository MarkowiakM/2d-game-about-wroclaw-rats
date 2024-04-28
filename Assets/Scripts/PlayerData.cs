using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentSceneIndex;
    public int[] unlockedLevelsToSave;

    public PlayerData(LevelManager levelManager, int[] unlockedLevels)
    {
        currentSceneIndex = levelManager.currentSceneIndex;
        unlockedLevelsToSave = unlockedLevels;
    }
}
