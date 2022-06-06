using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidPushState : SquidAbstractState
{
    bool isNinjaPushed;
    bool isShockWaveSent;

    public override void EnterState(SquidStateManager squid)
    {
    }

    public override void UpdateState(SquidStateManager squid)
    {
        //Push ba�lay�nca shockwave g�rselini harekete ge�ir
        if (isShockWaveSent == false && squid.animator.GetCurrentAnimatorStateInfo(0).IsTag("Push") && squid.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.15f)
        {
            squid.pushWave.transform.LookAt(squid.ninjaStateManager.transform);
            squid.pushWave.GetComponent<ParticleSystem>().Play();
            isShockWaveSent = true;
        }
        //Push animasyonunun ortas�ndayken ninja state'i receive push'a ge�ir ki sanki squid'in hareketinden etkilenmi� gibi olsun.
        else if(isNinjaPushed == false && squid.animator.GetCurrentAnimatorStateInfo(0).IsTag("Push") && squid.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f)
        {
            squid.ninjaStateManager.GetComponent<HealthController>().DecreaseHealth(squid.pushDamage);
            isNinjaPushed = true;
            squid.ninjaStateManager.SwitchState(squid.ninjaStateManager.ReceivePushState);
        }

        //Tekrar sleep'e ge�mek i�in push animasyonunun bitmesini bekle
        else if (isNinjaPushed == true && squid.animator.GetCurrentAnimatorStateInfo(0).IsTag("Push") && squid.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95f)
        {
            isNinjaPushed = false;
            isShockWaveSent = false;
            squid.animator.SetBool("NinjaSighted", false);
            squid.SwitchState(squid.GoToSleepState);
        }
    }
}
