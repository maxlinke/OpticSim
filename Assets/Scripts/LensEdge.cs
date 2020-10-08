using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensEdge {

    public enum Type {
        LINE, 
        ARC
    }

    public class Hit {

        public readonly Vector2 point;
        public readonly Vector2 normal;
        public readonly float angle;

        private Hit (Vector2 point, Vector2 normal, float angle) {
            this.point = point;
            this.normal = normal;
            this.angle = angle;
        }

    }

    public Type type { get; private set; }
    //all you ever need for line "collision" detection
    private Vector2 linePoint1;
    private Vector2 linePoint2;
    //all this however is for the arc "collision" detection. it's not generalized, only for the stuff i do here...
    private Vector2 arcCenter;
    private float arcRadius;
    private Range xBounds;
    private Range yBounds;

    private LensEdge () {}

    public bool IsIntersected (Vector2 localRayOrigin, Vector2 localRayDirection, out Hit hit) {
        switch(this.type){
            case Type.LINE:
                hit = null;
                return false;
            case Type.ARC:
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

    public static LensEdge GetArcEdge (Vector2 center, float radius) {
        var output = new LensEdge();
        output.type = LensEdge.Type.ARC;
        output.arcCenter = center;
        output.arcRadius = radius;
        return output;
    }
	
}
