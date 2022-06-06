using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SquidPatrolState : SquidAbstractState
{
    float patrolDurationTime;
    float timeElapsed;
    float turnAngleTotal;

    public override void EnterState(SquidStateManager squid)
    {
        //Randomize time for patrol duration
        patrolDurationTime = Random.Range(squid.minPatrolTime, squid.maxPatrolTime);
        squid.rgbdy.angularVelocity = Vector3.up * squid.turnSpeedForPatrolStart;
    }

    public override void UpdateState(SquidStateManager squid)
    {
        //Stop the squid rotation when it faces the ninja (it should be 180 degrees but somehow 259 degrees work!)
        if (turnAngleTotal < Mathf.Deg2Rad * 259f)
            turnAngleTotal += Time.deltaTime * squid.turnSpeedForPatrolStart;
        else
            squid.rgbdy.angularVelocity = Vector3.zero;

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