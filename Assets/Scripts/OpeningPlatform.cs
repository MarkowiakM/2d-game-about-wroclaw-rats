using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningPlatform : MonoBehaviour
{

    private Animator platformAnimation;
    public OpeningButton button;

    void Start()
    {
        platformAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        platformAnimation.SetBool("isOpen", button.isPressed);
    }
}