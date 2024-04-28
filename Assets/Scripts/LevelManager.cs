using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float timeLeft = 120f;

    public LevelCompletedScreen LevelCompletedScreen;
    public LevelOverScreen LevelOverScreen;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(isRubyDead || isRufusDead || timeLeft <= 0)
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
            StartCoroutine(DelayedLevelCompleted(1.5f));
        } else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    private IEnumerator DelayedLevelCompleted(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelCompleted();
    }

    private void LevelCompleted()
    {
        LevelCompletedScreen.Setup(rubyCoins, rufusCoins, timeLeft);
        Time.timeScale = 0f;
    }

    private IEnumerator DelayedLevelOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelOver();
    }

    private void LevelOver()
    {
        LevelOverScreen.Setup();
        Time.timeScale = 0f;
    }

}
