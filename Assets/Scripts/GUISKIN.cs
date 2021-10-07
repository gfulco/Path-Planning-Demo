
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GUISKIN : MonoBehaviour
{
    private Rect rctWindow1,rctWindow2,rctWindow3;
    GameObject DemoCam,MenuCam;
    public static int togglewindow = 0;
    public static int  mainmenuon = 1;
    public static int input=0;
    public static string x_in = "";
    public static string y_in = "";
    public static string x_fin = "";
    public static string y_fin = "";
    public static string theta_in = "";
    public static string theta_fin = "";
    public static string delta_in = "";
    public static string delta_fin = "";

    double x_i, y_i,theta_i,delta_i;
    void Start()
    {
        rctWindow1 = new Rect(20, 20, Screen.width /4 +20, Screen.height / 3.5f);
        rctWindow2 = new Rect(Screen.width - Screen.width / 3.75f-20, Screen.height - Screen.height / 5.0f-20, Screen.width / 3.75f, Screen.height / 5.0f);
        rctWindow3 = new Rect(0, Screen.height - 140, Screen.width / 4.0f, Screen.height / 5.0f);
    }
    void OnGUI()
    {
       
      
        GameObject theory = GameObject.Find("TheoryButton");
        theorybutton tbutt = (theorybutton)theory.GetComponent(typeof(theorybutton));
        GameObject code = GameObject.Find("CodeButton");
        codebutton cbutt = (codebutton)code.GetComponent(typeof(codebutton));
        GameObject cone1 = GameObject.Find("Cone");
        GameObject cone2 = GameObject.Find("Cone (1)");
        GameObject cone3 = GameObject.Find("Cone (2)");
        GameObject cone4 = GameObject.Find("Cone (3)");
        GameObject cone5 = GameObject.Find("Cone (4)");
        GameObject cone6 = GameObject.Find("Cone (5)");
        GameObject cone7 = GameObject.Find("Cone (6)");
        GameObject cone8 = GameObject.Find("Cone (7)");


        DemoCam = GameObject.Find("DemoCamera");
        MenuCam = GameObject.Find("MenuCamera");
        var cam1 = MenuCam.GetComponent<Camera>();
        var cam2 = DemoCam.GetComponent<Camera>();

        if (mainmenuon == 1)
        {
            rctWindow1 = GUI.Window(0, rctWindow1, DoMyWindow, "Point to Point Trajectory");
           
        }


        if (togglewindow == 1)
        {

            rctWindow2 = GUI.Window(1, rctWindow2, DoSettingsWindow, "Play Mode");
       
    
            if (GUI.Button(new Rect(Screen.width / 2.8f, Screen.height / 1.2f, Screen.width / 4, Screen.height / 20), "PLAY"))
            {
                mainmenuon = 0;
                togglewindow = 0;
                Movement.demo = 2;


                Double.TryParse(GUISKIN.x_in, out x_i);
                Double.TryParse(GUISKIN.y_in, out y_i);
                Movement.x_f = x_i + 50.0;
                Double.TryParse(GUISKIN.theta_in, out theta_i);
                Double.TryParse(GUISKIN.delta_in, out delta_i);
                Double.TryParse(GUISKIN.x_in, out Movement.x_i);
                Double.TryParse(GUISKIN.y_in, out Movement.y_i);
                //Double.TryParse(GUISKIN.x_fin, out Movement.x_f);
                Double.TryParse(GUISKIN.y_fin, out Movement.y_f);
                Double.TryParse(GUISKIN.theta_in, out Movement.theta_i);
                Double.TryParse(GUISKIN.delta_in, out Movement.delta_i);
                Double.TryParse(GUISKIN.theta_fin, out Movement.theta_f);
                Double.TryParse(GUISKIN.delta_fin, out Movement.delta_f);
                Debug.Log("theta" + Movement.theta_i.ToString());

                cone7.transform.SetPositionAndRotation(new Vector3((float)x_i+(float)Movement.x_f,0,(float)y_i+(float)Movement.y_f+3),new Quaternion(0,0,0,0));
                cone8.transform.SetPositionAndRotation(new Vector3((float)x_i+(float)Movement.x_f, 0,(float)y_i+(float)Movement.y_f-3), new Quaternion(0, 0, 0, 0));

                cone7.GetComponent<MeshRenderer>().enabled = true;
                cone8.GetComponent<MeshRenderer>().enabled = true;

                Vector3 posfwl, posfwr, posrw, possw, poscar;
                poscar = new Vector3((float)x_i, 0.0f, (float)y_i);
                Movement.Shelby.transform.SetPositionAndRotation(poscar, Quaternion.Euler(0, (float)theta_i, 0));

                posrw = new Vector3(Movement.rear.transform.position.x, Movement.rear.transform.position.y, Movement.rear.transform.position.z);
                Movement.rear.transform.SetPositionAndRotation(posrw, Quaternion.Euler(0, (float)theta_i, 0));
                posfwr = new Vector3(Movement.fwr.transform.position.x, Movement.fwr.transform.position.y, Movement.fwr.transform.position.z);
                posfwl = new Vector3(Movement.fwl.transform.position.x, Movement.fwl.transform.position.y, Movement.fwl.transform.position.z);

                Movement.fwr.transform.SetPositionAndRotation(posfwr, Quaternion.Euler(0, (float)theta_i + (float)delta_i, 0));
                Movement.fwl.transform.SetPositionAndRotation(posfwl, Quaternion.Euler(0, (float)theta_i + (float)delta_i, 0));
                possw = new Vector3(Movement.sw.transform.position.x, Movement.sw.transform.position.y, Movement.sw.transform.position.z);
                Movement.sw.transform.SetPositionAndRotation(possw, Quaternion.Euler(10 * (float)delta_i, (float)theta_i, 0));
                Movement.rear.GetComponent<TrailRenderer>().enabled = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2.8f, Screen.height / 1.2f+Screen.height/20, Screen.width / 4, Screen.height / 20), "EXIT"))
            {
                mainmenuon = 1;
                SceneManager.LoadScene("MainScene");
                Movement.demo = 0;
                togglewindow = 0;
            }
        }

    }
  

    void DoMyWindow(int windowID)
    {
        GameObject theory = GameObject.Find("TheoryButton");
        theorybutton tbutt = (theorybutton)theory.GetComponent(typeof(theorybutton));
        GameObject code = GameObject.Find("CodeButton");
        codebutton cbutt = (codebutton)code.GetComponent(typeof(codebutton));
        GameObject cone1 = GameObject.Find("Cone");
        GameObject cone2 = GameObject.Find("Cone (1)");
        GameObject cone3 = GameObject.Find("Cone (2)");
        GameObject cone4 = GameObject.Find("Cone (3)");
        GameObject cone5 = GameObject.Find("Cone (4)");
        GameObject cone6 = GameObject.Find("Cone (5)");
        GameObject cone7 = GameObject.Find("Cone (6)");
        GameObject cone8 = GameObject.Find("Cone (7)");

        GUILayout.BeginVertical();
        GUILayout.Label("Welcome to our Lesson on p2p trajectory");
        if (GUI.Button(new Rect(10, 50, rctWindow1.width -20, rctWindow1.height/8), "Theory"))
        {
            tbutt.NextScene();
        }
        if (GUI.Button(new Rect(10, rctWindow1.height /8 +60, rctWindow1.width - 20, rctWindow1.height/8), "Code"))
        {
            cbutt.NextScene();
        }
        if (GUI.Button(new Rect(10, rctWindow1.height / 4 + 70, rctWindow1.width - 20, rctWindow1.height/8), "Demo"))
        {
            Movement.demo = 1;
            mainmenuon = 0;

            DemoCam.GetComponent<Camera>().enabled = true;
            //DemoCam.GetComponent<moveCamera>().enabled = true;
            MenuCam.GetComponent<rotateCamera>().enabled = false;
            MenuCam.GetComponent<Camera>().enabled = false;
            input = 2;
            cone1.GetComponent<MeshRenderer>().enabled = true;
            cone2.GetComponent<MeshRenderer>().enabled = true;
            cone3.GetComponent<MeshRenderer>().enabled = true;
            cone4.GetComponent<MeshRenderer>().enabled = true;
            cone5.GetComponent<MeshRenderer>().enabled = true;
            cone6.GetComponent<MeshRenderer>().enabled = true;


        }
        if (GUI.Button(new Rect(10, rctWindow1.height-10-rctWindow1.height/8, rctWindow1.width - 20, rctWindow1.height / 8), "Play"))
        {
            togglewindow = 1;
            mainmenuon = 0;
            DemoCam.GetComponent<Camera>().enabled = true;
            DemoCam.GetComponent<moveCamera>().enabled = true;
            MenuCam.GetComponent<rotateCamera>().enabled = false;
            MenuCam.GetComponent<Camera>().enabled = false;
        }
    
    GUILayout.EndVertical();

    }

    void DoSettingsWindow(int windowID)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("You can choose the input type");
        if (GUI.Button(new Rect(10, 50, rctWindow2.width - 20, rctWindow2.height/5.5f), "Polynomial"))
        {

            input = 0;

        }
        if (GUI.Button(new Rect(10, rctWindow2.height - 50, rctWindow2.width - 20, rctWindow2.height/5.5f), "Sinusoidal"))
        {
            input = 1;
        }

        GUILayout.EndVertical();


    }
    void DoPlayWindow(int windowID)
    {
        GUILayout.BeginVertical();



        GUILayout.EndVertical();

    }

}

