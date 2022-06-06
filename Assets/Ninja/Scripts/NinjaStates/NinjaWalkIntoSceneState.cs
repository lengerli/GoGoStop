using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaWalkIntoSceneState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        ninja.animController.enabled = true;
        ninja.animController.SetBool("WalkIntoScene", true);
        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (ninja.animController.GetCurrentAnimatorStateInfo(0).IsName("WalkIntoScene") &&
            ninja.animController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
            ninja.animController.SetBool("WalkIntoScene", false);
        else if (ninja.animController.GetCurrentAnimatorStateInfo(0).IsName("IdleState")) 
                ninja.SwitchState(ninja.FrozenState);
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {

    }

    public override void ExitState(NinjaStateManager ninja)
    {
        ninja.animController.enabled = false;
        isStateInitialized = false;
    }

}