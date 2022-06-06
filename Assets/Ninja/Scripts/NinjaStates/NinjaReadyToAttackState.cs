using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaReadyToAttackState : NinjaAbstractState
{
    bool canEnableAttackState;

    public override void EnterState(NinjaStateManager ninja)
    {
        ninja.killButton.gameObject.SetActive(true);
        ninja.killButton.onClick.RemoveAllListeners();
        ninja.killButton.onClick.AddListener(SwitchToAttackAttemptState);
        isStateInitialized = true;
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (canEnableAttackState == true)
        {
            canEnableAttackState = false;
            ninja.SwitchState(ninja.InitiateAttackState);
        }
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {
        ninja.rgbdy.AddForce(ninja.gravityScale * Vector3.down, ForceMode.Acceleration);
    }
    public override void ExitState(NinjaStateManager ninja)
    {
        ninja.killButton.gameObject.SetActive(false);
        ninja.killButton.onClick.RemoveAllListeners();
        isStateInitialized = false;
    }

    public void SwitchToAttackAttemptState()
    {
        canEnableAttackState = true;
    }
}