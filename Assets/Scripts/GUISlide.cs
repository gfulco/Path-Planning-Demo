using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class GUISlide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject menu = GameObject.Find("MenuButton");
        menubutton mbutt = (menubutton)menu.GetComponent(typeof(menubutton));

        if (GUI.Button(new Rect(30, 70, 300, 20), "Main Menu"))
        {
            mbutt.NextScene();
        }
    }
}
