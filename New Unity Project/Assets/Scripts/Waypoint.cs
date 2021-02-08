using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //create a static array of points
    public static Transform[] points;

    //populate the list in "Awake method"
    private void Awake()
    {
        //set the size of array according to the current transform's child count
        points = new Transform[transform.childCount];

        //iterate over the value of the child length
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}
