using System.Collections.Generic;
using UnityEngine;

namespace Geometry {
    
    public static class IntersectTools {

        public static List<Point> LineLineIntersect (Line lineA, Line lineB) {
            return null;
        }

        public static List<Point> CircleCircleIntersect (Circle circleA, Circle circleB) {
            float rA = circleA.radius;
            float rB = circleB.radius;
            float xA = circleA.x;
            float xB = circleB.x;
            float yA = circleA.y;
            float yB = circleB.y;
            float lineXMul = -2f * (xB - xA);
            float lineYMul = -2f * (yB - yA);
            float lineConst = (xB * xB) - (xA * xA) + (yB * yB) - (yA * yA) - (rB * rB) + (rA * rA);
            Line intersectLine = new Line(lineXMul, lineYMul, lineConst);
            Debug.Log(intersectLine);
            return LineCircleIntersect(intersectLine, circleA);
        }

        public static List<Point> LineCircleIntersect (Line line, Circle circle) {
            Vector2 linePointA, linePointB;
            float xA = -1;
            float yA = line.fX(xA);
            float xB, yB;
            if(!float.IsNaN(yA)){
                xB = 1;
                yB = line.fX(xB);
            }else{
                yA = -1;
                xA = line.fY(yA);
                yB = 1;
                xB = line.fY(yB);
            }
            linePointA = new Vector2(xA, yA);
            linePointB = new Vector2(xB, yB);
            //circle is at 0, 0 for this...
            var localPA = linePointA - circle.center;
            var localPB = linePointB - circle.center;
            //http://mathworld.wolfram.com/Circle-LineIntersection.html
            float r = circle.radius;
            float x1 = localPA.x;
            float x2 = localPB.x;
            float y1 = localPA.y;
            float y2 = localPB.y;
            float dx = x2 - x1;
            float dy = y2 - y1;
            float dr = Mathf.Sqrt((dx * dx) + (dy * dy));
            float bigD = x1 * y2 - x2 * y1;
            var localIntersects = new List<Point>();
            float discriminant = (r * r) * (dr * dr) - (bigD * bigD);
            if(!(discriminant < 0)){
                float xNumeratorSummand1 = bigD * dy;
                float xNumeratorSummand2 = sgn(dy) * dx * Mathf.Sqrt(discriminant);
                float xQuotient = dr * dr;
                float yNumeratorSummand1 = -bigD * dx;
                float yNumeratorSummand2 = Mathf.Abs(dy) * Mathf.Sqrt(discriminant);
                float yQuotient = dr * dr;
                localIntersects.Add(new Point(
                    (xNumeratorSummand1 + xNumeratorSummand2) / xQuotient, 
                    (yNumeratorSummand1 + yNumeratorSummand2) / yQuotient)
                );
                if(discriminant > 0){
                    localIntersects.Add(new Point(
                        (xNumeratorSummand1 - xNumeratorSummand2) / xQuotient, 
                        (yNumeratorSummand1 - yNumeratorSummand2) / yQuotient)
                    );
                }
            }
            var output = new List<Point>();
            foreach(var intersect in localIntersects){
                output.Add((Vector2)intersect + circle.center);
            }
            return output;

            float sgn (float inputValue) {
                return (inputValue < 0 ? -1 : 1);
            }
        }

    }
	
}
