using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCheckAndStartSimulation : MonoBehaviour
{
    public void EnableLights()
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
            //TODO text to fill all lights
            return;
        }

        foreach (var light in lights)
        {
            light.GetComponent<SpriteRenderer>().color = Color.white;
            light.GetComponent<LightChangerTimer>().isValid = true;
        }
    }
}
