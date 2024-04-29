using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingManager : MonoBehaviour
{

    private GameStateManager gameStateManager;
    private static int isGameOn = 1;
    private static int isMusicOn = 1;

    public void StopResumeGame() {
        if (isGameOn == 1)
        {
            GameStateManager.StopResumeGame(0);
            isGameOn = 0;
        } else
        {
            GameStateManager.StopResumeGame(1);
            isGameOn = 1;
        }
    }

    public void StopResumeMusic() {
        if (isMusicOn == 1)
        {
            GameStateManager.PlayPasueMusic(0);
            isMusicOn = 0;
        } else
        {
            GameStateManager.PlayPasueMusic(1);
            isMusicOn = 1;
        }
    }
}
