using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaReceiveAttackState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {

    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {
        ninja.rgbdy.AddForce(ninja.gravityScale * Vector3.down, ForceMode.Acceleration);
    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }
}
