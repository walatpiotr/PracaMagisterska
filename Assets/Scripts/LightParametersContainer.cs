using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class LightParametersContainer : MonoBehaviour
{
    public GameObject lightToPopulate;

    public TMP_InputField green;
    public TMP_InputField yellow;
    public TMP_InputField red;
    public TMP_InputField offset;

    public GameObject lightCopyContainer;

    public void OnCopyButtonClick()
    {
        if (Validate())
        {
            var container = lightCopyContainer.GetComponent<LightParametersCopyConatiner>();
            container.green = float.Parse(green.text);
            container.yellow = float.Parse(yellow.text);
            container.red = float.Parse(red.text);
            container.offfset = float.Parse(offset.text);
        }
    }

    public void OnPasteButtonClick()
    {
        if (Validate())
        {
            var container = lightCopyContainer.GetComponent<LightParametersCopyConatiner>();
            green.text = container.green.ToString();
            yellow.text = container.yellow.ToString();
            red.text = container.red.ToString();
            offset.text = container.offfset.ToString();
        }
    }

    public void OnApplyButtonClick()
    {
        if (Validate())
        {
            Debug.Log("validated");
            lightToPopulate.GetComponent<LightChangerTimer>().greenTime = float.Parse(green.text);
            lightToPopulate.GetComponent<LightChangerTimer>().yellowTime = float.Parse(yellow.text);
            lightToPopulate.GetComponent<LightChangerTimer>().redTime = float.Parse(red.text);
            lightToPopulate.GetComponent<LightChangerTimer>().offset = float.Parse(offset.text);
            lightToPopulate.GetComponent<LightEnabler>().ChangeToValidColor();
        }
        Debug.Log("applied");
    }

    public void OnApplyRoadButtonClick()
    {
        // TODO
    }

    private bool Validate()
    {
        var listOfVars = new List<TMP_InputField>() { green, yellow, red, offset };
        foreach (var tmp in listOfVars)
        {
            int errors = 0;
            try
            {
                float.Parse(tmp.text);
            }
            catch
            {
                Debug.Log("not good format");
                errors += 1;
            }

            if (float.Parse(tmp.text) <= 0.0f)
            {
                Debug.Log("must be more than 0");
                errors += 1;
            }

            if (errors > 0)
            {
                return false;
            }
        }

        return true;
    }
}
