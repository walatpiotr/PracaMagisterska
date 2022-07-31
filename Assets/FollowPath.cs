using Assets.Scripts;
using Assets.Scripts.Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject currentPath;
    public GameObject target;
    public int nodeNumberInPath=0;

    public List<GameObject> wholePath;

    private int middlePointsTargeted = 0;
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, gameObject.GetComponent<CarValueContainer>().velocity * Time.deltaTime);
        transform.up = target.transform.position - transform.position;
        
        if(Vector2.Distance(transform.position, target.transform.position)<0.1f)
        {
            if(nodeNumberInPath < wholePath.Count - 1)
            {
                if (target.GetComponent<Node>().type == Assets.CSharpClasses.Constans.NodeType.Middle)
                {
                    GetComponent<CarBehaviourBase>().Accelerate();
                }
                nodeNumberInPath += 1;
                target = wholePath[nodeNumberInPath];
                
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void CalculatePredeterminedPath()
    {
        foreach (var node in currentPath.GetComponent<Path>().path)
        {
            wholePath.Add(node);
        }
        var amountOfPossiblePaths = currentPath.GetComponent<Path>().nextPath.Count;
        var randomPathChoose = Random.Range(0, amountOfPossiblePaths);
        var curvePath = currentPath.GetComponent<Path>().nextPath[randomPathChoose];
        foreach (var node in curvePath.GetComponent<CurvePath>().curveNodes)
        {
            wholePath.Add(node);
        }
        foreach (var node in curvePath.GetComponent<CurvePath>().nextPath.GetComponent<Path>().path)
        {
            wholePath.Add(node);
        }

    }
}
