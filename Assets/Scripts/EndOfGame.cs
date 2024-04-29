using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public LevelCompletedScreen levelCompletedScreen;
    public SideMenu sideMenu;

    public void GameCompleted()
    {
        gameOverScreen.Setup();
        levelCompletedScreen.Close();
        sideMenu.Close();
    }
}
