using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPlatformEvent : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    public void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void TriggerEvent()
    {
        boxCollider.enabled = false;
    }
}