using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonState : GameAbstractState
{
    public override void EnterState(GameManager gameManager)
    {
        isStateInitiated = true;
    }

    public override void UpdateState(GameManager gameManager)
    {
        if (gameManager.ninjaStMngr.animController.GetCurrentAnimatorStateInfo(0).IsName("WalkAwayAfterVictory") &&
                gameManager.ninjaStMngr.animController.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
        {
            int nextLevel = PlayerPrefs.GetInt("Level") + 1;
            PlayerPrefs.SetInt("Level", nextLevel);

            gameManager.BackToEntryScreen();
        }
    }

    public override void ExitState(GameManager gameManager)
    {
        isStateInitiated = false;
    }
}
