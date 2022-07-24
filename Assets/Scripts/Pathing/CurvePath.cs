using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathing
{
    public class CurvePath : MonoBehaviour
    {
        public List<GameObject> curveNodes = new List<GameObject>();

        public string pathId;

        public GameObject nextPath;

        public void Start()
        {
            pathId = Guid.NewGuid().ToString();
        }
    }
}
