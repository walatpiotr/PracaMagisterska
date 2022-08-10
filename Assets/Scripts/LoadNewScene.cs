using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public void LoadSimulationScene()
    {
        if (GameObject.FindGameObjectWithTag("configuration").GetComponent<ConfigurationValidator>().ValidateConfig())
        {
            SceneManager.LoadScene("SimulationScene");
        }
    }
}
