using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static int doorOpenedCount;

    public AudioSource musicSource;

    public AudioClip background;
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


    void Update()
    {
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
