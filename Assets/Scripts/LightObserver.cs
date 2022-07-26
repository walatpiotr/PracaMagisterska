using Assets.CSharpClasses;
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
            Debug.Log("czas ruszaæ: "+GetComponent<Detection>().identifier);
            WaitIfNeededAndStart();
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

            var tuple = GameObject.FindGameObjectWithTag("delayGenerator").GetComponent<DelayNumbersGenerator>().GenerateDelayTimes();
            GetComponent<CarValueContainer>().firstCarOffset = tuple.Item1.Item1;
            GetComponent<CarValueContainer>().secondCarOffset = tuple.Item2.Item1;
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
            GetComponent<CarBehaviourBase>().KeepVelocity(0f);
        }
    }

    private void OnDestroy()
    {
        events.OnLightChange -= Events_OnLightChange;
    }

    private void WaitIfNeededAndStart()
    {
        float offset;
        if (valueContainer.carAhead)
        {
            offset = valueContainer.carAhead.GetComponent<CarValueContainer>().firstCarOffset + valueContainer.carAhead.GetComponent<CarValueContainer>().secondCarOffset;
        }
        else
        {
            offset = valueContainer.firstCarOffset;
        }
        StartCoroutine(WaitOffset(offset));
    }

    private IEnumerator WaitOffset(float offset)
    {
        yield return new WaitForSeconds(offset);

        Debug.Log("waited");
        GetComponent<CarBehaviourBase>().NoDetectionSub();
        GetComponent<CarValueContainer>().carAhead = null;
        GetComponent<CarBehaviourBase>().Accelerate();
        GetComponent<Detection>().isDetectionOn = false;
    }
}
