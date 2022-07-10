using UnityEngine;

public class Breaking : MonoBehaviour
{
    private CarValueContainer valueContainer;
    public bool isBreaking;

    void Start()
    {
        valueContainer = gameObject.GetComponent<CarValueContainer>();
    }

    private void FixedUpdate()
    {
        if (isBreaking && valueContainer.velocity > 0f)
        {
            valueContainer.velocity -= valueContainer.breakValue;
            if (valueContainer.velocity < 0f)
            {
                valueContainer.velocity = 0f;
            }
        }
    }
}
