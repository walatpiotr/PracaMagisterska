using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public CarValueContainer valueContainer;
    public float detectionLength;
    public float calculatedDetectionLength;
    public GameObject startObject;
    public GameObject directionObject;
    public Vector2 startPoint;
    public Vector2 direction;
    public Vector2 updatedStart;
    public Vector2 updatedDirection;
    public Vector3 offset;
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
        startObject = transform.GetChild(0).gameObject;
        directionObject = transform.GetChild(1).gameObject;
        startPoint = startObject.transform.position - transform.position;
        direction = directionObject.transform.position - transform.position;
        if (isDetectionOn) {
            updatedStart = startPoint + new Vector2(transform.position.x, transform.position.y);
            updatedDirection = direction + new Vector2(transform.position.x, transform.position.y);

            //TODO - calculate propervalue
            detectionLength = ((valueContainer.velocity) * (valueContainer.velocity)) / (2f * valueContainer.breakValue) + valueContainer.safeDistance;
            calculatedDetectionLength = detectionLength;
            //Debug.Log(detectionLength);

            Vector3 directionTemp = Vector3.Normalize(updatedDirection - updatedStart);
            offset = new Vector3(updatedStart.x, updatedStart.y, 0f) + (directionTemp * detectionLength);

            //Debug.DrawLine(updatedStart, offset, Color.yellow);


            hit = Physics2D.Raycast(updatedStart, directionTemp, detectionLength);
            //Debug.DrawLine(updatedStart, updatedDirection);
            if (hit.collider != null)
            {
                if (detectionLength <= valueContainer.safeDistance)
                {
                    valueContainer.carAhead = hit.transform.gameObject;
                    OnSafeDetection?.Invoke(this, null);
                }
                if( detectionLength < valueContainer.safeDistance)
                {
                    GetComponent<CarBehaviourBase>().KeepVelocity(0f);
                }
                else
                {
                    Debug.DrawLine(updatedStart, hit.point);
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
