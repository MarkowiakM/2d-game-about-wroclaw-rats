using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public Instructions instructions;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rufus") || other.gameObject.CompareTag("Ruby"))
        {
            gameObject.SetActive(false);
            instructions.ShowNextStep();
        }
    }
}
