using Assets.Scripts.Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject currentPath;
    public GameObject target;
    public int nodeNumberInPath=0;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, gameObject.GetComponent<CarValueContainer>().velocity * Time.deltaTime);
        transform.up = target.transform.position - transform.position;

        try
        {
            if (transform.position == target.transform.position && currentPath.GetComponent<Path>().path.Count - 1 == nodeNumberInPath)
            {
                if (currentPath.GetComponent<Path>().nextPath.Count==0)
                {
                    //Debug.Log("nowhere to go - see you on the other side");
                    Destroy(gameObject);
                }
                var amountOfPossiblePaths = currentPath.GetComponent<Path>().nextPath.Count;
                var randomPathChoose = Random.Range(0, amountOfPossiblePaths);
                currentPath = currentPath.GetComponent<Path>().nextPath[randomPathChoose];
                nodeNumberInPath = 0;
                target = currentPath.GetComponent<Path>().path[nodeNumberInPath];
            }
            if (transform.position == target.transform.position && currentPath.GetComponent<Path>().path.Count - 1 != nodeNumberInPath)
            {
                nodeNumberInPath += 1;
                target = currentPath.GetComponent<Path>().path[nodeNumberInPath];
            }
        }
        catch { }
        try
        {
            if (transform.position == target.transform.position && currentPath.GetComponent<CurvePath>().curveNodes.Count - 1 == nodeNumberInPath)
            {
                currentPath = currentPath.GetComponent<CurvePath>().nextPath;
                nodeNumberInPath = 0;
                target = currentPath.GetComponent<Path>().path[nodeNumberInPath];
            }
            if (transform.position == target.transform.position && currentPath.GetComponent<CurvePath>().curveNodes.Count - 1 != nodeNumberInPath)
            {
                nodeNumberInPath += 1;
                target = currentPath.GetComponent<CurvePath>().curveNodes[nodeNumberInPath];
            }
        }
        catch { }
    }
}
