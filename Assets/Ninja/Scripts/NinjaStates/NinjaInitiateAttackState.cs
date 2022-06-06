using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaInitiateAttackState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        Vector3 hopVector = (ninja.hopForceMagnitude * ninja.hopForceDirection * 10f);
        ninja.rgbdy.velocity = Vector3.zero;
        ninja.rgbdy.AddForce(hopVector, ForceMode.Impulse);
        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (ninja.transform.position.y > ninja.ninjaAttackSuccessMinJumpHeight)
            ninja.SwitchState(ninja.CinematicPrepForFinalAttackState);
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
