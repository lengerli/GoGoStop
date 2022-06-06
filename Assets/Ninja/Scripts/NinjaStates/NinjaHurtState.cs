using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NinjaHurtState : NinjaAbstractState
{
    /// <summary>
    /// Like freeze state, this hurt state is also special.
    /// Switch to this state is controlled by other scripts just as in freeze state. In this case, the state switch is caused by weapons.
    /// But unlike freeze state, switching out of this state is controlled by this script itself. And the only out is idle.
    /// </summary>
    /// 

    GameObject activeBloodGusher = null;

    public override void EnterState(NinjaStateManager ninja)
    {
        bool isAvailableBloodFound = false;


        //Check list and find an inactive blood gusher ,
        foreach(GameObject blood in ninja.bloodGushers)
        {
            if (blood.activeSelf == false)
            {
                activeBloodGusher = blood;
                isAvailableBloodFound = true;
                break;
            }
        }

        if (isAvailableBloodFound == false)
            Debug.LogError("there were no active bloodgusher");
        else
        {
            //rotate the blood gusher
            activeBloodGusher.transform.LookAt(ninja.woundPosition);

            //activate the blood gusher object (the object will play blood particles and deactivate itself when its done with the blood gushing)
            activeBloodGusher.SetActive(true);
        }

        isStateInitialized = true;        
    }

    public override void UpdateState(NinjaStateManager ninja)
    {
        if (isStateInitialized && ninja.GetComponent<HealthController>().CurrentHealth() < 1)
            ninja.SwitchState(ninja.DieState);
        if (isStateInitialized)
            ninja.SwitchState(ninja.IdleState);
    }

    public override void ApplyGravityState(NinjaStateManager ninja)
    {
        ninja.rgbdy.AddForce(ninja.gravityScale * Vector3.down, ForceMode.Acceleration);
    }

    public override void ExitState(NinjaStateManager ninja)
    {
        activeBloodGusher = null;
        isStateInitialized = false;
    }
}