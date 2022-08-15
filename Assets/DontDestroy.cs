using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static GameObject instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(base.gameObject);
        }
        else
        {
            Destroy(base.gameObject);
        }
    }
}
