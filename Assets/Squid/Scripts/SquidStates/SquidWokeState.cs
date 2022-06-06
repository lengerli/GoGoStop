using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidWokeState : SquidAbstractState
{
    bool willLookAround;
    bool willGoBackSleeping;
    float stayWokeTimeTotal;
    float stayWokeTime;
    public override void EnterState(SquidStateManager squid)
    {
        willLookAround = false;
        willGoBackSleeping = false;
        squid.eyeForSight.SetActive(true);
        squid.animator.SetBool("WakeUp", true);

        stayWokeTime = Random.Range(squid.minWokeWait, squid.maxWokeWait);

        if (Random.Range(1, 100) < squid.patrolPossibility)
            willLookAround = true;
        else
            willGoBackSleeping = true;
    }

    public override void UpdateState(SquidStateManager squid)
    {
        stayWokeTimeTotal += Time.deltaTime;

        if(stayWokeTimeTotal > stayWokeTime && squid.animator.IsInTransition(0) == false)
        {
            squid.animator.SetBool("WakeUp", false);
            stayWokeTimeTotal = 0f;

            if (willLookAround)
                squid.SwitchState(squid.LookAroundState);
            else if (willGoBackSleeping)
                squid.SwitchState(squid.SleepState);
        }
    }
}
