using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidGoToSleepState : SquidAbstractState
{
    float reTurnAngleTotal;
    float reTurnSpeed;
    float reTurnAngleAtFrame;

    public override void EnterState(SquidStateManager squid)
    {
        squid.isNinjaSighted = false;
        squid.eyeForSightTrnsf.localRotation = squid.eyeRotationAtStart;
        squid.eyeForSightTrnsf.localPosition = squid.eyePositionAtStart;
        squid.eyeForSight.SetActive(false);
        squid.animator.SetBool("Sleep", true);
        reTurnSpeed = squid.turnSpeedForPatrolStart;
    }

    public override void UpdateState(SquidStateManager squid)
    {
        if (reTurnAngleTotal < 180f)
        {
            reTurnAngleAtFrame = Time.deltaTime * reTurnSpeed;
            reTurnAngleTotal += reTurnAngleAtFrame;
            squid.transform.Rotate(squid.rotateAxis, reTurnAngleAtFrame);
        }
        else
        {
            reTurnAngleTotal = 0f;
            squid.rgbdy.angularVelocity = Vector3.zero;
            squid.transform.rotation = squid.squidStartRotation;
            squid.SwitchState(squid.SleepState);
        }
    }
}