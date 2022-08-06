using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfigLoader : MonoBehaviour
{
    public TextMeshProUGUI configText;
    public string propertyName;

    public void FixedUpdate()
    {
        var configObject = GameObject.FindGameObjectWithTag("configuration").GetComponent<Configuration>();
        switch (propertyName)
        {
            case "acceleration":
                configText.text = configObject.acceleration.ToString();
                break;
            case "breaking":
                configText.text = configObject.breaking.ToString();
                break;
            case "ffchance":
                configText.text = configObject.ffchance.ToString();
                break;
            case "fschance":
                configText.text = configObject.fschance.ToString();
                break;
            case "sschance":
                configText.text = configObject.sschance.ToString();
                break;
            case "sfchance":
                configText.text = configObject.sfchance.ToString();
                break;
            case "minFirstCarDelay":
                configText.text = configObject.minFirstCarDelay.ToString();
                break;
            case "maxFirstCarDelay":
                configText.text = configObject.maxFirstCarDelay.ToString();
                break;
            case "minSecondCarDelay":
                configText.text = configObject.minSecondCarDelay.ToString();
                break;
            case "maxSecondCarDelay":
                configText.text = configObject.maxSecondCarDelay.ToString();
                break;
            case "safeDistance":
                configText.text = configObject.safeDistance.ToString();
                break;
            case "maxVelocity":
                configText.text = configObject.maxVelocity.ToString();
                break;
            case "generatorDistance":
                configText.text = configObject.generatorDistance.ToString();
                break;
        }
    }
}
