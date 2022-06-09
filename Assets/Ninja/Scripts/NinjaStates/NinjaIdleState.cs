using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaIdleState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        //Make sure ninja is not above ground
        ninja.transform.position = new Vector3(ninja.transform.position.x, ninja.startPosition.y, ninja.transform.position.z);
        ninja.transform.rotation = ninja.ninjaStartRotation;

        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
        if ( ( Input.GetKey(KeyCode.Space) || Input.touchCount > 0) 
            && ninja.ninjaBottom.isNinjaBottomTouchingFloor )
            ninja.SwitchState(ninja.HopState);
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
