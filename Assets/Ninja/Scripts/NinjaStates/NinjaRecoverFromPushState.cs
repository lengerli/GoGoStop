using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRecoverFromPushState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        ninja.rgbdy.constraints = RigidbodyConstraints.FreezeRotation;
        ninja.rgbdy.velocity = Vector3.zero;
        ninja.rgbdy.angularVelocity = Vector3.zero;
        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (Mathf.Abs ( ninja.transform.rotation.x - ninja.ninjaStartRotation.x ) > 0.05f)
            RollNinjaBack(ninja);
        else
        {
            ninja.transform.rotation = ninja.ninjaStartRotation;
            if (ninja.GetComponent<HealthController>().CurrentHealth() > 0)
                ninja.SwitchState(ninja.IdleState);
            else
                ninja.SwitchState(ninja.DieState);
        }
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {
        ninja.rgbdy.AddForce(ninja.gravityScale * Vector3.down, ForceMode.Acceleration);
    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }

    private void RollNinjaBack(NinjaStateManager ninja)
    {
        ninja.transform.Rotate(Vector3.right, 1.5f);
    }
}
