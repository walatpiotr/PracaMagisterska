using Assets.CSharpClasses;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObserver : MonoBehaviour
{
    public CarValueContainer valueContainer;
    public float minDistanceToLight=1000000f;
    public GameObject lightWithEvents;
    protected LightChangerTimer events;

    public LightChangerTimer.State currentLightState;

    void Start()
    {
        currentLightState = lightWithEvents.GetComponent<LightChangerTimer>().currentState;
        valueContainer = gameObject.GetComponent<CarValueContainer>();
        events = lightWithEvents.GetComponent<LightChangerTimer>();
        events.OnLightChange += Events_OnLightChange;
    }

    private void Events_OnLightChange(object sender, LightChangerTimer.OnLightChangeEventArgs e)
    {
        if (e.changeToState.ToString() == LightChangerTimer.State.Green.ToString())
        {
            currentLightState = lightWithEvents.GetComponent<LightChangerTimer>().currentState;
            if (GetComponent<CarValueContainer>().velocity <= 0f)
            {
                WaitIfNeededAndStart();
            }
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.Yellow.ToString())
        {
            currentLightState = lightWithEvents.GetComponent<LightChangerTimer>().currentState;
        }

        if (e.changeToState.ToString() == LightChangerTimer.State.Red.ToString())
        {
            currentLightState = lightWithEvents.GetComponent<LightChangerTimer>().currentState;

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

        if (e.changeToState.ToString() == LightChangerTimer.State.YellowRed.ToString())
        {
            currentLightState = lightWithEvents.GetComponent<LightChangerTimer>().currentState;
            var tuple = GameObject.FindGameObjectWithTag("delayGenerator").GetComponent<DelayNumbersGenerator>().GenerateDelayTimes();
            GetComponent<CarValueContainer>().firstCarOffset = tuple.Item1.Item1;
            GetComponent<CarValueContainer>().secondCarOffset = tuple.Item2.Item1;
        }
    }

    private void FixedUpdate()
    {
        var updatedStart = GetComponent<Detection>().startObject.transform.position;
        var detectionLength = ((valueContainer.velocity) * (valueContainer.velocity)) / (2f * valueContainer.breakValue) + valueContainer.safeDistance;

        var distanceToLight = Vector2.Distance(updatedStart, lightWithEvents.transform.position);

        if (currentLightState != LightChangerTimer.State.Green)
        {
            CheckDistanceToLight(distanceToLight, detectionLength);
        }
        if (distanceToLight < 0.1f)
        {
            GetComponent<Detection>().isDetectionOn = false;
        }
        if (distanceToLight < minDistanceToLight)
        {
            minDistanceToLight = distanceToLight;
        }
        if( distanceToLight > minDistanceToLight)
        {
            events.OnLightChange -= Events_OnLightChange;
            GetComponent<LightObserver>().enabled = false;
        }
    }

    private void CheckDistanceToLight(float distanceToLight, float detectionLength)
    {
        if (distanceToLight < detectionLength)
        {
            if (currentLightState == LightChangerTimer.State.Red)
            {
                GetComponent<CarBehaviourBase>().NoDetectionUnSub();
                GetComponent<CarBehaviourBase>().Break();
            }
            if (currentLightState == LightChangerTimer.State.Yellow)
            {
                if ((distanceToLight / valueContainer.velocity) >= lightWithEvents.GetComponent<LightChangerTimer>().timer)
                {
                    Debug.Log((distanceToLight / valueContainer.velocity));
                    GetComponent<CarBehaviourBase>().NoDetectionUnSub();
                    GetComponent<CarBehaviourBase>().Break();
                }
            }
            if (currentLightState == LightChangerTimer.State.Offset)
            {
                GetComponent<CarBehaviourBase>().NoDetectionUnSub();
                GetComponent<CarBehaviourBase>().Break();
            }
        }
        if (distanceToLight < valueContainer.safeDistance)
        {
            if (currentLightState == LightChangerTimer.State.Red)
            {
                Debug.Log("zatrzymuje sie przy czerwonym");
                GetComponent<CarBehaviourBase>().NoDetectionUnSub();
                GetComponent<CarBehaviourBase>().KeepVelocity(0f);
            }
            if (currentLightState == LightChangerTimer.State.Offset)
            {
                GetComponent<CarBehaviourBase>().NoDetectionUnSub();
                GetComponent<CarBehaviourBase>().KeepVelocity(0f);
            }
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

        //Debug.Log("waited: "+ offset);
        GetComponent<CarBehaviourBase>().NoDetectionSub();
        GetComponent<CarValueContainer>().carAhead = null;
        GetComponent<CarBehaviourBase>().Accelerate();
        //GetComponent<Detection>().isDetectionOn = false;
    }
}
