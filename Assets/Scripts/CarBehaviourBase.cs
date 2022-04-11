using System;
using UnityEngine;
using static NonUnityClasses.Constants;

namespace Assets.Scripts
{
    public class CarBehaviourBase : MonoBehaviour
    {
        protected float velocity = 0f;

        protected CarStates currentState = CarStates.Init;

        // Method responsible for increasing speed
        protected void Accelerate()
        {

        }

        // Method responsible for decreasing speed
        protected void Break()
        {

        }

        // Method responsible for detecting car from the same line
        protected Tuple<GameObject, float> DetectCarAheadWithDistance()
        {
            return null;
        }
    }
}
