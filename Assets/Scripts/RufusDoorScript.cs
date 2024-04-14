using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RufusDoorScript : MonoBehaviour
{

    private Animator doorAnimation;
    public LevelManager lm;

    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rufus"))
        {
            doorAnimation.SetBool("isTouching", true);
            GameStateManager.doorOpenedCount += 1;
            lm.rufusDoorOpened = true;
        }
    }
}
