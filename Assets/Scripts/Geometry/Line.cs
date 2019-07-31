using UnityEngine;
using System.Collections.Generic;

namespace Geometry {
    
    public struct Line {

        public readonly float a;
        public readonly float b;
        public readonly float c;

        public float xMultiplier => a;
        public float yMultiplier => b;
        public float constantOffset => c;

        public Line (float xMul, float yMul, float constOffset) {
            if(xMul == 0 && yMul == 0){
                throw new System.Exception("Invalid definition for line! One of the coefficients MUST not be zero!");
            }
            this.a = xMul;
            this.b = yMul;
            this.c = constOffset;
        }

        public Line (Point p1, Point p2) {
            if(p1.Equals(p2)){
                throw new System.Exception("Two points for creating a line MUST not be equal!");
            }
            this.a = p1.y - p2.y;
            this.b = p2.x - p1.x;
            this.c = p1.x * p2.y - p2.x * p1.y;
        }

        public static bool operator ==(Line l1, Line l2) => l1.Equals(l2);
        public static bool operator !=(Line l1, Line l2) => !(l1.Equals(l2));

        public float fX (float x) {
            if(b == 0f){
                return float.NaN;
            }
            return -((a * x) + c) / b;
        }

        public float fY (float y) {
            if(a == 0f){
                return float.NaN;
            }
            return -((b * y) + c) / a;
        }

        public bool Intersects (Line other, out Point intersectPoint) {
            return IntersectTools.LineLineIntersect(this, other, out intersectPoint);
        }

        //also returns true when tangential...
        public bool Intersects (Circle other, out List<Point> intersections) {
            intersections = IntersectTools.LineCircleIntersect(this, other);
            return intersections.Count > 0;
        }

        public override int GetHashCode () {
            return a.GetHashCode() + b.GetHashCode() + c.GetHashCode();
        }

        public override bool Equals (object obj) {
            if(!(obj is Line)){
                return false;
            }
            var other = (Line)obj;
            float refValue;
            if(this.a != 0){
                refValue = other.a / this.a;
            }else if(this.b != 0){
                refValue = other.b / this.b;
            }else if(this.c != 0){
                refValue = other.c / this.c;
            }else{
                throw new System.Exception("All coefficients are zero, that's NOT supposed to happen!");
            }
            float da = Mathf.Abs((this.a * refValue) - other.a);
            float db = Mathf.Abs((this.b * refValue) - other.b);
            float dc = Mathf.Abs((this.c * refValue) - other.c);
            Debug.Log($"(da: {da}, db: {db}, dc: {dc})");
            Debug.Log($"{Geometry.EPSILON}");
            return
                da <= Geometry.EPSILON &&
                db <= Geometry.EPSILON &&
                dc <= Geometry.EPSILON;
        }

        public override string ToString () {
            return $"(a: {a:F3}, b: {b:F3}, c: {c:F3})";
        }

    }
	
}
