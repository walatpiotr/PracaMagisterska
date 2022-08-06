using System;
using UnityEngine;
using static Assets.CSharpClasses.Constans;

public class DelayNumbersGenerator : MonoBehaviour
{
    public float firstTreshold;
    public float secondTreshold;
    public float thirdTreshold;
    public float forthTreshold;

    public GameObject config;

    public void Start()
    {
        config = GameObject.FindGameObjectWithTag("configuration");
        firstTreshold = config.GetComponent<Configuration>().ffchance;
        secondTreshold = config.GetComponent<Configuration>().ffchance + config.GetComponent<Configuration>().fschance;
        thirdTreshold = config.GetComponent<Configuration>().ffchance + config.GetComponent<Configuration>().fschance + config.GetComponent<Configuration>().sschance;
        forthTreshold = config.GetComponent<Configuration>().ffchance + config.GetComponent<Configuration>().fschance + config.GetComponent<Configuration>().sschance + config.GetComponent<Configuration>().sfchance;
    }

    public Tuple<Tuple<float, DelayType>, Tuple<float, DelayType>> GenerateDelayTimes()
    {
        return GenerateTimesBySituation(GenerateSituation());
    }

    private Tuple<Tuple<float, DelayType>, Tuple<float, DelayType>> GenerateTimesBySituation(Tuple<DelayType, DelayType> generatedSituation)
    {
        var timeFirst = GenerateTimeForFirstCar(generatedSituation.Item1);
        var timeSecond = GenerateTimeForSecondCar(generatedSituation.Item2);

        return new Tuple<Tuple<float, DelayType>, Tuple<float, DelayType>>(
            new Tuple<float, DelayType>(timeFirst, generatedSituation.Item1),
            new Tuple<float, DelayType>(timeSecond, generatedSituation.Item2));
    }

    private Tuple<DelayType, DelayType> GenerateSituation()
    {
        float randomNumber = UnityEngine.Random.Range(0.0f, 100.0f);

        if (randomNumber < firstTreshold)
        {
            return new Tuple<DelayType, DelayType>(DelayType.Fast, DelayType.Fast);
        }
        else if (randomNumber < secondTreshold)
        {
            return new Tuple<DelayType, DelayType>(DelayType.Fast, DelayType.Slow);
        }
        else if (randomNumber < thirdTreshold)
        {
            return new Tuple<DelayType, DelayType>(DelayType.Slow, DelayType.Slow);
        }
        else if (randomNumber < forthTreshold)
        {
            return new Tuple<DelayType, DelayType>(DelayType.Slow, DelayType.Fast);
        }
        else
        {
            return null;
        }
    }

    private float GenerateTimeForFirstCar(DelayType delayType)
    {
        switch (delayType)
        {
            // TODO - decide or read where border of slow and fast is
            case DelayType.Fast:
                return UnityEngine.Random.Range(config.GetComponent<Configuration>().minFirstCarDelay, config.GetComponent<Configuration>().maxFirstCarDelay);
            case DelayType.Slow:
                return UnityEngine.Random.Range(config.GetComponent<Configuration>().minFirstCarDelay, config.GetComponent<Configuration>().maxFirstCarDelay);
        }

        return 0f;
    }

    private float GenerateTimeForSecondCar(DelayType delayType)
    {
        switch (delayType)
        {
            // TODO - decide or read where border of slow and fast is
            case DelayType.Fast:
                return UnityEngine.Random.Range(config.GetComponent<Configuration>().minSecondCarDelay, config.GetComponent<Configuration>().maxSecondCarDelay);
            case DelayType.Slow:
                return UnityEngine.Random.Range(config.GetComponent<Configuration>().minSecondCarDelay, config.GetComponent<Configuration>().maxSecondCarDelay);
        }

        return 0f;
    }
}
