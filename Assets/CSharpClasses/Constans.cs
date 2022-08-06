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
