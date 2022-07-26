using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public CarValueContainer valueContainer;
    public float detectionLength;
    public GameObject startObject;
    public GameObject directionObject;
    public Vector2 startPoint;
    public Vector2 direction;
    public Vector2 updatedStart;
    public Vector2 updatedDirection;
    public RaycastHit2D hit;

    public string identifier;

    public bool isDetectionOn=true;

    public event EventHandler<OnCarDetectionEventArgs> OnCarDetection;
    public class OnCarDetectionEventArgs : EventArgs
    {
        public GameObject carAheadEventArg;
    }

    public event EventHandler OnNoDetection;
    public event EventHandler OnSafeDetection;

    void Start()
    {
        valueContainer = gameObject.GetComponent<CarValueContainer>();
        identifier = Guid.NewGuid().ToString();
        startPoint = startObject.transform.position - transform.position;
        direction = directionObject.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        if (isDetectionOn) {
            updatedStart = startPoint + new Vector2(transform.position.x, transform.position.y);
            updatedDirection = direction + new Vector2(transform.position.x, transform.position.y);

            //TODO - calculate propervalue
            detectionLength = ((valueContainer.velocity) * (valueContainer.velocity)) / (2f * valueContainer.breakValue) + valueContainer.safeDistance;
            //Debug.Log(detectionLength);

            hit = Physics2D.Raycast(updatedStart, updatedDirection, detectionLength);
            //Debug.DrawLine(updatedStart, updatedDirection);
            if (hit.collider != null)
            {
                if (detectionLength <= valueContainer.safeDistance)
                {
                    valueContainer.carAhead = hit.transform.gameObject;
                    OnSafeDetection?.Invoke(this, null);
                }
                else
                {
                    //Debug.Log(detectionLength);
                    //Debug.Log("detekcja:" + identifier + " : " + hit.collider.gameObject.GetInstanceID());
                    //Debug.DrawLine(updatedStart, hit.point);
                    valueContainer.carAhead = hit.transform.gameObject;
                    OnCarDetection?.Invoke(this, new OnCarDetectionEventArgs { carAheadEventArg = hit.transform.gameObject });
                }
            }
            else
            {
                OnNoDetection?.Invoke(this, null);
            }
        }
    }
}
