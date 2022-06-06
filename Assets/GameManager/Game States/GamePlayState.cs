using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : GameAbstractState
{
    public override void EnterState(GameManager gameManager)
    {
        gameManager.ninjaStMngr.SwitchState(gameManager.ninjaStMngr.IdleState);
        gameManager.squidStMngr.SwitchState(gameManager.squidStMngr.SleepState);
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
