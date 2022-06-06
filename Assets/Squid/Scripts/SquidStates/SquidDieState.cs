using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidDieState : SquidAbstractState
{
    public override void EnterState(SquidStateManager squid)
    {
        squid.animator.speed = 1f;
        squid.rgbdy.velocity = Vector3.zero;
        squid.rgbdy.angularVelocity = Vector3.zero;
        squid.animator.SetBool("Die", true);
        squid.sightingAlarm.enabled = false;
    }

    public override void UpdateState(SquidStateManager squid)
    {

    }
}
