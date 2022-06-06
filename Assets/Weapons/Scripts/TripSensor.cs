using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripSensor : MonoBehaviour, IWeaponSensor
{
    public List<GameObject> weaponList = new List<GameObject>();
    public void ContactSensed(GameObject target)
    {
        foreach(GameObject weapon in weaponList)
            weapon.GetComponent<IWeaponAction>().FireTheWeapon();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"  &&  IsNinjaSensible (other.gameObject) )
            ContactSensed(other.gameObject);
    }

    private bool IsNinjaSensible(GameObject ninja)
    {
        if (ninja.GetComponent<NinjaStateManager>().GetCurrentState().GetType().Equals(typeof(NinjaIdleState)) ||
            ninja.GetComponent<NinjaStateManager>().GetCurrentState().GetType().Equals(typeof(NinjaHopState))  )
            return true;
        else
            return false;


    }
}
