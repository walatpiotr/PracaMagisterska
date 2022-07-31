using UnityEngine;

public class CarCountingScript : MonoBehaviour
{
    public int amountOfCarsWhichCrossedTheRoad;

    public void IncreaseCarCount()
    {
        amountOfCarsWhichCrossedTheRoad += 1;
    }
}
