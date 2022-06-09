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
        gameManager.settingsPanel.SetActive(true);

        DisplayMuteOrUnmuteButton();

        gameManager.muteButton.onClick.RemoveAllListeners();
        gameManager.unMuteButton.onClick.RemoveAllListeners();
        gameManager.restartLevelButton.onClick.RemoveAllListeners();
        gameManager.quitGameButton.onClick.RemoveAllListeners();
        gameManager.closeSettingsMenuButton.onClick.RemoveAllListeners();

        gameManager.muteButton.onClick.AddListener(Mute);
        gameManager.unMuteButton.onClick.AddListener(UnMute);
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

    public void Mute()
    {
        GameObject.FindObjectOfType<AudioSource>().mute = true;
    }

    public void UnMute()
    {
        GameObject.FindObjectOfType<AudioSource>().mute = false;
    }

    private void DisplayMuteOrUnmuteButton()
    {
        gameManagerCurrent.unMuteButton.gameObject.SetActive(false);
        gameManagerCurrent.muteButton.gameObject.SetActive(false);

        if (GameObject.FindObjectOfType<AudioSource>().mute == true)
            gameManagerCurrent.unMuteButton.gameObject.SetActive(true);
        else
            gameManagerCurrent.muteButton.gameObject.SetActive(true);
    }
}
