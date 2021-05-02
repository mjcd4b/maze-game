using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureMenuScript : MonoBehaviour
{
    public GameObject failureMenu;

    void Start()
    {
        failureMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Trap.failure || !Timer.timerIsRunning)
        {
            activateMenu();
        }
    }

    // Update is called once per frame
    void activateMenu()
    {
        failureMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
}
