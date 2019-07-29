using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens {

    public float FocalLength => CalculateFocalLength();

    float r1, r2, n, thickness, radius;

    public Lens (float r1, float r2, float n, float thickness, float desiredRadius) {
        if(TryGetIntersectPoint(r1, r2, thickness, out float x, out float y)){
            Debug.Log($"yes: {x:F2}, {y:F2}");
        }else{
            Debug.Log("no");
        }
    }

    public Mesh GetMesh () {
        return null;
    }

    private bool TryGetIntersectPoint (float r1, float r2, float thickness, out float intersectX, out float intersectY) {
        bool face1Flat = float.IsInfinity(r1);
        bool face2Flat = float.IsInfinity(r2);
        float d2 = thickness / 2;
        float xOff1 = r1 - d2;
        float xOff2 = r2 + d2;
        if(face1Flat && face2Flat){
            intersectX = thickness == 0 ? 0 : float.NaN;
            intersectY = float.NaN;
            return false;
        }else{
            float r, xOff, x;
            if(face1Flat || face2Flat){
                if(face1Flat){
                    r = Mathf.Abs(r2);
                    xOff = xOff2;
                    x = -d2;
                }else{
                    r = Mathf.Abs(r1);
                    xOff = xOff1;
                    x = d2;
                }
            }else{
                x = ((r2 * r2) - (r1 * r1) + (xOff1 * xOff1) - (xOff2 * xOff2)) / (2 * (xOff1 - xOff2));
                r = r1;
                xOff = xOff1;
            }
            float y = Mathf.Sqrt(Mathf.Pow(r, 2) - Mathf.Pow(x - xOff, 2));
            if(float.IsNaN(y)){
                intersectX = float.NaN;
                intersectY = float.NaN;
                return false;
            }else{
                intersectX = x;
                intersectY = y;
                return true;
            }
        }
    }

    private float CalculateFocalLength () {
        return 1f / ((n - 1f) * ((1 / r1) * (1 / r2) * (((n - 1) * thickness) / (n * r1 * r2))));
    }
	
}
