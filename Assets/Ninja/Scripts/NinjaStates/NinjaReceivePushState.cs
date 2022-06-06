using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaReceivePushState : NinjaAbstractState
{
    Vector3 pushStartPosition;
    float distanceToTravel;

    public override void EnterState(NinjaStateManager ninja)
    {
        //Stop ninja movement before applying push
        ninja.rgbdy.velocity = Vector3.zero;

        //Enable ninja rigidbody to roll in z axis
        ninja.rgbdy.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        //Record position where push first started
        pushStartPosition = ninja.transform.position;

        //Calculate velocity relative to distance to squid
        float curDistToSquid = Vector3.Distance(ninja.squidTrn.position, pushStartPosition);
        float distRatioToSquid = (ninja.startDistanceToSquid / curDistToSquid);
        float velMagnitude = distRatioToSquid * ninja.pushBackVelocityCoeff;

        //Push the ninja back by rolling him back.
        ninja.rgbdy.velocity = Vector3.forward * velMagnitude;

        //Set pushback distance relative to distance to squid
        distanceToTravel = distRatioToSquid * ninja.ninjaPushBackDistance;

        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
        //Ninja cannot move past the starting position
        if(Vector3.Distance(ninja.startPosition, ninja.transform.position) < 2f)
            ninja.SwitchState(ninja.RecoverFromPushState);

        //Check if ninja is pushed far enough and switch to recevor from push state
        else if (Vector3.Distance(pushStartPosition, ninja.transform.position) > distanceToTravel)
            ninja.SwitchState(ninja.RecoverFromPushState);
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
