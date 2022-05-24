using UnityEngine;

namespace Assets.Scripts
{
    public class Bezier: MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Vector3 point0, point1, point2;

        private int numOfPoints = 50;
        private Vector3[] positions = new Vector3[50];

        void Start()
        {
            lineRenderer.positionCount = numOfPoints;
            DrawLineCurve();
            CleanUpVectors();
        }

        void Update()
        {
            Debug.DrawLine(point0, point1, Color.white, 2.5f);
            Debug.DrawLine(point2, point0, Color.white, 2.5f);
            Debug.DrawLine(point2, point1, Color.white, 2.5f);
            DrawLineCurve();
        }

        private Vector3 CalculateLinearBezierPoint(float t, Vector3 p0, Vector3 p1)
        {
            return p0 + t * (p1 - p0);
        }

        // private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)

        private void DrawLineCurve()
        {
            for(int i=1; i< numOfPoints+1; i++)
            {
                float t = i / numOfPoints;
                positions[i - 1] = CalculateLinearBezierPoint(t, point0, point1);
            }
            lineRenderer.SetPositions(positions);

        }

        private void CleanUpVectors()
        {
            point0 = VectorExtensions.XZPlane(point0);
            point1 = VectorExtensions.XZPlane(point1);
            point2 = VectorExtensions.XZPlane(point2);
        }
    }
}
