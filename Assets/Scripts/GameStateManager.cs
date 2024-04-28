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
    public static int[] unlockedLevels;
    public static GameStateManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            unlockedLevels = new int[]{1, 0, 0, 0, 0, 0};
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
}
