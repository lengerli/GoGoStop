using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSensor : MonoBehaviour, IWeaponSensor
{
    public GameObject weapon;
    public GameObject hitObject;
    public virtual void ContactSensed(GameObject target)
    {
        weapon.GetComponent<IWeaponAction>().HitAction(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        hitObject = other.gameObject;
        ContactSensed(hitObject);
    }
}
