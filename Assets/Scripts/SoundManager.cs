using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip coinSound;

    public void PlayCoinSound()
    {
        musicSource.PlayOneShot(coinSound);

    }
}
