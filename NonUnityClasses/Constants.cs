namespace NonUnityClasses
{
    public static class Constants
    {
        public enum CarStates
        {
            Breaking,
            WaitingForGreen,
            Stop,
            Accelerating,
            FollowingPath,
            FollowingNextCar
        }

        public const float acceleration = 1.0f;
        public const float breaking = 2.0f;

        public const float minFirstCarDelay = 9.99f; //placeholder
        public const float maxFirstCarDelay = 9.99f; //placeholder

        public const float minSecondCarDelay = 9.99f; //placeholder
        public const float maxSecondCarDelay = 9.99f; //placeholder
    }
}
