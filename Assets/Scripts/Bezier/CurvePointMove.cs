using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePointMove : MonoBehaviour
{
    public bool editMode = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (editMode)
        {
            this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        }
    }

    private void OnMouseDown()
    {
        switchMode();
    }

    private void switchMode()
    {
        editMode = !editMode;
    }
}
