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
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        editMode = true;
        this.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
    }

    private void OnMouseUp()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
        editMode = false;
    }

    private void OnMouseDrag()
    {
        this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
    }
}
