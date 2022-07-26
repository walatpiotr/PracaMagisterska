using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObserver : MonoBehaviour
{
    public CarValueContainer valueContainer;

    public GameObject lightWithEvents;
    protected LightChangerTimer events;

    void Start()
    {
        valueContainer = gameObject.GetComponent<CarValueContainer>();
        events = lightWithEvents.GetComponent<LightChangerTimer>();
        events.OnLightChange += Events_OnLightChange;
    }

    private void Events_OnLightChange(object sender, LightChangerTimer.OnLightChangeEventArgs e)
    {
        if (e.changeToState.ToString() == LightChangerTimer.State.Green.ToString())
        {
            //Debug.Log("czas ruszaæ: "+GetComponent<Detection>().identifier);
            GetComponent<CarBehaviourBase>().NoDetectionSub();
            GetComponent<CarValueContainer>().carAhead = null;
            GetComponent<CarBehaviourBase>().Accelerate();
            GetComponent<Detection>().isDetectionOn = false;
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.Yellow.ToString())
        {
            //Debug.Log("czas zwalniaæ");
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.Red.ToString())
        {
            //Debug.Log("nie ruszaj siê");
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.YellowRed.ToString())
        {
            //Debug.Log("nadal nie ruszaj siê");
        }
    }

    private void FixedUpdate()
    {
        if (valueContainer.carAhead == null && lightWithEvents.GetComponent<LightChangerTimer>().currentState != LightChangerTimer.State.Green)
        {
            CheckDistanceToLight();
            Debug.Log("checking distance to light");
        }
    }

    private void CheckDistanceToLight()
    {
        var updatedStart = GetComponent<Detection>().startPoint + new Vector2(transform.position.x, transform.position.y);
        var detectionLength = ((valueContainer.velocity) * (valueContainer.velocity)) / (2f * valueContainer.breakValue) + valueContainer.safeDistance;

        var distanceToLight = Vector2.Distance(updatedStart, lightWithEvents.transform.position);

        if (distanceToLight < detectionLength)
        {
            GetComponent<CarBehaviourBase>().NoDetectionUnSub();
            GetComponent<CarBehaviourBase>().Break();
        }
        if (distanceToLight < valueContainer.safeDistance)
        {
            GetComponent<CarBehaviourBase>().NoDetectionUnSub();
            GetComponent<CarBehaviourBase>().Break();
        }
    }

    private void OnDestroy()
    {
        events.OnLightChange -= Events_OnLightChange;
    }
}
