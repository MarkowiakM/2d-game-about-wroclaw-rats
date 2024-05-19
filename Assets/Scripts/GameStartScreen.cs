using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameStartScreen : MonoBehaviour
{

    public List<GameObject> texts;
    private int currentStepIndex = 0;

    public SideMenu sideMenu;
    public LevelManager lm;

    void Start()
    {
        for (int i = 1; i < texts.Count; i++)
        {
            texts[i].SetActive(false);
        }
        sideMenu.Close();
        texts[0].SetActive(true);
    }

    private void Close()
    {
        lm.timeLeft = 120f;
        sideMenu.Open();
        gameObject.SetActive(false);
    }


    public void Continue()
    {
        if (currentStepIndex < texts.Count - 1)
        {
            texts[currentStepIndex].SetActive(false);
            currentStepIndex++;
            texts[currentStepIndex].SetActive(true);
        }
        else
        {
            texts[currentStepIndex].SetActive(false);
            Close();
        }
    }
}
