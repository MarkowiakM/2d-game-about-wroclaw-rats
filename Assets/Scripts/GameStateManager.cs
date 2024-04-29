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
        } else
        {
            
        }
    }

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
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
}
