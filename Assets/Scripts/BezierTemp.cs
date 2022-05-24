using UnityEngine;

namespace Assets.Scripts
{
    public class BezierTemp : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Vector3 point0;
        public Vector3 point1;

        public int numOfPoints = 50;
        public Vector3[] positions = new Vector3[50];

        void Start()
        {
            lineRenderer.positionCount = numOfPoints;
        }

        void Update()
        {
            point1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CleanUpVectors();
            DrawLineCurve();
        }

        private Vector2 CalculateLinearBezierPoint(float t, Vector2 p0, Vector2 p1)
        {
            return p0 + t * (p1 - p0);
        }

        private void DrawLineCurve()
        {
            for (int i = 1; i < numOfPoints + 1; i++)
            {
                float t = i / numOfPoints;
                positions[i - 1] = CalculateLinearBezierPoint(t, point0, point1).AddLayer();
            }

            lineRenderer.SetPositions(positions);

        }
        private void CleanUpVectors()
        {
            point0 = VectorExtensions.XZPlane(point0);
            point1 = VectorExtensions.XZPlane(point1);
        }
    }
}
