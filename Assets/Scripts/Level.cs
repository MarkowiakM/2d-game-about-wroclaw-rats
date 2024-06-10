using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    public GameObject playButton;
    public int levelNr;

    public TextMeshProUGUI levelText;

    void Start()
    {
        if (GameStateManager.unlockedLevels[levelNr - 1] == 0)
        {
            playButton.GetComponent<Button>().interactable = false;
        }
        
            // Ustaw tekst na podstawie wartości levelNr
            levelText.text = GameStateManager.starsForLevels[levelNr - 1].ToString();
        
    }
}
