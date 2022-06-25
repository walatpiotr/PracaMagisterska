using System;
using UnityEngine;
using static Assets.CSharpClasses.Constans;

namespace Assets.Scripts.Pathing
{
    public class Node : MonoBehaviour
    {
        public string nodeId;
        public NodeType type;

        public void Start()
        {
            nodeId = Guid.NewGuid().ToString();
        }
    }
}
