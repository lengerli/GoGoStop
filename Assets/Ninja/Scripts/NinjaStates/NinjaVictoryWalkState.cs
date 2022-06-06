using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaVictoryWalkState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        ninja.animController.SetBool("VictoryWalk", true);
        ninja.Victory();
        isStateInitialized = true;
    }

    bool dimLightsStarted;

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (ninja.animController.GetCurrentAnimatorStateInfo(0).IsName("WalkAwayAfterVictory") &&
            ninja.animController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f &&
            dimLightsStarted == false)
        {
            ninja.DimTheLights();
            dimLightsStarted = true;
        }
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {

    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }

}
