using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryFailureMenuButtonsScript : MonoBehaviour
{
    public GameObject Canvas;
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void deactivateMenu()
    {
        Canvas.gameObject.SetActive(false);
        Goal.victory = false;
        Trap.failure = false;
        Timer.timerIsRunning = true;
    }
}
