using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningButton : MonoBehaviour
{

    private Animator buttonAnimation;
    public bool isPressed;
    void Start()
    {
        buttonAnimation = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ruby") || other.gameObject.CompareTag("Rufus"))
        {
            buttonAnimation.SetBool("isPressed", true);
            isPressed = true;
        } 
        // else
        // {
        //    buttonAnimation.SetBool("isPressed", false);
        //    isPressed = false;
        //}
        

    }

}
