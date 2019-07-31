using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensEdge {

    public enum Type {
        LINE, 
        CIRCLE
    }

    public class Hit {

        public Vector2 point { get; private set; }
        public Vector2 normal { get; private set; }
        public float angle { get; private set; }

        private Hit (Vector2 point, Vector2 normal, float angle) {
            this.point = point;
            this.normal = normal;
            this.angle = angle;
        }

    }

    public Type type { get; private set; }

    private Vector2 linePoint1;
    private Vector2 linePoint2;

    private Vector2 circleCenter;
    private float circleRadius;
    //TODO a range of x-values (technically i only need one, but it can either be a min or max...)

    private LensEdge () {}

    public bool IsIntersected (Vector2 localRayOrigin, Vector2 localRayDirection, out Hit hit) {
        switch(this.type){
            case Type.LINE:
                hit = null;
                return false;
            case Type.CIRCLE:
                hit = null;
                return false;
            default:
                hit = null;
                return false;
        }
        
    }

    public static LensEdge GetLineEdge (Vector2 pointA, Vector2 pointB) {
        var output = new LensEdge();
        output.type = LensEdge.Type.LINE;
        output.linePoint1 = pointA;
        output.linePoint2 = pointB;
        return output;
    }

    public static LensEdge GetCircleEdge (Vector2 center, float radius) {
        var output = new LensEdge();
        output.type = LensEdge.Type.CIRCLE;
        output.circleCenter = center;
        output.circleRadius = radius;
        return output;
    }
	
}
