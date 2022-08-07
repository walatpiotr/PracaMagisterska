using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationReset : MonoBehaviour
{
    public void SimulationReseting()
    {
        var cars = GameObject.FindGameObjectsWithTag("car");
        foreach(var car in cars)
        {
            Destroy(car);
        }

        var lights = GameObject.FindGameObjectsWithTag("light");
        foreach (var light in lights)
        {
            var lightScript = light.GetComponent<LightChangerTimer>();
            lightScript.timer = lightScript.offset;
            lightScript.currentState = LightChangerTimer.State.Offset;
            lightScript.ChangeSprite();
        }

        this.gameObject.GetComponent<CarCountingWrapper>().timer = 0f;

        GameObject.FindGameObjectWithTag("carCounter").GetComponent<CarCountingScript>().amountOfCarsWhichCrossedTheRoad = 0;
    }
}
