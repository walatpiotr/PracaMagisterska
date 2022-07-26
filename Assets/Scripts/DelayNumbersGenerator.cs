using System;
using UnityEngine;
using static Assets.CSharpClasses.Constans;

namespace Assets.CSharpClasses
{
    public class DelayNumbersGenerator : MonoBehaviour
    {
        float firstTreshold = ffchance;
        float secondTreshold = ffchance + fschance;
        float thirdTreshold = ffchance + fschance + sschance;
        float forthTreshold = ffchance + fschance + sschance + sfchance;

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
                    return UnityEngine.Random.Range(minFirstCarDelay, maxFirstCarDelay);
                case DelayType.Slow:
                    return UnityEngine.Random.Range(minFirstCarDelay, maxFirstCarDelay);
            }

            return 0f;
        }

        private float GenerateTimeForSecondCar(DelayType delayType)
        {
            switch (delayType)
            {
                // TODO - decide or read where border of slow and fast is
                case DelayType.Fast:
                    return UnityEngine.Random.Range(minSecondCarDelay, maxSecondCarDelay);
                case DelayType.Slow:
                    return UnityEngine.Random.Range(minSecondCarDelay, maxSecondCarDelay);
            }

            return 0f;
        }
    }
}
