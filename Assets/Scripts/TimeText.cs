using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public LevelManager lm;

 

    void Update()
    {
        if(lm.timeLeft >= 0)
        {
            timeText.text = FormatTime(lm.timeLeft);
        }

    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
