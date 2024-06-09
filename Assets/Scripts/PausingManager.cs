using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausingManager : MonoBehaviour
{

    private GameStateManager gameStateManager;
    private static int isGameOn = 1;
    private static int isMusicOn = 1;
    public GameObject pauseButton;
    public GameObject playButton;
    public GoToMenuPopup goToMenuPopup;

    public void Start()
    {
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    public void StopResumeGame()
    {
        Debug.Log("is game on: " + (isGameOn == 1).ToString());
        GameStateManager.StopResumeGame(isGameOn);
        pauseButton.SetActive(isGameOn == 0);
        playButton.SetActive(isGameOn == 1);
        isGameOn = 1 - isGameOn;
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

    public void OpenMenuPopup()
    {
        Time.timeScale = 0f;
        goToMenuPopup.Open();
    }

    public void CloseMenuPopup()
    {
        Time.timeScale = 1f;
        goToMenuPopup.Close();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
