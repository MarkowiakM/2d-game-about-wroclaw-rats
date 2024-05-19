using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorialStartScreen : MonoBehaviour
{

    public SideMenu sideMenu;
    public Instructions instructions;
    public LevelManager lm;

    void Start()
    {
       sideMenu.Close();
        instructions.Close();
  
    }

    public void Close()
    {
        lm.timeLeft = 120f;
        sideMenu.Open();
        instructions.Open();
        gameObject.SetActive(false);
    }

}
