namespace Assets.CSharpClasses
{
    public static class Constans
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

        // Paths

        public enum NodeType
        {
            End,
            Middle,
            Start,
            Generator
        }
        
        // Delays
        public enum DelayType
        {
            Slow,
            Fast
        }

        public const float ffchance = 12.00f; //placeholder
        public const float fschance = 24.00f; //placeholder
        public const float sschance = 36.00f; //placeholder
        public const float sfchance = 28.00f; //placeholder

        public const float minFirstCarDelay = 0.42f; //placeholder
        public const float maxFirstCarDelay = 2.12f; //placeholder

        public const float minSecondCarDelay = 1.11f; //placeholder
        public const float maxSecondCarDelay = 3.02f; //placeholder

        // Simulation State
        public enum SimulationState
        {
            RoadConfiguration,
            LightConfiguration,
            SimulationRunning,
            SimulationStopped,
            SimulationFinished
        }
    }
}
