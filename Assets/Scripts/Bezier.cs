using UnityEngine;

namespace Assets.Scripts
{
    public class Bezier: MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public Vector3 point0, point1, point2;

        public GameObject middlePointPrefab;
        public GameObject instantiatedPrefab;

        private int numOfPoints = 10;
        public Vector3[] positions = new Vector3[10];

        void Start()
        {
            lineRenderer.positionCount = numOfPoints;
            DrawLineCurve();
            CleanUpVectors();
            InstantiateMiddlePointprefab();
        }

        void Update()
        {
            Debug.DrawLine(point0, point1, Color.white, 2.5f);
            Debug.DrawLine(point2, point0, Color.white, 2.5f);
            Debug.DrawLine(point2, point1, Color.white, 2.5f);
            DrawLineCurve();
            UpdatePoint2ToPrefabPoint();
        }

        private Vector3 CalculateLinearBezierPoint(float t, Vector3 p0, Vector3 p1)
        {
            return p0 + t * (p1 - p0);
        }

        private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            float u = 1-t;
            float tt = t * t;
            float uu = u * u;
            Vector3 p = uu * point0;
            p += 2 * u * t * point2;
            p += tt * point1;
            return p;
        }

        private void DrawLineCurve()
        {
            for(int i=1; i< numOfPoints+1; i++)
            {
                float t = i / (float)numOfPoints;
                positions[i - 1] = CalculateQuadraticBezierPoint(t, point0, point1, point2);
            }
            lineRenderer.SetPositions(positions);

        }

        private void CleanUpVectors()
        {
            point0 = VectorExtensions.XZPlane(point0);
            point1 = VectorExtensions.XZPlane(point1);
            point2 = VectorExtensions.XZPlane(point2);
        }

        private void InstantiateMiddlePointprefab()
        {
            instantiatedPrefab = Instantiate(middlePointPrefab, point2, Quaternion.identity);
        }

        private void UpdatePoint2ToPrefabPoint()
        {
            point2 = instantiatedPrefab.transform.position;
        }
    }
}
