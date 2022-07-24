using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObserver : MonoBehaviour
{
    public GameObject lightWithEvents;

    void Start()
    {
        LightChangerTimer events = lightWithEvents.GetComponent<LightChangerTimer>();
        events.OnLightChange += Events_OnLightChange;
    }

    private void Events_OnLightChange(object sender, LightChangerTimer.OnLightChangeEventArgs e)
    {
        if (e.changeToState.ToString() == LightChangerTimer.State.Green.ToString())
        {
            Debug.Log("czas ruszaæ");
            // TODO - logic to other component
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.Yellow.ToString())
        {
            Debug.Log("czas zwalniaæ");
            // TODO - logic to other component
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.Red.ToString())
        {
            Debug.Log("nie ruszaj siê");
            // TODO - logic to other component
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.YellowRed.ToString())
        {
            Debug.Log("nadal nie ruszaj siê");
            // TODO - logic to other component
        }
    }
}
