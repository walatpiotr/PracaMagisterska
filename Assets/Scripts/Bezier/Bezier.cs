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
        public Color randomizedColor;

        void Start()
        {
            lineRenderer.positionCount = numOfPoints;
            CleanUpVectors();
            InstantiateMiddlePointprefab();
            ApplyColor();
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
            positions[0] = end.transform.position;
            for(int i=2; i< numOfPoints+1; i++)
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
            var xAverage = (end.transform.position.x + start.transform.position.x) / 2f;
            var yAverage = (end.transform.position.y + start.transform.position.y) / 2f;
            var middleVector = new Vector3(xAverage, yAverage, 0f);
            Debug.Log(end.transform.position + " : " + start.transform.position);
            Debug.Log(xAverage + " : " + yAverage);
            instantiatedPrefab = Instantiate(middlePointPrefab, middleVector, Quaternion.identity);
            instantiatedPrefab.transform.parent = gameObject.transform;
            instantiatedPrefab.GetComponent<CurvePointMove>().editMode = true;
        }

        private void UpdatePoint2ToPrefabPoint()
        {
            point2 = instantiatedPrefab.transform.position;
        }

        private void ApplyColor()
        {
            var r = Random.Range(0f, 1f);
            var g = Random.Range(0f, 1);
            var b = Random.Range(0f, 1f);

            Debug.Log("randomized: " + r + ":" + g + ":" + b);

            randomizedColor = new Color(r, g, b, 1f);
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = randomizedColor;
            lineRenderer.endColor = randomizedColor;
            instantiatedPrefab.GetComponent<SpriteRenderer>().material = new Material(Shader.Find("Sprites/Default"));
            instantiatedPrefab.GetComponent<CurvePointMove>().randomizedColor = randomizedColor;
        }

        public void DestroyBezier()
        {
            Destroy(this.gameObject);
        }
    }
}
