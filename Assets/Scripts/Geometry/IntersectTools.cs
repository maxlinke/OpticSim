using System.Collections.Generic;
using UnityEngine;

namespace Geometry {
    
    public static class IntersectTools {

        public static bool LineLineIntersect (Line lineA, Line lineB, out Point intersectPoint) {
            if(lineA.a == 0){
                return LineLineIntersect(lineB, lineA, out intersectPoint);     //because the f(y) can return NaN if lineA is vertical...
            }
            var output = new List<Point>();
            float yQuotient = lineA.a * lineB.b - lineB.a * lineA.b;
            if(yQuotient == 0){
                intersectPoint = new Point(float.NaN, float.NaN);
                return false;
            }
            float yNumerator = lineB.a * lineA.c - lineA.a * lineB.c;
            float y = yNumerator / yQuotient;
            float x = lineA.fY(y);
            intersectPoint = new Point(x, y);
            return true;
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
            //revert transformation into local space of circle
            foreach(var intersect in localIntersects){
                output.Add((Vector2)intersect + circle.center);
            }
            return output;

            //since regular sign function returns 0 at input 0
            float sgn (float inputValue) {
                return (inputValue < 0 ? -1 : 1);
            }
        }

    }
	
}
