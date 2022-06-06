using UnityEngine;

public abstract class SquidAbstractState
{
    public abstract void EnterState(SquidStateManager squid);
    public abstract void UpdateState(SquidStateManager squid);
}
