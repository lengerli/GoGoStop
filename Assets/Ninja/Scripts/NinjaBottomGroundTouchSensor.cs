using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaBottomGroundTouchSensor : MonoBehaviour
{
    public bool isNinjaBottomTouchingFloor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Floor")
            isNinjaBottomTouchingFloor = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Floor")
            isNinjaBottomTouchingFloor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Floor")
          isNinjaBottomTouchingFloor = false;
    }
}
