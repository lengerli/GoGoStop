using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidLookAroundState : SquidAbstractState
{
    bool willPatrol;
    bool willGoBackSleeping;
    float lookAroundTimeTotal;
    public override void EnterState(SquidStateManager squid)
    {
        squid.eyeForSight.SetActive(true);
        squid.animator.SetBool("LookAround", true);

        if (Random.Range(1, 100) < squid.patrolPossibility)
            willPatrol = true;
        else
            willGoBackSleeping = true;
    }

    public override void UpdateState(SquidStateManager squid)
    {
        lookAroundTimeTotal += Time.deltaTime;

        if (lookAroundTimeTotal > squid.lookAroundTime && squid.animator.IsInTransition(0) == false)
        {
            lookAroundTimeTotal = 0f;

            if (willPatrol) 
                squid.SwitchState(squid.PatrolState);
            else if (willGoBackSleeping)
            {
                squid.SwitchState(squid.SleepState);
                squid.animator.SetBool("LookAround", false);
            }

            willPatrol = false;
            willGoBackSleeping = false;
        }
    }


}