using UnityEngine;

/// <summary>
/// The abstract class all ninja state classes inherit from
/// </summary>

public abstract class NinjaAbstractState 
{
    public bool isStateInitialized;

    public abstract void EnterState(NinjaStateManager ninja);
    public abstract void UpdateState(NinjaStateManager ninja);

    public abstract void ExitState(NinjaStateManager ninja);

    public abstract void ApplyGravityState(NinjaStateManager ninja);
}
