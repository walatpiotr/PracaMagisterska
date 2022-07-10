using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerating : MonoBehaviour
{
    private CarValueContainer valueContainer;
    public bool isAccelerating;

    void Start()
    {
        valueContainer = gameObject.GetComponent<CarValueContainer>();
    }

    private void FixedUpdate()
    {
        if (isAccelerating && valueContainer.velocity<valueContainer.maxVelocity)
        {
            valueContainer.velocity += valueContainer.acceleration;
        }
    }
}
