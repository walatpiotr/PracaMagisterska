using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        if(Input.GetKey("z"))
        {
            transform.Rotate(Vector3.forward * 0.25f);
        }
        if (Input.GetKey("x"))
        {
            transform.Rotate(Vector3.forward * -0.25f);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(-0.25f, 0f,0f));
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(0.25f, 0f, 0f));
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector3(0f, 0.25f, 0f));
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3( 0f, -0.25f, 0f));
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            this.gameObject.GetComponent<Camera>().orthographicSize--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
        {
            this.gameObject.GetComponent<Camera>().orthographicSize++;
        }
    }
}
