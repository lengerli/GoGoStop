using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelEnterState : GameAbstractState
{
    public override void EnterState(GameManager gameManager)
    {
        gameManager.camAnimController.enabled = true;
        gameManager.camAnimController.SetBool("SceneEntry", true);

        gameManager.ninjaStMngr.SwitchState(gameManager.ninjaStMngr.WalkIntoSceneState);
        gameManager.squidStMngr.SwitchState(gameManager.squidStMngr.CinematicFreezeState);

        isStateInitiated = true;
    }

    public override void UpdateState(GameManager gameManager)
    {
        if (gameManager.camAnimController.GetCurrentAnimatorStateInfo(0).IsName("CameraSceneEntryAnim") &&
            gameManager.camAnimController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f)
        {
            gameManager.camAnimController.SetBool("SceneEntry", false);
            gameManager.SwitchState(gameManager.ReadyToStartState);
        }
    }

    public override void ExitState(GameManager gameManager)
    {
        gameManager.camAnimController.enabled = false;
        isStateInitiated = false;
    }
}
