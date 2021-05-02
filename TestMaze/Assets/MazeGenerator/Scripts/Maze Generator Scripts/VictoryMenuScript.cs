using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenuScript : MonoBehaviour
{
    public GameObject victoryMenu;

    void Start()
    {
        victoryMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Goal.victory)
        {
            activateMenu();
        }
    }

    // Update is called once per frame
    void activateMenu()
    {
        victoryMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
}
