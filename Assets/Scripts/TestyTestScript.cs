using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geometry;

public class TestyTestScript : MonoBehaviour {

    void Start () {
        var c1 = new Circle(-3, 1, 5);
        var c2 = new Circle(2, -3, 4);
        foreach(Vector2 intersect in IntersectTools.CircleCircleIntersect(c1, c2)){
            Debug.Log(intersect);
        }
        // var c = new Circle(-3, 1, 5);
        // var l = new Line(-10, 8, 12);
        // foreach(Vector2 intersect in IntersectTools.LineCircleIntersect(l, c)){
        //     Debug.Log(intersect);
        // }
    }

    void Update () {
        
    }
	
}
