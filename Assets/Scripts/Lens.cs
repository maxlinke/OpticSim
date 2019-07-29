using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lens {

    public const float MESH_RESOLUTION = 32;        //points per lens surface
    public const float MIN_THICKNESS = 0.001f;      //1mm

    public float FocalLength => CalculateFocalLength();

    float r1, r2, n, d, r;

    public Lens (float frontRadius, float rearRadius, float refractiveIndex, float thickness, float lensRadius) {
        this.r1 = frontRadius;
        this.r2 = rearRadius;
        this.d = Mathf.Max(MIN_THICKNESS, thickness);
        this.n = refractiveIndex;
        if(TryGetIntersectPoint(r1, r1, d, out float iX, out float iY)){        //TODO instead of r1, r2 and inferring stuff from there use a sphere/circle struct so i don't have to recalculate centers and offsets in multiple places...
            lensRadius = Mathf.Min(Mathf.Abs(iY), lensRadius);
        }
    }

    public Vector2[] GetFrontOutlinePointsBottomToTop () {
        return null;
    }

    public Vector2[] GetBackOutlinePointsBottomToTop () {
        return null;
    }

    public Vector2[] GetOutlinePoints () {
        List<Vector2> output = new List<Vector2>();
        var front = GetFrontOutlinePointsBottomToTop();
        var back = GetBackOutlinePointsBottomToTop();
        for(int i=0; i<front.Length; i++){
            output.Add(front[i]);
        }
        for(int i=back.Length-1; i>=0; i--){
            output.Add(front[i]);
        }
        return output.ToArray();
    }

    public Mesh GetMesh () {
        var front = GetFrontOutlinePointsBottomToTop();
        var back = GetBackOutlinePointsBottomToTop();
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
        return 1f / ((n - 1f) * ((1 / r1) * (1 / r2) * (((n - 1) * d) / (n * r1 * r2))));
    }
	
}
