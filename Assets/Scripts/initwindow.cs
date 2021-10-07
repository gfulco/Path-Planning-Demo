using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initwindow : MonoBehaviour

{

    private Rect rctWindow,rctWindow1;
    int Info=0;
    // Start is called before the first frame update
    void Start()
    {
        rctWindow = new Rect(Screen.width - Screen.width / 3.75f - 20, 20, Screen.width / 3.75f, Screen.height / 3.0f);
        rctWindow1 = new Rect(10, Screen.height-Screen.height/2.8f -20, Screen.width / 3.75f, Screen.height / 2.8f);
    }

    // Update is called once per frame
    void OnGUI()
    {
        
        if(GUISKIN.togglewindow ==1)
            rctWindow = GUI.Window(2, rctWindow, DoPlayWindow, "Play Mode");
        if(Info==1)
            rctWindow1 = GUI.Window(0, rctWindow1, DoInfoWindow, "Info");
    }

    void DoPlayWindow(int windowID)
    {
        GUILayout.BeginVertical();
       
        GUILayout.Label("Insert initial and final position");
        //init Cond.
        GUISKIN.x_in = GUI.TextField(new Rect(10, 50, rctWindow.width/4, rctWindow.height/8), GUISKIN.x_in,2);
        GUISKIN.y_in = GUI.TextField(new Rect(10, rctWindow.height / 8+65, rctWindow.width / 4 , rctWindow.height / 8), GUISKIN.y_in,2);
        GUISKIN.theta_in = GUI.TextField(new Rect(10, rctWindow.height / 4+80, rctWindow.width / 4, rctWindow.height / 8), GUISKIN.theta_in);
        GUISKIN.delta_in = GUI.TextField(new Rect(10, rctWindow.height - rctWindow.height / 8-10, rctWindow.width / 4, rctWindow.height / 8), GUISKIN.delta_in);
        GUI.Label(new Rect(rctWindow.width / 4 + 20, 50, rctWindow.width / 4, rctWindow.height / 8),"x initial");
        GUI.Label(new Rect(rctWindow.width / 4 + 20, rctWindow.height / 8 + 65, rctWindow.width / 4 , rctWindow.height / 8),"y initial");
        GUI.Label(new Rect(rctWindow.width / 4 + 20, rctWindow.height / 4 + 80, rctWindow.width / 4 , rctWindow.height / 6.5f),"theta initial");
        GUI.Label(new Rect(rctWindow.width / 4 + 20, rctWindow.height- rctWindow.height / 8 -10, rctWindow.width / 4, rctWindow.height / 6.5f),"delta initial");
        //final condition
        if (GUI.Button(new Rect(rctWindow.width / 2, 50, rctWindow.width / 4, rctWindow.height / 8), "Info"))
        {
            if (Info == 1)
                Info = 0;
            else
                Info = 1;
        }
        GUISKIN.y_fin = GUI.TextField(new Rect(rctWindow.width / 2 , rctWindow.height / 8 + 65, rctWindow.width / 4, rctWindow.height / 8), GUISKIN.y_fin,2);
        GUISKIN.theta_fin = GUI.TextField(new Rect(rctWindow.width / 2 , rctWindow.height / 4 + 80, rctWindow.width / 4, rctWindow.height / 8), GUISKIN.theta_fin);
        GUISKIN.delta_fin = GUI.TextField(new Rect(rctWindow.width / 2 , rctWindow.height - rctWindow.height / 8 - 10, rctWindow.width / 4, rctWindow.height / 8), GUISKIN.delta_fin);
        GUI.Label(new Rect(rctWindow.width -rctWindow.width / 4+10 , rctWindow.height / 8 + 65, rctWindow.width / 4, rctWindow.height / 8), "y final");
        GUI.Label(new Rect(rctWindow.width -rctWindow.width / 4+10 , rctWindow.height / 4 + 80, rctWindow.width / 4, rctWindow.height / 6.5f), "theta final");
        GUI.Label(new Rect(rctWindow.width -rctWindow.width / 4+10 , rctWindow.height - rctWindow.height / 8 - 10, rctWindow.width / 4, rctWindow.height / 6.5f), "delta final");

        GUILayout.EndVertical();
    }

    void DoInfoWindow(int windowID)
    {
        GUILayout.Label("You can choose initial and final position of the vehicle as explained in the theory lesson.");
        GUILayout.Label("All the measurement units are in [m] meters for x and y and [rad] radians for theta and delta.");
        GUILayout.Label("There's a single constraints given by the integration period which is fixed at 50 m.");
        GUILayout.Label("So once you choose x initial, the position for x final is self assigned to x_i+50.");
        GUILayout.Label("Otherwise Equation of motion of the car-like model would be too large to be processed.");
    }


    }
