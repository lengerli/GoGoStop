using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaDieState : NinjaAbstractState
{
    /// <summary>
    /// This state is switched by NinjaHurtState or NinjaRecevorFromPushState
    /// </summary>
    /// <param name="ninja"></param>

    public override void EnterState(NinjaStateManager ninja)
    {
        foreach(GameObject blood in ninja.bloodGushers)
        {
            blood.SetActive(true);
        }

        ninja.gameManager.SwitchState(ninja.gameManager.LostState);

        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {

    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {

    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }

}
