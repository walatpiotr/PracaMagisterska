using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace
{
    static public class VectorExtensions
    {
        static public Vector3 XZPlane(this Vector3 vec)
        {
            return new Vector3(vec.x, 0, vec.z);
        }
    }
}
