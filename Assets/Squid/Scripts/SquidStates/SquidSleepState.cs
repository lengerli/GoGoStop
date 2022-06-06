using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidSleepState : SquidAbstractState
{
    float sleepTimeTotal;
    float sleepTime;


    public override void EnterState(SquidStateManager squid) 
    {
        squid.eyeForSight.SetActive(false);
        sleepTime = Random.Range(squid.minSleepTime, squid.maxSleepTime);
        squid.animator.speed = 1f;
        squid.animator.SetBool("Sleep", true);
    }

    public override void UpdateState(SquidStateManager squid) 
    {
        sleepTimeTotal += Time.deltaTime;
        if (sleepTimeTotal > sleepTime)
        {
            sleepTimeTotal = 0f;
            squid.animator.SetBool("Sleep", false);
            squid.SwitchState(squid.WokeState);
        }
    }
}
