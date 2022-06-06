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
        ninja.cameraZoomAnim.enabled = true;//main cam zoom anim oynatmaya ba�lat
    }

    bool orthPerspTransitionCalled = false;
    bool zoomAnimEnded = false;

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (orthPerspTransitionCalled == false && ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
        {
            ninja.camZoom.ZoomCamForNinjaAttack();//Zoom animasyonunun ortas�ndayken orth-persp camera transition �a��r
            orthPerspTransitionCalled = true;
            ninja.cameraZoomAnim.SetBool("RoundAbout", true);
            ninja.SetUpVictoryWalkCorridor();
        }
        else if (orthPerspTransitionCalled == true && ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 2.45f)
            zoomAnimEnded = true;
        else if(zoomAnimEnded == true && ninja.cameraZoomAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            ninja.SwitchState(ninja.FinalizeAttackState);
            //TODO art�k final attak statelere ge�ebiliriz (squid i�in de ninja i�in de. squidde animasyonu serbest b�rak�caz sadece)
        }
        
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {

    }

    public override void ExitState(NinjaStateManager ninja)
    {
        isStateInitialized = false;
    }
}