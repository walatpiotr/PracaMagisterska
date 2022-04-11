﻿using System;
using static NonUnityClasses.Constants;

namespace NonUnityClasses
{
    public class DelayNumbersGenerator
    {
        public Tuple<Tuple<float, DelayType>, Tuple<float, DelayType>> GenerateDelayTimes()
        {
            return GenerateTimesBySituation(GenerateSituation());
        }

        private Tuple<DelayType, DelayType> GenerateSituation()
        {
            // TODO
            // generate one out of four possible situations:
            // slow-slow ; slow-fast ; fast-slow ; fast-fast
            return null;
        }

        private Tuple<Tuple<float, DelayType>, Tuple<float, DelayType>> GenerateTimesBySituation(Tuple<DelayType, DelayType> generatedSituation)
        {
            var timeFirst = GenerateTimeForFirstCar(generatedSituation.Item1);
            var timeSecond = GenerateTimeForSecondCar(generatedSituation.Item2);

            return new Tuple<Tuple<float, DelayType>, Tuple<float, DelayType>>(
                new Tuple<float, DelayType>(timeFirst, generatedSituation.Item1),
                new Tuple<float, DelayType>(timeSecond, generatedSituation.Item2));
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
