using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public List<GameObject> tutorialSteps;
    private int currentStepIndex = 0;

    void Start()
    {
        for (int i = 1; i < tutorialSteps.Count; i++)
        {
            tutorialSteps[i].SetActive(false);
        }

        ShowStep(0);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void ShowNextStep()
    {
        if (currentStepIndex < tutorialSteps.Count - 1)
        {
            tutorialSteps[currentStepIndex].SetActive(false);
            currentStepIndex++;
            tutorialSteps[currentStepIndex].SetActive(true);
        }
        else
        {
            tutorialSteps[currentStepIndex].SetActive(false);
            Debug.Log("Tutorial completed.");
        }
    }

    public void ShowStep(int stepIndex)
    {
        if (stepIndex >= 0 && stepIndex < tutorialSteps.Count)
        {
            if (currentStepIndex < tutorialSteps.Count)
            {
                tutorialSteps[currentStepIndex].SetActive(false);
            }
            currentStepIndex = stepIndex;
            tutorialSteps[currentStepIndex].SetActive(true);
        }
    }
}
