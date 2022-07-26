using System;
using UnityEngine;
using static Assets.CSharpClasses.Constans;

namespace Assets.Scripts
{
    public class CarBehaviourBase : MonoBehaviour
    {
        protected CarStates currentState = CarStates.Init;
        protected Detection events;

        public void Start()
        {
            events = GetComponent<Detection>();
            events.OnCarDetection += Events_OnCarDetection;
            events.OnNoDetection += Events_OnNoDetection;
            events.OnSafeDetection += Events_OnCarInSafeDistanceDetection;
        }

        private void Events_OnCarDetection(object sender, Detection.OnCarDetectionEventArgs e)
        {
            Break();
        }

        private void Events_OnNoDetection(object sender, EventArgs e)
        {
            Accelerate();
        }

        private void Events_OnCarInSafeDistanceDetection(object sender, EventArgs e)
        {
            if (GetComponent<CarValueContainer>().carAhead.GetComponent<CarValueContainer>().velocity < GetComponent<CarValueContainer>().velocity)
            {
                Break();
            }
            if (GetComponent<CarValueContainer>().carAhead.GetComponent<CarValueContainer>().velocity == GetComponent<CarValueContainer>().velocity)
            {
                KeepVelocity();
            }
            if (GetComponent<CarValueContainer>().carAhead.GetComponent<CarValueContainer>().velocity == GetComponent<CarValueContainer>().velocity)
            {
                Accelerate();
            }
        }

        // Method responsible for increasing speed
        public void Accelerate()
        {
            GetComponent<Accelerating>().isAccelerating = true;
            GetComponent<Breaking>().isBreaking = false;
        }

        // Method responsible for decreasing speed
        public void Break()
        {
            GetComponent<Accelerating>().isAccelerating = false;
            GetComponent<Breaking>().isBreaking = true;
        }

        // Method responsible for keeping speed
        public void KeepVelocity()
        {
            GetComponent<Accelerating>().isAccelerating = false;
            GetComponent<Breaking>().isBreaking = false;
        }


        private void OnDestroy()
        {
            events.OnCarDetection -= Events_OnCarDetection;
            events.OnNoDetection -= Events_OnNoDetection;
            events.OnSafeDetection -= Events_OnCarInSafeDistanceDetection;
        }

        public void NoDetectionUnSub()
        {
            events.OnNoDetection -= Events_OnNoDetection;
        }

        public void NoDetectionSub()
        {
            events.OnNoDetection += Events_OnNoDetection;
        }
    }
}
