using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class moveCamera : MonoBehaviour
{

    public GameObject target;//the t arget object

    //private float speedMod = 10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at

    private Vector3 offset;
    public static int init = 0;
    // Use this for initialization
    void Start()
    {
        
        target = GameObject.Find("Car");
        point = target.transform.position;//get target's coords
     
        transform.LookAt(point);//makes the camera look to it
        
        //offset = transform.position - target.transform.position + new Vector3((float)Movement.x_i, 0, (float)Movement.y_i);
    }

    void Update()
    {

        //Debug.Log(target.transform.position.x.ToString());
        //if (init == 0)
        //{
        //    offset = transform.position - target.transform.position + new Vector3((float)Movement.x_i, 0, (float)Movement.y_i);
        //    transform.position = target.transform.position + offset ;
        //    init = 1;
        //}
        //else if (init == 1)
        //    transform.position = target.transform.position + offset;

    }
}