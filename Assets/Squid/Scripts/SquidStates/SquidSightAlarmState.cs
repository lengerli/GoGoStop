using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidSightAlarmState : SquidAbstractState
{
    public override void EnterState(SquidStateManager squid)
    {
        squid.eyePositionAtSight = squid.eyeForSightTrnsf.position;
        squid.eyeRotationAtSight = squid.eyeForSightTrnsf.rotation;
        squid.isNinjaSighted = true;

        squid.animator.SetBool("NinjaSighted", true);
        squid.rgbdy.angularVelocity = Vector3.zero;
        squid.ninjaStateManager.SwitchState(squid.ninjaStateManager.FrozenState);
        squid.SwitchState(squid.PushState);
    }

    public override void UpdateState(SquidStateManager squid)
    {

    }
}
