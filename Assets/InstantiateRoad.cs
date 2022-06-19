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
        var position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        Instantiate(roadPrefab, position, Quaternion.identity);
        var canva = GameObject.FindGameObjectWithTag("canvaRoads");
        canva.GetComponent<Canvas>().enabled = true;
        Destroy(this.gameObject);
    }
}
