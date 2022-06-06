using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestartState : GameAbstractState
{
    public override void EnterState(GameManager gameManager)
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
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
