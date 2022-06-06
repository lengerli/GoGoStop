using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFrozenState : NinjaAbstractState
{
    /// <summary>
    /// Frozen state is a special state. Ninja enters and exits by decree of outside operators only! 
    /// </summary>
    /// <param name="ninja"></param>

    public override void EnterState(NinjaStateManager ninja)
    {
        ninja.rgbdy.velocity = Vector3.zero;
        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
          ninja.rgbdy.velocity = Vector3.zero;
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {
        ninja.rgbdy.AddForce(ninja.gravityScale * Vector3.down, ForceMode.Acceleration);
    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }
}
