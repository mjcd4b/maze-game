using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public GameObject Canvas;
    bool Paused = false;

    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Paused == false)
            {
                activateMenu();
            }
            else
            {
                deactivateMenu();
            }
        }
    }

    void activateMenu()
    {
        Canvas.gameObject.SetActive(true);
        Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void deactivateMenu()
    {
        Canvas.gameObject.SetActive(false);
        Paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
