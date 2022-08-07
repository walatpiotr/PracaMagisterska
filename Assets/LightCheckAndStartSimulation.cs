using Assets.CSharpClasses;
using System;
using UnityEngine;

public class LightCheckAndStartSimulation : MonoBehaviour
{
    public bool EnableLights()
    {
        var lights = GameObject.FindGameObjectsWithTag("light");

        try
        {
            foreach (var light in lights)
            {
                if (light.GetComponent<SpriteRenderer>().color != Color.blue)
                {
                    throw new Exception("not all valid");
                }
            }
        }
        catch
        {
            return false;
        }

        foreach (var light in lights)
        {
            light.GetComponent<SpriteRenderer>().color = Color.white;
            light.GetComponent<LightChangerTimer>().isValid = true;
        }

        return true;
    }

    public void StartSimulation()
    {
        if (EnableLights())
        {
            SetupGenerators();
            SetupCanvas();
            SetupSimulationManager();

        }
    }

    public void SetupGenerators()
    {
        var generators = GameObject.FindGameObjectsWithTag("generator");
        var ends = GameObject.FindGameObjectsWithTag("nodeEnd");
        foreach (var generator in generators)
        {
            generator.GetComponent<CarGeneration>().Trigger();
        }
    }

    public void SetupCanvas()
    {
        var canvaRoadsChildrenCount = GameObject.FindGameObjectWithTag("canvaSimulation").gameObject.transform.childCount;
        for (int i = 0; i < canvaRoadsChildrenCount; i++)
        {
            GameObject.FindGameObjectWithTag("canvaSimulation").gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }

        var canvaLightsChildrenCount = GameObject.FindGameObjectWithTag("canvaLights").gameObject.transform.childCount;
        for (int i = 0; i < canvaLightsChildrenCount; i++)
        {
            GameObject.FindGameObjectWithTag("canvaLights").gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SetupSimulationManager()
    {
        // Components changes needed for lights configuration
        GameObject.FindGameObjectWithTag("simulationManager").GetComponent<SimulationState>().simulationState = Constans.SimulationState.SimulationRunning;
        GameObject.FindGameObjectWithTag("simulationManager").GetComponent<CarCountingWrapper>().timer = 0f;
    }
}
