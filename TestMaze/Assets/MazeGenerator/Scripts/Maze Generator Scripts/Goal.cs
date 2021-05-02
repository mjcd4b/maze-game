using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public static bool victory = false;

    private void OnTriggerEnter(Collider other)
    {
        victory = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited the goal");
    }

}
