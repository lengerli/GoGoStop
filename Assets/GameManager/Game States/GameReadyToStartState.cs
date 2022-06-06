using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReadyToStartState : GameAbstractState
{
    bool canPlayGame;
    float displayButtonDelayTimeTotal;
    bool isPlayButtonDisplayed;

    public override void EnterState(GameManager gameManager) 
    {
        isStateInitiated = true;
    }

    public override void UpdateState(GameManager gameManager) 
    {
        if(displayButtonDelayTimeTotal < 0.75f)
            displayButtonDelayTimeTotal += Time.deltaTime;
        else if(isPlayButtonDisplayed == false)
        {
            gameManager.gameStartButton.gameObject.SetActive(true);
            gameManager.gameStartButton.onClick.RemoveAllListeners();
            gameManager.gameStartButton.onClick.AddListener(SwitchToPlayState);
            isPlayButtonDisplayed = true;
        }

        else if (canPlayGame == true)
        {
            gameManager.gameStartButton.gameObject.SetActive(false);
            gameManager.gameStartButton.onClick.RemoveAllListeners();
            canPlayGame = false;
            gameManager.SwitchState(gameManager.PlayState);
        }
    }

    public override void ExitState(GameManager gameManager) 
    {
        isStateInitiated = false;
    }

    public void SwitchToPlayState()
    {
        canPlayGame = true;
    }
}
