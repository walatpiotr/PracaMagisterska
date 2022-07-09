using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathing
{
    public class Path : MonoBehaviour
    {
        public GameObject endNode;
        public GameObject startnode;
        public GameObject generator;

        public List<GameObject> path = new List<GameObject>();
        public List<GameObject> nextPath = new List<GameObject>();
        public string pathId;

        public void Start()
        {
            path.Add(endNode);
            path.Add(startnode);
            pathId = Guid.NewGuid().ToString();
        }
    }
}
