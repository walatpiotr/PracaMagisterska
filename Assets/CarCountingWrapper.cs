using TMPro;
using UnityEngine;

public class CarCountingWrapper : MonoBehaviour
{
    public GameObject carCounter;
    public TextMeshProUGUI simulationTime;
    public TextMeshProUGUI amountOfCars;
    public TextMeshProUGUI capacityByTime;

    public float timer = 0f;

    public void FixedUpdate()
    {
        timer += Time.deltaTime;
        var timeToMinuteRatio = 60f/timer;
        simulationTime.text = timer.ToString("0.##");
        amountOfCars.text = carCounter.GetComponent<CarCountingScript>().amountOfCarsWhichCrossedTheRoad.ToString();
        capacityByTime.text = (carCounter.GetComponent<CarCountingScript>().amountOfCarsWhichCrossedTheRoad * timeToMinuteRatio).ToString("0.##");
    }
}