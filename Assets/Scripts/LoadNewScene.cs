using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public void LoadSimulationScene()
    {
        SceneManager.LoadScene("SimulationScene");
    }
}
