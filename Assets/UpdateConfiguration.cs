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

    public Configuration configObject;

    public void UpdateConfigurationButtonMethod()
    {
        configObject = GameObject.FindGameObjectWithTag("configuration").GetComponent<Configuration>();
        
        if (acceleration.text != "")
        {
            acceleration.text = acceleration.text.Replace('.', ',');
            configObject.acceleration = float.Parse(acceleration.text); Debug.Log("acceleration updated"); }
        if (breaking.text != "")
        {
            breaking.text = breaking.text.Replace('.', ',');
            configObject.breaking = float.Parse(breaking.text); Debug.Log("breaking updated"); }
        if (ffchance.text != "")
        {
            ffchance.text = ffchance.text.Replace('.', ',');
            configObject.ffchance = float.Parse(ffchance.text); Debug.Log("ffchance updated"); }
        if (fschance.text != "")
        {
            fschance.text = fschance.text.Replace('.', ',');
            configObject.fschance = float.Parse(fschance.text); Debug.Log("fschance updated"); }
        if (sschance.text != "")
        {
            sschance.text = sschance.text.Replace('.', ',');
            configObject.sschance = float.Parse(sschance.text); Debug.Log("sschance updated"); }
        if (sfchance.text != "")
        {
            sfchance.text = sfchance.text.Replace('.', ',');
            configObject.sfchance = float.Parse(sfchance.text); Debug.Log("sfchance updated"); }
        if (minFirstCarDelay.text != "")
        {
            minFirstCarDelay.text = minFirstCarDelay.text.Replace('.', ',');
            configObject.minFirstCarDelay = float.Parse(minFirstCarDelay.text); Debug.Log("minFirstCarDelay updated"); }
        if (maxFirstCarDelay.text != "")
        {
            maxFirstCarDelay.text = maxFirstCarDelay.text.Replace('.', ',');
            configObject.maxFirstCarDelay = float.Parse(maxFirstCarDelay.text); Debug.Log("maxFirstCarDelay updated"); }
        if (minSecondCarDelay.text != "")
        {
            minSecondCarDelay.text = minSecondCarDelay.text.Replace('.', ',');
            configObject.minSecondCarDelay = float.Parse(minSecondCarDelay.text); Debug.Log("minSecondCarDelay updated"); }
        if (maxSecondCarDelay.text != "")
        {
            maxSecondCarDelay.text = maxSecondCarDelay.text.Replace('.', ',');
            configObject.maxSecondCarDelay = float.Parse(maxSecondCarDelay.text); Debug.Log("maxSecondCarDelay updated"); }
        if (safeDistance.text != "")
        {
            safeDistance.text = safeDistance.text.Replace('.', ',');
            configObject.safeDistance = float.Parse(safeDistance.text); Debug.Log("safeDistance updated"); }
        if (maxVelocity.text != "")
        {
            maxVelocity.text = maxVelocity.text.Replace('.', ',');
            configObject.maxVelocity = float.Parse(maxVelocity.text); Debug.Log("maxVelocity updated"); }
        if (generatorDistance.text != "")
        {
            generatorDistance.text = generatorDistance.text.Replace('.', ',');
            configObject.generatorDistance = float.Parse(generatorDistance.text); Debug.Log("generatorDistance updated"); }
        Debug.Log("config updated");

        GameObject.FindGameObjectWithTag("configuration").GetComponent<ConfigurationValidator>().ValidateConfig();
    }
}
