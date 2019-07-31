using UnityEngine;
using System.Collections.Generic;

namespace Geometry {
    
    public struct Circle {

        public readonly float x;
        public readonly float y;
        public readonly float radius;
        public Point center => new Point(x, y);

        public Circle (float x, float y, float radius) {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public Circle (Point center, float radius) {
            this.x = center.x;
            this.y = center.y;
            this.radius = radius;
        }

        //also returns true when tangential...
        public bool Intersects (Line other, out List<Point> intersections) {
            intersections = IntersectTools.LineCircleIntersect(other, this);
            return intersections.Count > 0;
        }

        //also returns true when tangential...
        public bool Intersects (Circle other, out List<Point> intersections) {
            intersections = IntersectTools.CircleCircleIntersect(other, this);
            return intersections.Count > 0;
        }

        public override int GetHashCode () {
            return x.GetHashCode() + y.GetHashCode() + radius.GetHashCode();
        }

        public override bool Equals (object obj) {
            if(!(obj is Circle)){
                return false;
            }
            var other = (Circle)obj;
            return 
                this.center.Equals(other.center) &&
                Mathf.Abs(this.radius - other.radius) <= Geometry.EPSILON;
        }

        public override string ToString () {
            return $"(center: {center.ToString()}, radius: {radius:F3})";
        }
    
    }

}
