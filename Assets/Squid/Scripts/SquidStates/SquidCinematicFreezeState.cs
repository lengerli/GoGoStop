using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidCinematicFreezeState : SquidAbstractState
{
    public override void EnterState(SquidStateManager squid)
    {
        squid.rgbdy.velocity = Vector3.zero;
        squid.rgbdy.angularVelocity = Vector3.zero;

        squid.animator.speed = 0;
        squid.eyeForSight.SetActive(false);
    }

    public override void UpdateState(SquidStateManager squid)
    {

    }
}
