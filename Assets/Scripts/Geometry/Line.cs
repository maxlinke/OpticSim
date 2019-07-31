namespace Geometry {
    
    public struct Line {

        public readonly float a;
        public readonly float b;
        public readonly float c;

        public float xMultiplier => a;
        public float yMultiplier => b;
        public float constantOffset => c;

        public Line (float xMul, float yMul, float constOffset) {
            this.a = xMul;
            this.b = yMul;
            this.c = constOffset;
        }

        //a kind of public Line (point, point) would be nice... but how do i convert from that into a, b and c?

        // public static Line FromFunctionOfX (float xMul, float offset) {

        // }

        // public static Line FromFunctionOfY (float yMul, float offset) {

        // }

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

        public override int GetHashCode () {
            return a.GetHashCode() + b.GetHashCode() + c.GetHashCode();
        }

        public override bool Equals (object obj) {
            if(!(obj is Line)){
                return false;
            }
            var otherLine = (Line)obj;
            return otherLine.a.Equals(this.a) && otherLine.b.Equals(this.b) && otherLine.c.Equals(this.c);
        }

        public override string ToString () {
            return $"(a: {a:F3}, b: {b:F3}, c: {c:F3})";
        }

    }
	
}
