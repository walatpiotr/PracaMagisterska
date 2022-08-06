using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.Pathing;
using System;
using Assets.CSharpClasses;

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
                SetupComponentsAfterChange();
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

    private void SetupComponentsAfterChange()
    {
        // Components changes needed for lights configuration
        GameObject.FindGameObjectWithTag("simulationManager").GetComponent<SimulationState>().simulationState = Constans.SimulationState.LightConfiguration;

        var endNodes = GameObject.FindGameObjectsWithTag("nodeEnd");
        var startNodes = GameObject.FindGameObjectsWithTag("nodeStart");
        foreach (var node in endNodes)
        {
            node.GetComponent<CircleCollider2D>().enabled = false;
            node.GetComponent<SpriteRenderer>().enabled = false;

            if (node.transform.parent.GetComponent<Path>().nextPath.Count != 0)
            {
                node.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        foreach (var node in startNodes)
        {
            node.GetComponent<CircleCollider2D>().enabled = false;
            node.GetComponent<SpriteRenderer>().enabled = false;
        }
        var roads = GameObject.FindGameObjectsWithTag("road");
        foreach (var road in roads)
        {
            road.GetComponent<BoxCollider2D>().enabled = false;
            road.GetComponent<EditPostion>().enabled = false;
        }

        var canvaRoadsChildrenCount = GameObject.FindGameObjectWithTag("canvaRoads").gameObject.transform.childCount;
        for (int i=0; i<canvaRoadsChildrenCount; i++)
        {
            GameObject.FindGameObjectWithTag("canvaRoads").gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }

        var canvaLightsChildrenCount = GameObject.FindGameObjectWithTag("canvaLights").gameObject.transform.childCount;
        for (int i = 0; i < canvaLightsChildrenCount; i++)
        {
            GameObject.FindGameObjectWithTag("canvaLights").gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
