/*  CSCI-B481/B581 - Fall 2021 - Mitja Hmeljak
    This script provides a library of "utility" methods,
    that may be useful to solve Problem Set 01.
    
    However, you may have to complete the parts marked as TODO ...
    Original demo code by CSCI-B481 alumnus Rajin Shankar, IU Computer Science.
 */

using UnityEngine;

namespace PS01 {

    public static class LineUtility {
    
        // DirectionNormal() --- returns the normal to a given direction vector:
        public static Vector2 DirectionNormal(Vector2 direction) {
            // TODO: compute 
            Vector2 normal = new Vector2(-direction.y,direction.x);  //n = ( -(y2 - y1) , (x2 - x1) )
            return normal;
        } // end of DirectionNormal() 

        // LineSegmentNormal() --- returns the normal to a line segment:
        public static Vector2 LineSegmentNormal(Vector2 start, Vector2 end) {
            // TODO: compute 
            Vector2 normal = new Vector2(-(end.y-start.y),(end.x-start.x));     //n = ( -(y2 - y1) , (x2 - x1) )
            return normal;
        } // end of LineSegmentNormal()
        

        // ClosestPointOnLine() --- returns the closest point on a line to a given query point:
        public static Vector2 ClosestPointOnLine(Vector2 pointOnLine, Vector2 direction, Vector2 point) {
            //l = (dot product) = (direction unit vector v) ⋅ (x0-x1)
            direction.Normalize();
            float l = Vector2.Dot(direction, point - pointOnLine);

            //localX is the point on line; P = x1 + l*v 
            Vector2 localX = pointOnLine + (l * direction);
            return localX;
            
            //  you may find useful the 2D Point-Line Geometry expressions shown at lecture time
            //  
            
        } // end of ClosestPointOnLine()


        // ClosestPointOnSegment() --- returns the closest point (on a line segment)
        //                             to a given subject point:
        public static Vector2 ClosestPointOnSegment(Vector2 start, Vector2 end, Vector2 point) {
            // TODO: 
            //  you may find the above methods useful, once you complete them...
            float l =  Vector2.Dot((end - start).normalized, point - start);
            float length = (end - start).magnitude; 
             if (l < 0) {
                 return start;
             } else if (l > length) {
                 return end;
             } else {
                 return ClosestPointOnLine(start, end - start, point);
             }
        } // end of ClosestPointOnSegment()



        // NOTE: decide whether you prefer to use
        //       either the ClosestPointOnPolygon() method
        //       or the ClosestPointOnPolygon() method,
        //       but not both...
        
        
        // ClosestPointOnPolygon() --- returns the closest point (on a polygon)
        //                             to a given query point.
        //
        // Note:
        //   Polygon given as array of vertices with vertex[n-1] connecting back to vertex[0]
        public static Vector2 ClosestPointOnPolygon(Vector2[] polygonPoints, Vector2 point) {
            Vector2 result = Vector2.zero;
            float minSqrDistance = float.PositiveInfinity;
            for (int i = 0; i < polygonPoints.Length; i++) {
                int j = (i + 1) % polygonPoints.Length;
                Vector2 side = polygonPoints[j] - polygonPoints[i];
                float sideLength = side.magnitude;
                Vector2 sideDirection = side / sideLength;

            // TODO: 
            //  you may find useful the utility methods at the top of this file, once you complete them...

                Vector2 pointOnPolygon;
            //    if (localX < 0) {
            //        ...
            //    } else if (localX > sideLength) {
            //        ...
            //    } else {
            //        ...
            //    }

            // TODO:
            //  the following code works, as long as you computed pointOnPolygon correctly.
            //  It will be useful to understand what the following lines do:
                Vector2 delta = point; //- pointOnPolygon;
                float sqrDistance = delta.sqrMagnitude;

                if (sqrDistance < minSqrDistance) {
                    //result = pointOnPolygon;
                    minSqrDistance = sqrDistance;
                }
            }
            return result;
        } // end of ClosestPointOnPolygon()


        // ClosestPointOnPolygon() --- returns the closest point (on a polygon)
        //                             to a given subject point.
        //  Note:
        //      the polygon is given as array of transforms
        //      with vertex[n-1] connecting back to vertex[0]
        //
        public static Vector2 ClosestPointOnPolygon(Transform[] polygonVertices, Vector2 point) {
        
            Vector2 result = Vector2.zero;
            float minSqrDistance = float.PositiveInfinity;
            
            for (int i = 0; i < polygonVertices.Length; i++) {
                int j = (i + 1) % polygonVertices.Length;
                Vector2 side = polygonVertices[j].position - polygonVertices[i].position; //direction = end - start
                float sideLength = side.magnitude;
                Vector2 sideDirection = side / sideLength;  //normalizing by dividing vector by magnitude

            // TODO: 
            //  you may find useful the utility methods at the top of this file, once you complete them...

                Vector2 pointOnPolygon = ClosestPointOnSegment(polygonVertices[i].position, polygonVertices[j].position, point);
            //    if (localX < 0) {
            //        pointOnPolygon = ...
            //    } else if (localX > sideLength) {
            //        pointOnPolygon = ...
            //    } else {
            //        pointOnPolygon = ...
            //    }

            // TODO:
            //  the following code works, as long as you computed pointOnPolygon correctly.
            //  It will be useful to understand what the following lines do:
                Vector2 delta = point - pointOnPolygon;
                float sqrDistance = delta.sqrMagnitude;

                if (sqrDistance < minSqrDistance) {
                    result = pointOnPolygon;
                    minSqrDistance = sqrDistance;
                }
            }
            return result;
        } // end of ClosestPointOnPolygon()


    } // end of static class LineUtility

} // end of namespace PS01