/*  CSCI-B481/B581 - Fall 2021 - Mitja Hmeljak
    This script will position the start and end points for two line renderers.
    Positioning is done by using GameObject Transforms.
    Used to show closest point on line segment.
    Original demo code by CSCI-B481 alumnus Rajin Shankar, IU Computer Science.
 */

using UnityEngine;

namespace PS01 {

    public class PolygonScript : MonoBehaviour {

        // fields to connect to Unity objects:
        [SerializeField] private Transform[] subjectLineTransform; //[SerializeField] so that other scripts cannot access these
        [SerializeField] private Transform subjectPointTransform;
        [SerializeField] private LineRenderer[] subjectLineRenderer;     
        [SerializeField] private LineRenderer connectingLineRenderer;

        // Update() is called once per frame:
        private void Update() {

            // set positions for subject line vertices:
            for (int i = 0; i < subjectLineTransform.Length; i++) 
            {
                int j = (i + 1) % subjectLineTransform.Length;
                subjectLineRenderer[i].SetPosition(0, subjectLineTransform[i].position);
                subjectLineRenderer[i].SetPosition(1, subjectLineTransform[j].position);
            }

            // if debug is necessary, uncomment these lines:
            // Debug.Log("subjectLineStartTransform.position = " + subjectLineStartTransform.position);
            // Debug.Log("subjectLineEndTransform.position = " + subjectLineEndTransform.position);
            // Debug.Log("subjectLineRenderer.GetPosition(0) = " + subjectLineRenderer.GetPosition(0));
            // Debug.Log("subjectLineRenderer.GetPosition(1) = " + subjectLineRenderer.GetPosition(1));

            // set positions for connecting line vertices:
            Vector2 lClosestPoint = LineUtility.ClosestPointOnPolygon(
                subjectLineTransform,
                subjectPointTransform.position);

            //Vector2 lClosestPoint = Vector2.one; // temporarily!
            connectingLineRenderer.SetPosition(0, subjectPointTransform.position); //sets start point to presumed origin 
            connectingLineRenderer.SetPosition(1, lClosestPoint);   
        } // end of Update()

    } // end of class SingleSegmentPositionLines

} // end of namespace PS01