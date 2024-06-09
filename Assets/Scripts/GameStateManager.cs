using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static int doorOpenedCount;

    public AudioSource musicSource;
    public AudioSource effectAudioSource;

    public AudioClip background;
    public AudioClip cheeseBite;
    public AudioClip gameOver;
    public static int[] unlockedLevels;
    public static float[,] timeAndCoinsForLevels;

    public static int[] starsForLevels;
    public static GameStateManager instance;

    private static int isGameOn = 1;
    private static int isMusicOn = 1;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            unlockedLevels = new int[]{1, 1, 1, 1, 1, 1};
            timeAndCoinsForLevels = new float[,]{{120f, 0}, {120f, 0}, {120f, 0}, {120f, 0}, {120f, 0}, {120f, 0}};
            starsForLevels = new int[]{0, 0, 0, 0, 0, 0};
            musicSource.clip = background;
            musicSource.Play();
        } else
        {
            
        }
    }

    void Start()
    {
        
    }


    public static void PlaySFX(string audioEffectName)
    {
        if (audioEffectName == "cheeseBite")
        {
            instance.effectAudioSource.PlayOneShot(instance.cheeseBite);
        } else if (audioEffectName == "gameOver")
        {
            instance.effectAudioSource.PlayOneShot(instance.gameOver);
        }
    }

    public static int[] GetUnlockedLevels()
    {
        return unlockedLevels;
    }

    public static void UnlockLevel(int levelIndex)
    {
        // level 1 is at index 0
        unlockedLevels[levelIndex-2] = 1;
    }

    public static void SetLevelRatings(float[,] timeAndCoins)
    {
        timeAndCoinsForLevels = timeAndCoins;
        for (int i = 0; i < timeAndCoins.GetLength(0); i++)
        {
            starsForLevels[i] = GetStarsForLevel(timeAndCoins[i, 0], (int)timeAndCoins[i, 1]);
            Debug.Log("Level " + i + " stars: " + starsForLevels[i]);
        }
    }

    public static float[,] GetTimeAndCoins()
    {
        return timeAndCoinsForLevels;
    }

    public static void StopResumeGame(int isGameOn) {
        if (isGameOn == 1)
        {
            Time.timeScale = 0f;
            isGameOn = 0;
        } else
        {
            Time.timeScale = 1f;
            isGameOn = 1;
        }
    }

    public static void PlayPasueMusic(int isMusicOn)
    {
        if (isMusicOn == 0)
        {
            instance.musicSource.Pause();
            instance.effectAudioSource.mute = true;
        } else
        {
            instance.musicSource.Play();
            instance.effectAudioSource.mute = false;
        }
    }

    private static int GetStarsForLevel(float timeForLevel, int collectedCheeses)
    {
        int timeStars = 1;
        if (timeForLevel < 40)
        {
            timeStars = 3;
        }
        else if (timeForLevel < 80)
        {
            timeStars = 2;
        }

        int cheeseStars = 1;
        if (collectedCheeses >= 8)
        {
            cheeseStars = 3;
        }
        else if (collectedCheeses >= 4)
        {
            cheeseStars = 2;
        }

        int totalStars = timeStars + cheeseStars;

        // Mapowanie na 1-3 gwiazdek
        if (totalStars <= 3)
        {
            return 1;
        }
        else if (totalStars == 4)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}
