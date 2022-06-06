using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAction : MonoBehaviour, IWeaponAction
{
    public float delayAction;
    public float arrowShootVelocity;
    public Rigidbody rgbd;
    public int damage;
    public Transform woundPoint; //We add a child to the weapon so that when it wounds ninja, the blood prefab child of ninja can rotate towards this woundPoint and blood gushes from correct position of the ninja

    public void FireTheWeapon()
    {
        if (delayAction > 0f)
            StartCoroutine(DelayedFire());
        else
            ShootTheArrow();
    }

    public void HitAction (GameObject target)
    {
        GetComponent<Rigidbody>().velocity = Vector2.zero;

        if (target.tag == "Player")
        {
            target.GetComponent<HealthController>().DecreaseHealth(damage);
            target.GetComponent<NinjaStateManager>().woundPosition = woundPoint.position;
            target.GetComponent<NinjaStateManager>().SwitchState(target.GetComponent<NinjaStateManager>().HurtState);
        }

        transform.parent = target.transform;
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<SphereCollider>());
        this.enabled = false;
    }

    IEnumerator DelayedFire()
    {
        yield return new WaitForSeconds(delayAction);
        ShootTheArrow();
    }

    private void ShootTheArrow()
    {
        rgbd.velocity = transform.up * arrowShootVelocity;
    }

    void StickArrowToTarget()
    {

    }
}
