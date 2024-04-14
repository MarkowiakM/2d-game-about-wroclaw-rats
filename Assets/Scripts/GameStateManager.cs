using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static int doorOpenedCount;

    public AudioSource musicSource;

    public AudioClip background;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


    void Update()
    {
        
    }
}
