using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaCinematicPrepForFinalAttackState : NinjaAbstractState
{
    public override void EnterState(NinjaStateManager ninja)
    {
        ninja.rgbdy.velocity = Vector3.zero;
        isStateInitialized = true;
        ninja.squidStateMan.SwitchState(ninja.squidStateMan.CinematicFreezeState);
        ninja.cameraZoomAnim.enabled = true;//main cam zoom anim oynatmaya baþlat
        ninja.cameraZoomAnim.SetBool("RoundAbout", true);
    }

    bool orthPerspTransitionCalled = false;
    bool zoomAnimEnded = false;

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (orthPerspTransitionCalled == false &&
            ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).IsName("ZoomIn") &&
            ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        {
            ninja.camZoom.ZoomCamForNinjaAttack();//Zoom animasyonunun ortasýndayken orth-persp camera transition çaðýr
            orthPerspTransitionCalled = true;
            ninja.SetUpVictoryWalkCorridor();
        }
        else if (zoomAnimEnded == false && ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).IsName("ZoomIn") &&
            orthPerspTransitionCalled == true && ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98f)
            zoomAnimEnded = true;
        else if (zoomAnimEnded == true && ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).IsName("ZoomIn") == false && ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98f)
            ninja.SwitchState(ninja.FinalizeAttackState);
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {

    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }
}