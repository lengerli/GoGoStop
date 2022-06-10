using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SquidPatrolState : SquidAbstractState
{
    float patrolDurationTime;
    float timeElapsed;
    float turnAngleTotal;
    float turnAngleAtFrame;
    float turnSpeed;
    bool isTurnComplete;

    public override void EnterState(SquidStateManager squid)
    {
        //Randomize time for patrol duration
        isTurnComplete = false;
        patrolDurationTime = Random.Range(squid.minPatrolTime, squid.maxPatrolTime);
        turnSpeed = squid.turnSpeedForPatrolStart;
    }

    public override void UpdateState(SquidStateManager squid)
    {
        //Stop the squid rotation when it faces the ninja (it should be 180 degrees but somehow 259 degrees work!)
        if (turnAngleTotal < 180f)
        {
            turnAngleAtFrame = Time.deltaTime * turnSpeed;
            turnAngleTotal += turnAngleAtFrame;
            squid.transform.Rotate(squid.rotateAxis, turnAngleAtFrame);
        }
        else if (isTurnComplete == false)
        {
            turnSpeed = 0;
            float trimAngle = 180f - turnAngleTotal;
            //Trim the rotation to make sure it ends up at 180 degrees
            squid.transform.Rotate(squid.rotateAxis, trimAngle);
            isTurnComplete = true;
        }

        if (timeElapsed < patrolDurationTime)
            timeElapsed += Time.deltaTime;
        else
        {
            timeElapsed = 0;
            turnAngleTotal = 0f;
            squid.animator.SetBool("LookAround", false);
            squid.SwitchState(squid.GoToSleepState);
        }

        if (squid.sightingAlarm.isNinjaSighted && ( squid.ninjaStateManager.GetCurrentState().GetType().Equals(typeof(NinjaHopState))
                                                    || squid.ninjaStateManager.GetCurrentState().GetType().Equals(typeof(NinjaInitiateAttackState)) ) )
        {
            timeElapsed = 0f;
            turnAngleTotal = 0f;
            squid.squidBodyRotationAtSightingMoment = squid.squidBodyTrn.rotation;
            squid.animator.SetBool("LookAround", false);
            squid.SwitchState(squid.SightAlarmState);
        }
    }

}
