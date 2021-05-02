using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public static bool failure = false;
    private void OnTriggerEnter(Collider other)
    {
        failure = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited the trap");
    }

}
