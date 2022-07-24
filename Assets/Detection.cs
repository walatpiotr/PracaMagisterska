using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private CarValueContainer valueContainer;
    public float detectionLength;
    public GameObject startObject;
    public GameObject directionObject;
    public Vector2 startPoint;
    public Vector2 direction;
    public Vector2 updatedStart;
    public Vector2 updatedDirection;
    public RaycastHit2D hit;

    public string identifier;

    void Start()
    {
        valueContainer = gameObject.GetComponent<CarValueContainer>();
        identifier = Guid.NewGuid().ToString();
        startPoint = startObject.transform.position - transform.position;
        direction = directionObject.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        updatedStart = startPoint + new Vector2(transform.position.x , transform.position.y);
        updatedDirection = direction + new Vector2(transform.position.x, transform.position.y);

        //TODO - calculate propervalue
        detectionLength = ((valueContainer.velocity) * (valueContainer.velocity)) / (2f * valueContainer.breakValue);
        //Debug.Log(detectionLength);

        hit = Physics2D.Raycast(updatedStart, updatedDirection, detectionLength);
        //Debug.DrawLine(updatedStart, updatedDirection);
        if (hit.collider != null)
        {
            Debug.Log(detectionLength);
            Debug.Log("detekcja:" + identifier + " : " + hit.collider.gameObject.GetInstanceID());
            Debug.DrawLine(updatedStart, hit.point);
            valueContainer.carAhead = hit.transform.gameObject;
        }
    }
}
