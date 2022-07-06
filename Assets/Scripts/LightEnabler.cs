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

        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 19f);
        /*if (lightInput == null)
        {
            Debug.Log("clicked");
            lightInput = Instantiate(lightInputPrefab, transform.position, Quaternion.identity);
            lightInput.transform.parent = GameObject.Find("Canvas").transform;
            lightInput.GetComponent<LightParametersContainer>().lightToPopulate = this.gameObject;
            lightInput.GetComponent<RectTransform>().sizeDelta = lightInputPrefab.GetComponent<RectTransform>().sizeDelta;
            lightInput.GetComponent<RectTransform>().localScale = lightInputPrefab.GetComponent<RectTransform>().localScale;
            lightInput.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        }*/
    }

    void OnExitButtonClick()
    {
        Destroy(lightInput);
        lightInput = null;
    }
}
