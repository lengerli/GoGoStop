using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsState : GameAbstractState
{
    private GameManager gameManagerCurrent;
    public void InitializeSettingsMenu(GameManager gameManager)
    {
        gameManagerCurrent = gameManager;
    }

    public override void EnterState(GameManager gameManager)
    {
        PauseMovements();

        gameManager.restartLevelButton.onClick.RemoveAllListeners();
        gameManager.quitGameButton.onClick.RemoveAllListeners();
        gameManager.closeSettingsMenuButton.onClick.RemoveAllListeners();

        gameManager.restartLevelButton.onClick.AddListener(RestartLevel);
        gameManager.quitGameButton.onClick.AddListener(QuitGame);
        gameManager.closeSettingsMenuButton.onClick.AddListener(gameManager.SwitchToPreviousState);

        isStateInitiated = true;
    }

    public override void UpdateState(GameManager gameManager)
    {
    }

    public override void ExitState(GameManager gameManager)
    {
        isStateInitiated = false;
    }

    public void RestartLevel()
    {
        gameManagerCurrent.SwitchState(gameManagerCurrent.RestartState);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void PauseMovements()
    {
        Debug.LogError("IMPLEMENT PAUSE EVERYTHING");
    }

}
