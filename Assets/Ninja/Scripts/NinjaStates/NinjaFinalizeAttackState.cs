using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFinalizeAttackState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        ninja.rgbdy.velocity = Vector3.zero;
        ninja.animController.enabled = true;
        ninja.animController.SetBool("Attack", true);
        isStateInitialized = true;
    }

    bool isSquidDieded;

    public override void UpdateState(NinjaStateManager ninja)
    {
        //Ninja attack animasyonunun ortasýnda squid ile temas oluyor. Bu noktatda squid die state aktive edilebilir
        if (isSquidDieded == false && ninja.animController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.6f)
        {
            ninja.squidStateMan.SwitchState(ninja.squidStateMan.DieState);
            isSquidDieded = true;
        }
        else if (ninja.animController.GetCurrentAnimatorStateInfo(0).normalizedTime > 8f)
            ninja.SwitchState(ninja.VictoryWalkState);
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {

    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }
}