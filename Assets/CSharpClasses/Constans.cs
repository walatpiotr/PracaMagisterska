using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CSharpClasses
{
    public class Constans
    {
        // Vehicles
        public enum CarStates
        {
            Breaking,
            WaitingForGreenFirst,
            WaitingForGreenSecond,
            Stop,
            Accelerating,
            FollowingPath,
            FollowingNextCar,
            Init
        }

        public const float acceleration = 1.0f;
        public const float breaking = 2.0f;

        // Delays
        public enum DelayType
        {
            Slow,
            Fast
        }

        public const float ffchance = 9.99f; //placeholder
        public const float fschance = 9.99f; //placeholder
        public const float sschance = 9.99f; //placeholder
        public const float sfchance = 9.99f; //placeholder

        public const float minFirstCarDelay = 9.99f; //placeholder
        public const float maxFirstCarDelay = 9.99f; //placeholder

        public const float minSecondCarDelay = 9.99f; //placeholder
        public const float maxSecondCarDelay = 9.99f; //placeholder
    }
}
