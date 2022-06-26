using Assets.Scripts;
using UnityEngine;

public class BezierStart : MonoBehaviour
{
    public GameObject bezierPrefab;
    public GameObject bezierTriPrefab;

    public GameObject instance;

    public Vector3 pointer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateFlattenCameraToWorld();
    }

    private void OnMouseDown()
    {
        if (!GameObject.FindGameObjectWithTag("bezierSimple"))
        {

            instance = Instantiate(bezierPrefab, pointer, Quaternion.identity);
            GameObject.FindGameObjectWithTag("bezierManager").GetComponent<BezierContainer>().bezier = instance;
            instance.GetComponent<BezierTemp>().enabled = true;
            instance.GetComponent<BezierTemp>().end = this.gameObject;
            instance.GetComponent<BezierTemp>().point1 = VectorExtensions.XZPlane(pointer);
            Debug.Log("clicked");
        }
        else
        {
            var bezierTemp = GameObject.FindGameObjectWithTag("bezierSimple");
            var endPoint = bezierTemp.GetComponent<BezierTemp>().end;
            Destroy(GameObject.FindGameObjectWithTag("bezierSimple"));
            instance = Instantiate(bezierTriPrefab, pointer, Quaternion.identity);
            instance.GetComponent<Bezier>().end = endPoint;
            instance.GetComponent<Bezier>().start = this.gameObject;
            //TODO - average Vectors3
            var xRand = UnityEngine.Random.Range(0f, 2.5f);
            var yRand = UnityEngine.Random.Range(0f, 2.5f);
            var xAverage = (instance.GetComponent<Bezier>().end.transform.position.x + instance.GetComponent<Bezier>().end.transform.position.x) / 2;
            var yAverage = (instance.GetComponent<Bezier>().start.transform.position.y + instance.GetComponent<Bezier>().start.transform.position.y) / 2;
            instance.GetComponent<Bezier>().point2 = new Vector3(xAverage+xRand, yAverage+yRand, 0f);

        }

        
    }
    void CalculateFlattenCameraToWorld()
    {
        pointer = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
    }
}
