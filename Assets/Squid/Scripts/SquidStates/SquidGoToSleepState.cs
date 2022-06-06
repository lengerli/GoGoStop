using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidGoToSleepState : SquidAbstractState
{
    float reTurnAngleTotal;

    public override void EnterState(SquidStateManager squid)
    {
        squid.isNinjaSighted = false;
        squid.eyeForSightTrnsf.localRotation = squid.eyeRotationAtStart;
        squid.eyeForSightTrnsf.localPosition = squid.eyePositionAtStart;

        squid.animator.SetBool("Sleep", true);
        squid.rgbdy.angularVelocity = Vector3.up * squid.turnSpeedForPatrolStart;
    }

    public override void UpdateState(SquidStateManager squid)
    {
        if (reTurnAngleTotal < Mathf.Deg2Rad * 259f)
            reTurnAngleTotal += Time.deltaTime * squid.turnSpeedForPatrolStart;
        else
        {
            reTurnAngleTotal = 0f;
            squid.rgbdy.angularVelocity = Vector3.zero;
            squid.transform.rotation = squid.squidStartRotation;
            squid.SwitchState(squid.SleepState);
        }
    }
}