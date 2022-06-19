using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPostion : MonoBehaviour
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
            ListenToKeyBoard();
        }
    }

    private void ListenToKeyBoard()
    {
        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.forward * 0.1f);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.forward * -0.1f);
        }
        if (Input.GetKey("a"))
        {
            this.transform.position += new Vector3(-0.01f, 0f, 0f);
        }
        if (Input.GetKey("w"))
        {
            this.transform.position += new Vector3(0f, 0.01f, 0f);
        }
        if (Input.GetKey("s"))
        {
            this.transform.position += new Vector3(0f, -0.01f, 0f);
        }
        if (Input.GetKey("d"))
        {
            this.transform.position += new Vector3(0.01f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        DisableOtherRoadsEdit();
        editMode = true;
        this.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
    }

    void DisableOtherRoadsEdit()
    {
        var otherRoadParts = GameObject.FindGameObjectsWithTag("road");
        foreach (GameObject road in otherRoadParts)
        {
            road.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
            road.GetComponent<EditPostion>().editMode = false;
        }
    }

    private void OnMouseDrag()
    {
        this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);

    }
}
