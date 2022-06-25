using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Pathing
{
    public class Road : MonoBehaviour
    {
        public string roadId;
        public List<GameObject> paths;

        public void Start()
        {
            roadId = Guid.NewGuid().ToString();
        }
    }
}
