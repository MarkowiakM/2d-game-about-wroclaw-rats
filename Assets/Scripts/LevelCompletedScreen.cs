using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCompletedScreen : MonoBehaviour
{
    public TextMeshProUGUI rubyCoinsText;
    public TextMeshProUGUI rufusCoinsText;
    public TextMeshProUGUI totalCointsText;

    public void Setup(int rubyCoins, int rufusCoins)
    {
        gameObject.SetActive(true);
        rubyCoinsText.text = rubyCoins.ToString();
        rufusCoinsText.text = rufusCoins.ToString();
        totalCointsText.text = (rubyCoins + rufusCoins).ToString() + " / 10";
        Time.timeScale = 0f;
    }
}
