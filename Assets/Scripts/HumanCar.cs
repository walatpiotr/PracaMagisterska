using static Assets.CSharpClasses.Constans;

namespace Assets.Scripts
{
    public class HumanCar : CarBehaviourBase
    {
        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            switch (currentState)
            {
                case CarStates.Init:
                    break;
                case CarStates.Accelerating:
                    break;
                case CarStates.Breaking:
                    break;
                case CarStates.Stop:
                    break;
                case CarStates.WaitingForGreenFirst:
                    break;
                case CarStates.WaitingForGreenSecond:
                    break;
                case CarStates.FollowingPath:
                    break;
                case CarStates.FollowingNextCar:
                    break;
            }
        }
    }
}
