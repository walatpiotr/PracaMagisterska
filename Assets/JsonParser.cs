using Newtonsoft.Json;
using System;
using System.IO;
using TMPro;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("config/config.json"))
        {
            string json = r.ReadToEnd();
            Configuration config = JsonConvert.DeserializeObject<Configuration>(json);
            var configObject = GameObject.FindGameObjectWithTag("configuration").GetComponent<Configuration>();

            configObject.acceleration = config.acceleration;
            configObject.breaking = config.breaking;

            configObject.ffchance = config.ffchance;
            configObject.fschance = config.fschance;
            configObject.sschance = config.sschance;
            configObject.sfchance = config.sfchance;

            configObject.minFirstCarDelay = config.minFirstCarDelay;
            configObject.maxFirstCarDelay = config.maxFirstCarDelay;

            configObject.minSecondCarDelay = config.minSecondCarDelay;
            configObject.maxSecondCarDelay = config.maxSecondCarDelay;

            configObject.safeDistance = config.safeDistance;
            configObject.maxVelocity = config.maxVelocity;
            configObject.generatorDistance = config.generatorDistance;
        }
    }
}
