using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuitState : GameAbstractState
{
    public override void EnterState(GameManager gameManager)
    {
        isStateInitiated = true;
    }

    public override void UpdateState(GameManager gameManager)
    {

    }

    public override void ExitState(GameManager gameManager)
    {
        isStateInitiated = false;
    }
}
