using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HealthController))]

public class NinjaStateManager : MonoBehaviour
{
    #region Variables to be used by states
    public Rigidbody rgbdy;
    public float hopForceMagnitude;
    public Vector3 hopForceDirection;
    public Transform trnsfrm;
    public float gravityScale;
    public NinjaBottomGroundTouchSensor ninjaBottom;

    public float ninjaPushBackDistance;
    public float pushBackVelocityCoeff;

    public Transform squidTrn;
    public float startDistanceToSquid;

    public Vector3 startPosition;
    public Quaternion ninjaStartRotation;

    public float minDistanceToAttack;
    public Button killButton;

    public float ninjaAttackSuccessMinJumpHeight;
    public PerspectiveSwitcher camZoom;
    public Animator cameraZoomAnim;
    public Animator animController;


    public SquidStateManager squidStateMan;

    public GameObject victoryWalkCorridorPref;

    public List<Light> lights = new List<Light>();

    public GameManager gameManager;

    public Vector3 woundPosition;

    public List<GameObject> bloodGushers = new List<GameObject>();
    #endregion

    NinjaAbstractState currentState;

    #region Ninja State Instances
    public NinjaWalkIntoSceneState WalkIntoSceneState = new NinjaWalkIntoSceneState();
    public NinjaIdleState IdleState = new NinjaIdleState();
    public NinjaHopState HopState = new NinjaHopState();
    public NinjaReceivePushState ReceivePushState = new NinjaReceivePushState();
    public NinjaRecoverFromPushState RecoverFromPushState = new NinjaRecoverFromPushState();
    public NinjaFrozenState FrozenState = new NinjaFrozenState();
    public NinjaReadyToAttackState ReadyToAttackState = new NinjaReadyToAttackState();
    public NinjaInitiateAttackState InitiateAttackState = new NinjaInitiateAttackState();
    public NinjaFinalizeAttackState FinalizeAttackState = new NinjaFinalizeAttackState();
    public NinjaVictoryWalkState VictoryWalkState = new NinjaVictoryWalkState();
    public NinjaCinematicPrepForFinalAttackState CinematicPrepForFinalAttackState = new NinjaCinematicPrepForFinalAttackState();
    public NinjaHurtState HurtState = new NinjaHurtState();
    public NinjaDieState DieState = new NinjaDieState();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startDistanceToSquid = Vector3.Distance(transform.position, squidTrn.position);
        ninjaStartRotation = transform.rotation;
        /*
         * First state will be assigned by GameManager
         * GameLevelEnterState
        currentState = IdleState;
        currentState.EnterState(this);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState.isStateInitialized == true)
            currentState.UpdateState(this);
    }

    void FixedUpdate()
    {
        currentState.ApplyGravityState(this);
    }

    public void SwitchState(NinjaAbstractState newState)
    {
        if (currentState != null)
            currentState.ExitState(this);

        newState.EnterState(this);
        currentState = newState;
    }

    public NinjaAbstractState GetCurrentState()
    {
        return currentState;
    }

    public void SetUpVictoryWalkCorridor()
    {
        Instantiate(victoryWalkCorridorPref);
    }

    public void DimTheLights()
    {
        StartCoroutine(DimLights());
    }

    IEnumerator DimLights()
    {
        yield return new WaitForSeconds(0.1f);
        float lastIntensity = 0;
        foreach(Light thisLight in lights)
        {
            if(thisLight.intensity > 0.1f)
                thisLight.intensity -= 0.05f;

            lastIntensity = thisLight.intensity;
        }

        if (lastIntensity > 0.15f)
            StartCoroutine(DimLights());

    }

    public void Victory()
    {
        gameManager.GameIsWon();
    }
}
