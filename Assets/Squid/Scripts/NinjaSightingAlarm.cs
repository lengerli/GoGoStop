using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSightingAlarm : MonoBehaviour
{
    public bool isNinjaSighted;

    private void OnTriggerEnter(Collider other)
    {
        isNinjaSighted = true;
    }

    private void OnTriggerStay(Collider other)
    {
        isNinjaSighted = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isNinjaSighted = false;
    }
}
