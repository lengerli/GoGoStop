using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAction : MonoBehaviour, IWeaponAction
{
    public float delayAction;
    public float waitBeforeSwingBack;
    public Animator anim;
    public int damage;
    public Transform woundPoint; //We add a child to the weapon so that when it wounds ninja, the blood prefab child of ninja can rotate towards this woundPoint and blood gushes from correct position of the ninja

    public void FireTheWeapon()
    {
        if (delayAction > 0f)
            StartCoroutine(DelayedSwing());
        else
            SwingTheAxe();
    }

    public void HitAction(GameObject target)
    {
        if(target.tag == "Player")
        {
            target.GetComponent<HealthController>().DecreaseHealth(damage);
            target.GetComponent<NinjaStateManager>().woundPosition = woundPoint.position;
            target.GetComponent<NinjaStateManager>().SwitchState(target.GetComponent<NinjaStateManager>().HurtState);
        }
    }

    IEnumerator DelayedSwing()
    {
        yield return new WaitForSeconds(delayAction);
        SwingTheAxe();
    }

    private void SwingTheAxe()
    {
        anim.SetBool("SwingBack", false);
        anim.SetBool("SwingDown", true);
        if (waitBeforeSwingBack > 0)
            StartCoroutine(DelayedSwingBack());
    }

    IEnumerator DelayedSwingBack()
    {
        yield return new WaitForSeconds(waitBeforeSwingBack);
        SwingBack();
    }

    private void SwingBack()
    {
        anim.SetBool("SwingDown", false);
        anim.SetBool("SwingBack", true);
    }
}
