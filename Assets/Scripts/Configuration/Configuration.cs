using UnityEngine;

public class Configuration : MonoBehaviour
{
    public float acceleration = 1.0f;
    public float breaking = 2.0f;

    public float ffchance = 12.00f;
    public float fschance = 24.00f;
    public float sschance = 36.00f;
    public float sfchance = 28.00f;

    public float minFirstCarDelay = 0.42f;
    public float maxFirstCarDelay = 2.12f;

    public float minSecondCarDelay = 1.11f;
    public float maxSecondCarDelay = 3.02f;

    public float safeDistance = 0.2f;
    public float maxVelocity = 2f;
    public float generatorDistance = 3f;
}
