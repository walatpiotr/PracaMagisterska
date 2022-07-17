using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObserver : MonoBehaviour
{
    public GameObject lightWithEvents;
    // Start is called before the first frame update
    void Start()
    {
        LightChangerTimer events = lightWithEvents.GetComponent<LightChangerTimer>();
        events.OnLightChange += Events_OnLightChange;
    }

    private void Events_OnLightChange(object sender, LightChangerTimer.OnLightChangeEventArgs e)
    {
        Debug.Log("Zmiana: " + e.changeToState.ToString());
        
    }
}
