using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarValueContainer : MonoBehaviour
{
    public float maxVelocity;
    public float velocity;
    public float acceleration;
    public float breakValue;
    public float safeDistance;
    public GameObject carAhead;

    public float firstCarOffset;
    public float secondCarOffset;

    public void Start()
    {
        var configuration = GameObject.FindGameObjectWithTag("configuration").GetComponent<Configuration>();
        maxVelocity = configuration.maxVelocity;
        acceleration = configuration.acceleration;
        breakValue = configuration.breaking;
        safeDistance = configuration.safeDistance;
    }
}
