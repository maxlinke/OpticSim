using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Geometry;

public class TestyTestScript : MonoBehaviour {

    void Start () {
        // var c1 = new Circle(-3, 1, 5);
        // var c2 = new Circle(2, -3, 4);
        // foreach(Vector2 intersect in IntersectTools.CircleCircleIntersect(c1, c2)){
        //     Debug.Log(intersect);
        // }

        // var c = new Circle(-3, 1, 5);
        // var l = new Line(-10, 8, 12);
        // foreach(Vector2 intersect in IntersectTools.LineCircleIntersect(l, c)){
        //     Debug.Log(intersect);
        // }

        // var l1 = new Line(3, -1, -3);
        // var l2 = new Line(1, -1, 1);
        // foreach(var i in IntersectTools.LineLineIntersect(l1, l2)){
        //     Debug.Log(i);
        // }

        // var l1 = new Line(3, -3, 3);
        // var l2 = new Line(1, -1, 1);
        // Debug.Log(l1 == l2);
        // var l3 = new Line(7, 5, -13);
        // var l4 = new Line(-l3.a * Mathf.PI, -l3.b * Mathf.PI, -l3.c * Mathf.PI);    //adding  + 0.001f to the new a is enough to make it not equals anymore. that's satisfactory
        // Debug.Log(l3 == l4);
        
        Point A = new Point(2, 3);
        Point B = new Point(-1, 0);
        Point C = new Point(3, 2);
        Point D = new Point(-1, 2);
        Point E = new Point(3, -3);

        Line f = new Line(C, E);
        Line g = new Line(C, D);
        Line h = new Line(A, B);

        LogIntersect(f, g);
        LogIntersect(f, h);
        LogIntersect(g, h);

        void LogIntersect (Line l1, Line l2) {
            if(l1.Intersects(l2, out var l1l2intersect)){
                Debug.Log($"intersect at {l1l2intersect}");
            }else{
                Debug.Log("no intersect!");
            }
        }

    }

    void Update () {
        
    }
	
}
