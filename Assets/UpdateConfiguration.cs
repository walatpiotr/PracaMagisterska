using TMPro;
using UnityEngine;

public class UpdateConfiguration : MonoBehaviour
{
    public TMP_InputField ffchance;
    public TMP_InputField fschance;
    public TMP_InputField sschance;
    public TMP_InputField sfchance;
    public TMP_InputField minFirstCarDelay;
    public TMP_InputField maxFirstCarDelay;
    public TMP_InputField minSecondCarDelay;
    public TMP_InputField maxSecondCarDelay;
    public TMP_InputField safeDistance;
    public TMP_InputField breaking;
    public TMP_InputField acceleration;
    public TMP_InputField generatorDistance;
    public TMP_InputField maxVelocity;
    
    public void UpdateConfigurationButtonMethod()
    {
        var configObject = GameObject.FindGameObjectWithTag("configuration").GetComponent<Configuration>();

        if (acceleration.text != "")
        { configObject.acceleration = float.Parse(acceleration.text); }
        if (acceleration.text != "")
        { configObject.breaking = float.Parse(breaking.text); }
        if (acceleration.text != "")
        { configObject.ffchance = float.Parse(ffchance.text); }
        if (acceleration.text != "")
        { configObject.fschance = float.Parse(fschance.text); }
        if (acceleration.text != "")
        { configObject.sschance = float.Parse(sschance.text); }
        if (acceleration.text != "")
        { configObject.sfchance = float.Parse(sfchance.text); }
        if (acceleration.text != "")
        { configObject.minFirstCarDelay = float.Parse(minFirstCarDelay.text); }
        if (acceleration.text != "")
        { configObject.maxFirstCarDelay = float.Parse(maxFirstCarDelay.text); }
        if (acceleration.text != "")
        { configObject.minSecondCarDelay = float.Parse(minSecondCarDelay.text); }
        if (acceleration.text != "")
        { configObject.maxSecondCarDelay = float.Parse(maxSecondCarDelay.text); }
        if (acceleration.text != "")
        { configObject.safeDistance = float.Parse(safeDistance.text); }
        if (acceleration.text != "")
        { configObject.maxVelocity = float.Parse(maxVelocity.text); }
        if (acceleration.text != "")
        { configObject.generatorDistance = float.Parse(generatorDistance.text); }
    }
}
