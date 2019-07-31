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

        public override int GetHashCode () {
            return x.GetHashCode() + y.GetHashCode() + radius.GetHashCode();
        }

        public override bool Equals (object obj) {
            if(!(obj is Circle)){
                return false;
            }
            var otherCircle = (Circle)obj;
            return this.x.Equals(otherCircle.x) && this.y.Equals(otherCircle.y) && this.radius.Equals(otherCircle.radius);
        }

        public override string ToString () {
            return $"(center: {center.ToString()}, radius: {radius:F3})";
        }
    
    }

}
