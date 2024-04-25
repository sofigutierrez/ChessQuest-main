using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererScript : MonoBehaviour
{

    // From Tutorial https://learn.unity.com/tutorial/creating-a-vr-menu-2019-2#6036dc27edbc2a50f848a701

    // linerendere to store the component attached to the object
    [SerializeField] LineRenderer rend;

    // setting ffor the line renderer are stores as a vector3 array
    Vector3[] points;

    public LayerMask layerMask;

    public void AllignLineRenderer(LineRenderer rend)
    {
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 20);
        }
        rend.SetPositions(points);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World"); // test to see if the script is working

        // get the line renderer component attached to the object
        rend = gameObject.GetComponent<LineRenderer>();

        // initialize the line renderer
        points = new Vector3[2];

        // set the start point of the linerendere to the position of the object
        points[0] = Vector3.zero;

        //set the end point 20 units away from the GO to the Z axis (forward)
        points[1] = transform.position + new Vector3(0, 0, 20);

        //set positions array on the line renderer to the points array
        rend.SetPositions(points);
        rend.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        AllignLineRenderer(rend);
    }
}
