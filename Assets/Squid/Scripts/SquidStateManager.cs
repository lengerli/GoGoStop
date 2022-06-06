using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidStateManager : MonoBehaviour
{
    #region Squid States
    SquidAbstractState currentState;
    public SquidSleepState SleepState = new SquidSleepState();
    public SquidWokeState WokeState = new SquidWokeState();
    public SquidPatrolState PatrolState = new SquidPatrolState();
    public SquidSightAlarmState SightAlarmState = new SquidSightAlarmState();
    public SquidPushState PushState = new SquidPushState();
    public SquidLookAroundState LookAroundState = new SquidLookAroundState();
    public SquidGoToSleepState GoToSleepState = new SquidGoToSleepState();
    public SquidCinematicFreezeState CinematicFreezeState = new SquidCinematicFreezeState();
    public SquidDieState DieState = new SquidDieState();
    #endregion
    #region Variables For States
    public NinjaSightingAlarm sightingAlarm;
    public GameObject eyeForSight;
    public Transform eyeForSightTrnsf;
    public float minSleepTime;
    public float maxSleepTime;
    public NinjaStateManager ninjaStateManager;
    public Rigidbody rgbdy;
    public Animator animator;
    public float patrolPossibility;
    public float minWokeWait;
    public float maxWokeWait;
    public float minPatrolTime;
    public float maxPatrolTime;
    public float turnSpeedForPatrolStart;
    public Quaternion squidStartRotation;
    public float lookAroundPossibility;
    public float lookAroundTime;
    public Quaternion squidBodyRotationAtSightingMoment;
    public Quaternion squidBodyDefaultRotation;
    public Transform squidBodyTrn;
    public bool isNinjaSighted;
    public Vector3 eyePositionAtStart;
    public Vector3 eyePositionAtSight;
    public Quaternion eyeRotationAtSight;
    public Quaternion eyeRotationAtStart;

    public GameObject pushWave;

    public int pushDamage;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        eyeForSight = sightingAlarm.gameObject;
        eyeForSightTrnsf = eyeForSight.transform;
        squidBodyDefaultRotation = squidBodyTrn.rotation;
        squidStartRotation = transform.rotation;
        eyeRotationAtStart = eyeForSightTrnsf.localRotation;
        eyePositionAtStart = eyeForSightTrnsf.localPosition;
        /*
         * First assignment of state is managed by game manager
         * GameLevelEnterState
        currentState = SleepState;
        currentState.EnterState(this);
        */
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(SquidAbstractState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    void LateUpdate()
    {
        if(isNinjaSighted == true)
        {
            eyeForSightTrnsf.position = eyePositionAtSight;
            eyeForSightTrnsf.rotation = eyeRotationAtSight;
        }
    }
}
