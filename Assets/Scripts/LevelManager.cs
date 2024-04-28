using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int rufusCoins;
    public int rubyCoins;
    public bool isRubyDead;
    public bool isRufusDead;
    public bool rubyDoorOpened;
    public bool rufusDoorOpened;
    private bool isLevelCompleted;
    private bool isLevelOver;
    public float timeElapsed;

    public LevelCompletedScreen LevelCompletedScreen;
    public LevelOverScreen LevelOverScreen;
    public int currentSceneIndex;

    private GameStateManager gameStateManager;


    void Start()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        currentSceneIndex = currentScene.buildIndex;
    }

    void Update()
    {
        if(isRubyDead || isRufusDead)
        {
            if(!isLevelOver)
            {
                isLevelOver = true;
                StartCoroutine(DelayedLevelOver(1.5f));
            }

        }
        else if(rubyDoorOpened && rufusDoorOpened && !isLevelCompleted)
        {
            isLevelCompleted = true;
            Scene currentScene = SceneManager.GetActiveScene();
            currentSceneIndex = currentScene.buildIndex;
            // if level1 is completed then it passes index 2 etc.
            if (currentSceneIndex != 7) 
            {
                GameStateManager.UnlockLevel(currentSceneIndex+1);
            }
            SavePlayer();
            StartCoroutine(DelayedLevelCompleted(1.5f));
        }
        timeElapsed += Time.deltaTime;
    }

    private IEnumerator DelayedLevelCompleted(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelCompleted();
    }

    private void LevelCompleted()
    {
        LevelCompletedScreen.Setup(rubyCoins, rufusCoins, timeElapsed);
    }

    private IEnumerator DelayedLevelOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelOver();
    }

    private void LevelOver()
    {
        LevelOverScreen.Setup();
    }

    private void SavePlayer()
    {
        SaveSystem.SavePlayer(this, GameStateManager.GetUnlockedLevels());
    }
}
