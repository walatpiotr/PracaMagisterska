using Assets.Scripts.Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject currentPath;
    public GameObject target;
    public float speed = 1.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.up = target.transform.position - transform.position;

        if (transform.position == target.transform.position && currentPath == null)
        {
            currentPath = target.transform.parent.GetComponent<Path>().nextPath[0];
            target = currentPath.GetComponent<CurvePath>().curveNodes[0];
        }
        if(transform.position == target.transform.position && currentPath != null)
        {
            var index = currentPath.GetComponent<CurvePath>().curveNodes.IndexOf(target);
            target = currentPath.GetComponent<CurvePath>().curveNodes[index+1];
        }
    }
}
