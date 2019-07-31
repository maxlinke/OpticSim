using UnityEngine;

namespace Geometry {
    
    public struct Point {

        public readonly float x;
        public readonly float y;

        public Point (float x, float y) {
            this.x = x;
            this.y = y;
        }

        public Point (Vector2 vec) {
            this.x = vec.x;
            this.y = vec.y;
        }

        public static implicit operator Vector2(Point p) => p.ToVector2();
        public static implicit operator Point(Vector2 v) => new Point(v);

        public static bool operator ==(Point p1, Point p2) => p1.Equals(p2);
        public static bool operator !=(Point p1, Point p2) => !(p1.Equals(p2));

        public Vector2 ToVector2 () {
            return new Vector2(x, y);
        }

        public override int GetHashCode () {
            return x.GetHashCode() + y.GetHashCode();
        }

        public override bool Equals (object obj) {
            if(!(obj is Point)){
                return false;
            }
            var other = (Point)obj;
            return 
                Mathf.Abs(other.x - this.x) <= Geometry.EPSILON && 
                Mathf.Abs(other.y - this.y) <= Geometry.EPSILON;
        }

        public override string ToString () {
            return $"(x: {x:F3}, y: {y:F3})";
        }

    }
	
}
