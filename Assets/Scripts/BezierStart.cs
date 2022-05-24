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
            instance.GetComponent<BezierTemp>().point0 = this.transform.position;
            instance.GetComponent<BezierTemp>().point1 = VectorExtensions.XZPlane(pointer);
            Debug.Log("clicked");
        }
        else
        {
            
            Destroy(GameObject.FindGameObjectWithTag("bezierSimple"));
            instance = Instantiate(bezierTriPrefab, pointer, Quaternion.identity);
            instance.GetComponent<Bezier>().point0 = GameObject.FindGameObjectWithTag("bezierManager").GetComponent<BezierContainer>().bezier.GetComponent<BezierTemp>().point0;
            instance.GetComponent<Bezier>().point1 = pointer;
            //TODO - average Vectors3
            instance.GetComponent<Bezier>().point2 = new Vector3(0f,0f,0f);

        }

        
    }
    void CalculateFlattenCameraToWorld()
    {
        pointer = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
    }
}
