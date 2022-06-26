using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvePointMove : MonoBehaviour
{
    public bool editMode = false;
    public Color randomizedColor;
    public float rGreyMultiplier;
    public float gGreyMultiplier;
    public float bGreyMultiplier;

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
            this.GetComponent<SpriteRenderer>().material.color = randomizedColor;
            this.gameObject.GetComponentInParent<LineRenderer>().startColor = randomizedColor;
            this.gameObject.GetComponentInParent<LineRenderer>().endColor = randomizedColor;
        }
        else
        {
            rGreyMultiplier = randomizedColor.r / 255f;
            gGreyMultiplier = randomizedColor.g / 255f;
            bGreyMultiplier = randomizedColor.b / 255f;
            this.gameObject.GetComponentInParent<LineRenderer>().startColor = new Color(rGreyMultiplier*50f, gGreyMultiplier * 50f, bGreyMultiplier * 50f);
            this.gameObject.GetComponentInParent<LineRenderer>().endColor = new Color(rGreyMultiplier * 50f, gGreyMultiplier * 50f, bGreyMultiplier * 50f);
            this.GetComponent<SpriteRenderer>().material.color = new Color(rGreyMultiplier * 50f, gGreyMultiplier * 50f, bGreyMultiplier * 50f);
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
