using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ConfigurationValidator : MonoBehaviour
{
    public TextMeshProUGUI errorMessage;

    public GameObject textPrefab;


    public void Start()
    {
        errorMessage = GameObject.FindGameObjectWithTag("main_menu_error_text").GetComponent<TextMeshProUGUI>();

        if (!errorMessage)
        {
            Instantiate(textPrefab, GameObject.FindGameObjectWithTag("mainCanvas").transform);
        }
    }

    public bool ValidateConfig()
    {
        errorMessage = GameObject.FindGameObjectWithTag("main_menu_error_text").GetComponent<TextMeshProUGUI>();

        if (!errorMessage)
        {
            Instantiate(textPrefab, GameObject.FindGameObjectWithTag("mainCanvas").transform);
        }

        var conf = GetComponent<Configuration>();
        string error = "";
        if ((conf.ffchance + conf.fschance + conf.sschance + conf.sfchance) != 100f)
            error += "chances must add to 100% \n";
        if (conf.maxVelocity < conf.acceleration)
            error += "max velocity must be greater than acceleration \n";
        var fieldValues = conf.GetType()
                     .GetFields()
                     .Select(field => field.GetValue(conf))
                     .ToList();
        var fieldNames = conf.GetType()
                     .GetFields()
                     .Select(field => field.Name)
                     .ToList();
        Debug.Log(fieldNames);
        if (conf.maxFirstCarDelay <= conf.minFirstCarDelay || conf.maxSecondCarDelay <= conf.minSecondCarDelay)
            error += "max delay value must be greater than min delay value \n";

        int i = 0;
        foreach(var variable in fieldValues)
        {
            if (float.Parse(variable.ToString()) < 0f)
            {
                error += fieldNames[i] + " cannot be less than 0 \n";
            }
            i++;
        }

        errorMessage.text = error;

        if (error != "")
        {
            return false;
        }

        return true;
    }
}
