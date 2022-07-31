using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationTimeManager : MonoBehaviour
{
    public bool simulationPaused=false;

    public void ChangeSimulationPaused()
    {
        if (simulationPaused)
        {
            UnPauseGame();
        }
        else
        {
            PauseGame();
        }
        simulationPaused = !simulationPaused;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
