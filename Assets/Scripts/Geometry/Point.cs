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
            var otherPoint = (Point)obj;
            return otherPoint.x.Equals(this.x) && otherPoint.y.Equals(this.y);
        }

        public override string ToString () {
            return $"(x: {x:F3}, y: {y:F3})";
        }

    }
	
}
