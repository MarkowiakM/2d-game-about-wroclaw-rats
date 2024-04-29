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
    public TextMeshProUGUI timeText;

    public void Setup(int rubyCoins, int rufusCoins, float time)
    {
        gameObject.SetActive(true);
        rubyCoinsText.text = rubyCoins.ToString();
        rufusCoinsText.text = rufusCoins.ToString();
        totalCointsText.text = (rubyCoins + rufusCoins).ToString() + " / 10";
        timeText.text = FormatTime(120f - time);
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
