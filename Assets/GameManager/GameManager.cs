using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables for State Instances
    public NinjaStateManager ninjaStMngr;
    public SquidStateManager squidStMngr;
    public Animator camAnimController;

    public GameObject settingsButton;
    public Button muteButton;
    public Button unMuteButton;

    public GameObject settingsPanel;
    public GameObject gameLostText;

    public Button gameStartButton;

    public Button restartLevelButton;
    public Button quitGameButton;
    public Button closeSettingsMenuButton;
    #endregion

    #region State Instances
    public GameLevelEnterState LevelEnterState = new GameLevelEnterState();
    public GameReadyToStartState ReadyToStartState = new GameReadyToStartState();
    public GamePlayState PlayState = new GamePlayState();
    public GameLostState LostState = new GameLostState();
    public GameWonState WonState = new GameWonState();
    public GameQuitState QuitState = new GameQuitState();
    public GameSettingsState SettingsState = new GameSettingsState();
    public GameRestartState RestartState = new GameRestartState();
    #endregion

    private GameAbstractState currentState;
    private GameAbstractState previousState;

    // Start is called before the first frame update
    void Start()
    {
        SettingsState.InitializeSettingsMenu(this);
        ninjaStMngr.gameManager = this;

        currentState = LevelEnterState;
        currentState.EnterState(this);
        previousState = currentState;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState.isStateInitiated)
            currentState.UpdateState(this);
    }

    public void SwitchState(GameAbstractState newState)
    {
        if(currentState != null)
        {
            currentState.ExitState(this);
            previousState = currentState;
        }

        currentState = newState;
        currentState.EnterState(this);

        if (previousState == null)
            previousState = currentState;
    }

    public void SwitchToPreviousState()
    {
        currentState.ExitState(this);
        currentState = previousState;
        currentState.EnterState(this);
        previousState = null;
    }

    public void SwitchToSettingsMenuState()
    {
        SwitchState(SettingsState);
    }

    public void SwitchToPlayState()
    {
        SwitchState(PlayState);
    }

    public void GameIsWon()
    {
        //This method is called by ninja state manager after final attack is succesfull
        SwitchState(WonState);
    }

    public void GameIsLost()
    {
        //This method is called by ninja state manager at die state
        SwitchState(LostState);
    }

    public void BackToEntryScreen()
    {
        SceneManager.LoadScene(0);
    }
}
