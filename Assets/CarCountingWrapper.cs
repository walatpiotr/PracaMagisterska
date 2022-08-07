using TMPro;
using UnityEngine;

public class CarCountingWrapper : MonoBehaviour
{
    public GameObject carCounter;
    public TextMeshProUGUI simulationTime;
    public TextMeshProUGUI amountOfCars;
    public TextMeshProUGUI capacityByTime;

    public float timer = 0f;

    private int seconds;

    public void Start()
    {
        carCounter = GameObject.FindGameObjectWithTag("carCounter");
    }

    public void FixedUpdate()
    {
        timer += Time.deltaTime;
        var timeToMinuteRatio = 60f/timer;
        int seconds = (int)timer;
        var resultTime = string.Format("{0:00}:{1:00}", seconds / 60, seconds);
        simulationTime.text = resultTime;
        amountOfCars.text = carCounter.GetComponent<CarCountingScript>().amountOfCarsWhichCrossedTheRoad.ToString();
        capacityByTime.text = (carCounter.GetComponent<CarCountingScript>().amountOfCarsWhichCrossedTheRoad * timeToMinuteRatio).ToString("0.##");
    }
}