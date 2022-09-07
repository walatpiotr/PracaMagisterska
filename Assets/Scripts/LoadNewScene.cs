using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public void LoadSimulationScene()
    {
        if (GameObject.FindGameObjectWithTag("configuration").GetComponent<ConfigurationValidator>().ValidateConfig())
        {
            try
            {
                SceneManager.LoadScene("SimulationScene");
            }
            catch (Exception e)
            {
                GameObject.FindGameObjectWithTag("configuration").GetComponent<ConfigurationValidator>().errorMessage.text = "something went wrong:" + e.Message.ToString();
            }
        }
    }
}
