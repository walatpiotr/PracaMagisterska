using UnityEngine;
using TMPro;

public class LightParametersContainer : MonoBehaviour
{
    public GameObject lightToPopulate;
    public TMP_InputField green;
    public TMP_InputField yellow;
    public TMP_InputField offfset;

    public void OnButtonDown()
    {
        lightToPopulate.GetComponent<LightChangerTimer>().greenTime = float.Parse(green.text);
        lightToPopulate.GetComponent<LightChangerTimer>().yellowTime = float.Parse(yellow.text);
        lightToPopulate.GetComponent<LightChangerTimer>().offset = float.Parse(offfset.text);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            lightToPopulate.GetComponent<LightChangerTimer>().greenTime = float.Parse(green.text);
            lightToPopulate.GetComponent<LightChangerTimer>().yellowTime = float.Parse(yellow.text);
            lightToPopulate.GetComponent<LightChangerTimer>().offset = float.Parse(offfset.text);
            lightToPopulate.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
        }
    }
}
