namespace NonUnityClasses
{
    public static class Constants
    {
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

        public enum DelayType
        {
            Slow,
            Fast
        }

        public const float acceleration = 1.0f;
        public const float breaking = 2.0f;

        public const float minFirstCarDelay = 9.99f; //placeholder
        public const float maxFirstCarDelay = 9.99f; //placeholder

        public const float minSecondCarDelay = 9.99f; //placeholder
        public const float maxSecondCarDelay = 9.99f; //placeholder
    }
}
