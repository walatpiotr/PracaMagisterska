using System;
using UnityEngine;

namespace Assets.Scripts.Pathing
{
    public class Path : MonoBehaviour
    {
        public GameObject endNode;
        public GameObject startnode;

        public string pathId;

        public void Start()
        {
            pathId = Guid.NewGuid().ToString();
        }
    }
}
