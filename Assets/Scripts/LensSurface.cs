using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensSurface {

    public enum Type {
        PLANAR, 
        SPHERICAL
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

    private Vector2 planarPoint1;
    private Vector2 planarPoint2;

    private Vector2 sphereCenter;
    private float sphereRadius;
    //TODO a range of x-values (technically i only need one, but it can either be a min or max...)

    private LensSurface () {}

    public bool IsIntersected (Vector2 localRayOrigin, Vector2 localRayDirection, out Hit hit) {
        switch(this.type){
            case Type.PLANAR:
                hit = null;
                return false;
            case Type.SPHERICAL:
                hit = null;
                return false;
            default:
                hit = null;
                return false;
        }
        
    }

    public static LensSurface GetPlanarLensSurface (Vector2 pointA, Vector2 pointB) {
        var output = new LensSurface();
        output.type = LensSurface.Type.PLANAR;
        output.planarPoint1 = pointA;
        output.planarPoint2 = pointB;
        return output;
    }

    public static LensSurface GetSphericalLensSurface (Vector2 center, float radius) {
        var output = new LensSurface();
        output.type = LensSurface.Type.SPHERICAL;
        output.sphereCenter = center;
        output.sphereRadius = radius;
        return output;
    }
	
}
