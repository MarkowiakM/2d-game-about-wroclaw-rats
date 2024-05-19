using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public GameObject playButton;
    public int levelNr;

    void Start()
    {
        if (GameStateManager.unlockedLevels[levelNr - 1] == 0)
        {
            playButton.GetComponent<Button>().interactable = false;
        }
        
    }
}
