using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class dragndropInit : MonoBehaviour, IPointerDownHandler
{
    public GameObject prefabImage;

    private GameObject instantiatedPrefab;

    private bool dragMode = false;

    void Update()
    {
        if (dragMode)
        {
            UpdatePrefabPosition();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!dragMode)
        {
            var mousePosition = new Vector3(Camera.main.ScreenToViewportPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
            instantiatedPrefab = Instantiate(prefabImage, mousePosition, Quaternion.identity);
            var canva = GameObject.FindGameObjectWithTag("canvaRoads");
            canva.GetComponent<Canvas>().enabled = false;
        }
        dragMode = !dragMode;
    }

    public void OnMouseDown()
    {
        if (dragMode)
        {
            Destroy(instantiatedPrefab);
            var canva = GameObject.FindGameObjectWithTag("canvaRoads");
            canva.GetComponent<Canvas>().enabled = true;
        }
    }

    private void UpdatePrefabPosition()
    {
        if (instantiatedPrefab)
        {
            instantiatedPrefab.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        }
    }
}
