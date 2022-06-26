using UnityEngine;

namespace Assets.Scripts
{
    public class Bezier: MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public GameObject start;
        public GameObject end;
        public Vector3 point2;

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
            try
            {
                Debug.DrawLine(end.transform.position, start.transform.position, Color.white, 2.5f);
                Debug.DrawLine(end.transform.position, start.transform.position, Color.white, 2.5f);
                Debug.DrawLine(end.transform.position, start.transform.position, Color.white, 2.5f);
                DrawLineCurve();
            }
            catch
            {
                Destroy(this.gameObject);
            }
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
            Vector3 p = uu * end.transform.position;
            p += 2 * u * t * point2;
            p += tt * start.transform.position;
            return p;
        }

        private void DrawLineCurve()
        {
            for(int i=1; i< numOfPoints+1; i++)
            {
                float t = i / (float)numOfPoints;
                positions[i - 1] = CalculateQuadraticBezierPoint(t, end.transform.position, start.transform.position, point2);
            }
            lineRenderer.SetPositions(positions);

        }

        private void CleanUpVectors()
        {
            point2 = VectorExtensions.XZPlane(point2);
        }

        private void InstantiateMiddlePointprefab()
        {
            instantiatedPrefab = Instantiate(middlePointPrefab, point2, Quaternion.identity);
            instantiatedPrefab.transform.parent = gameObject.transform;
        }

        private void UpdatePoint2ToPrefabPoint()
        {
            point2 = instantiatedPrefab.transform.position;
        }
    }
}
