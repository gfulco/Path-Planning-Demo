using UnityEngine;
using System.Collections;

public class rotateCamera : MonoBehaviour
{

    public GameObject target;//the target object

    private float speedMod = 10.0f;//a speed modifier
    private Vector3 point,offset;//the coord to the point where the camera looks at

    void Awake()
    {//Set up things on the start method
        target = GameObject.Find("Car");
        point = target.transform.position;//get target's coords
        transform.LookAt(point);//makes the camera look to it
        offset = transform.position - target.transform.position;
        transform.position = offset;
    }

    void Update()
    {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
        transform.RotateAround(point, new Vector3(0.0f, 3.0f, 0.0f), 2 * Time.deltaTime * speedMod);
    }
}
