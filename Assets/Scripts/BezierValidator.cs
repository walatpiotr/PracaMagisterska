using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Pathing;
using System;

public class BezierValidator : MonoBehaviour
{
    public List<GameObject> roads;
    public List<GameObject> beziers;
    public List<Tuple<GameObject, GameObject>> tempBeziers = new List<Tuple<GameObject, GameObject>>();
    public List<GameObject> wrongBeziers = new List<GameObject>();

    public GameObject curvePathPrefab;
    public GameObject nodeCurvePathPrefab;

    public void Validate()
    {
        roads = GameObject.FindGameObjectsWithTag("road").ToList();
        beziers = GameObject.FindGameObjectsWithTag("bezierCurve").ToList();

        if (beziers.Count == 0 || roads.Count == 0)
        {
            //TODO - throw error
        }

        tempBeziers = new List<Tuple<GameObject, GameObject>>();
        wrongBeziers = new List<GameObject>();
        CheckStartToEndConnections();
    }

    private void CheckStartToEndConnections()
    {

        foreach (GameObject bezier in beziers)
        {
            
            foreach (GameObject bezierInside in beziers)
            {
                if (bezier.GetComponent<Bezier>().start == bezierInside.GetComponent<Bezier>().start && bezier != bezierInside)
                {
                    if(bezier.GetComponent<Bezier>().end.transform.parent.parent.GetComponent<Road>().roadId== bezierInside.GetComponent<Bezier>().end.transform.parent.parent.GetComponent<Road>().roadId)
                    {
                        tempBeziers.Add(new Tuple<GameObject, GameObject>(bezier, bezierInside));
                    }
                }
            }
        }
        
        foreach (Tuple<GameObject,GameObject> tuple in tempBeziers)
        {
            if( !wrongBeziers.Contains(tuple.Item1))
            {
                wrongBeziers.Add(tuple.Item1);
            }

            if (!wrongBeziers.Contains(tuple.Item2))
            {
                wrongBeziers.Add(tuple.Item2);
            }
        }

        if (wrongBeziers.Count != 0)
        {
            VisualizeWrongConnections();
        }
        else
        {
            foreach(GameObject bezier in beziers)
            {
                var curvePath = Instantiate(curvePathPrefab, bezier.transform.position, Quaternion.identity);
                foreach (var node in bezier.GetComponent<Bezier>().positions)
                {
                    var nodeInstantiated = Instantiate(nodeCurvePathPrefab, node, Quaternion.identity);
                    curvePath.GetComponent<CurvePath>().curveNodes.Add(nodeInstantiated);
                    nodeInstantiated.transform.parent = curvePath.transform;
                }
                curvePath.GetComponent<LineRenderer>().positionCount = bezier.GetComponent<Bezier>().numOfPoints;
                curvePath.GetComponent<LineRenderer>().SetPositions(bezier.GetComponent<Bezier>().positions);

                bezier.GetComponent<Bezier>().end.transform.parent.GetComponent<Path>().nextPath.Add(curvePath);
                curvePath.GetComponent<CurvePath>().nextPath = bezier.GetComponent<Bezier>().start.transform.parent.gameObject;
                Destroy(bezier);
            }
        }
    }

    private void VisualizeWrongConnections()
    {
        foreach(GameObject bezier  in wrongBeziers)
        {
            bezier.GetComponent<Bezier>().instantiatedPrefab.GetComponent<CurvePointMove>().notValid = true;
        }
    }
}
