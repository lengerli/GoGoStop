using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaHopState : NinjaAbstractState
{
    bool isNinjaTakenOffGround;

    public override void EnterState(NinjaStateManager ninja)
    {
        Vector3 hopVector = (ninja.hopForceMagnitude * ninja.hopForceDirection);
        ninja.rgbdy.velocity = Vector3.zero;//If the ninja is moving while hop starts, we should zero the velocity so that hop force can take true effect 
        ninja.rgbdy.AddForce(hopVector, ForceMode.Impulse);
        isNinjaTakenOffGround = false;
        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {

        if (isNinjaTakenOffGround == false && ninja.ninjaBottom.isNinjaBottomTouchingFloor == false) //Ninja just took off ground
            isNinjaTakenOffGround = true;
        else if (isNinjaTakenOffGround && ninja.ninjaBottom.isNinjaBottomTouchingFloor == true) //Ninja has landed
        { 
            float distanceToSquid = Vector3.Distance(ninja.transform.position, ninja.squidTrn.position);

            if (distanceToSquid < ninja.minDistanceToAttack)
                ninja.SwitchState(ninja.ReadyToAttackState);
            else
                ninja.SwitchState(ninja.IdleState);
        }
        
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {
        ninja.rgbdy.AddForce(ninja.gravityScale * Vector3.down, ForceMode.Acceleration);
    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isNinjaTakenOffGround = false;
        isStateInitialized = false;
    }
}
