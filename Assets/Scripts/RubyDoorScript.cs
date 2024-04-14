using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private Animator doorAnimation;

    void Start()
    {
        doorAnimation = GetComponent<Animator>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ruby"))
        {
            doorAnimation.SetBool("isTouching", true);
            GameStateManager.doorOpenedCount += 1;
        }
    }
}
