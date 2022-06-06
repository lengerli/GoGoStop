using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLostState : GameAbstractState
{
    public override void EnterState(GameManager gameManager)
    {
        gameManager.restartLevelButton.onClick.RemoveAllListeners();
        gameManager.quitGameButton.onClick.RemoveAllListeners();

        gameManager.restartLevelButton.onClick.AddListener(gameManager.SettingsState.RestartLevel);
        gameManager.quitGameButton.onClick.AddListener(gameManager.SettingsState.QuitGame);
        gameManager.closeSettingsMenuButton.gameObject.SetActive(false);
        gameManager.settingsPanel.SetActive(true);
        gameManager.gameLostText.SetActive(true);

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
