using UnityEngine;

static public class VectorExtensions
{
    static public Vector3 XZPlane(this Vector3 vec)
    {
        return new Vector3(vec.x, vec.y, 0f);
    }

    static public Vector3 AddLayer(this Vector2 vec)
    {
        return new Vector3(vec.x, vec.y, 0f);
    }
}
