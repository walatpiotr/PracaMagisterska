using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathing
{
    public class Path : MonoBehaviour
    {
        public GameObject endNode;
        public GameObject startnode;

        public List<GameObject> nextPath = new List<GameObject>();
        public string pathId;

        public void Start()
        {
            pathId = Guid.NewGuid().ToString();
        }
    }
}
