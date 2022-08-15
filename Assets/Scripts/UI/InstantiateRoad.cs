using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateRoad : MonoBehaviour
{
    public GameObject roadPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        var configuration = GameObject.FindGameObjectWithTag("configuration").GetComponent<Configuration>();
        var position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        

        var instance = Instantiate(roadPrefab, position, Quaternion.identity);
        foreach (Transform child in instance.transform)
        {
            foreach (Transform childchild in child.transform)
            {
                Debug.Log("sum of grandchildren: " + child.transform.GetChildCount());
                foreach (Transform childchildchild in childchild.transform)
                {

                    if (childchildchild.tag == "generator")
                    {
                        if (childchild.transform.localRotation.z == 180f)
                        {
                            childchildchild.transform.localPosition = new Vector3(0f, 1.75f+configuration.generatorDistance, 0f);
                        }
                        else
                        {
                            childchildchild.transform.localPosition = new Vector3(0f, -1.75f - configuration.generatorDistance, 0f);
                        }
                    }
                        
                }
            }
        }

        var canva = GameObject.FindGameObjectWithTag("canvaRoads");
        canva.GetComponent<Canvas>().enabled = true;
        Destroy(this.gameObject);
    }
}
