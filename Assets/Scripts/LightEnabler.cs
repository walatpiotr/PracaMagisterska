using UnityEngine;

public class LightEnabler : MonoBehaviour
{
    public GameObject lightInputPrefab;
    public GameObject lightContainerPrefab;

    public GameObject lightInput = null;

    void OnMouseDown()
    {
        var lightContainer = GameObject.FindGameObjectWithTag("lightContainerTemp");
        lightContainer.GetComponent<LightParametersContainer>().lightToPopulate = this.gameObject;
        lightContainer.GetComponent<LightParametersContainer>().green.text = GetComponent<LightChangerTimer>().greenTime.ToString();
        lightContainer.GetComponent<LightParametersContainer>().yellow.text = GetComponent<LightChangerTimer>().yellowTime.ToString();
        lightContainer.GetComponent<LightParametersContainer>().red.text = GetComponent<LightChangerTimer>().redTime.ToString();
        lightContainer.GetComponent<LightParametersContainer>().offset.text = GetComponent<LightChangerTimer>().offset.ToString();
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void ChangeToValidColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
