using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum StateType
{
    IDLE, PATROL, CHASE, REACT, ATTACK
}

[Serializable]
public class Parameter
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] partrolPoints;
    public Transform[] chasePoints;
    public Animator animator;
}

public class FSM : MonoBehaviour
{
    public Parameter parameter;

    private IState currentState;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    private void Awake()
    {
        parameter.animator = GetComponent<Animator>();
    }

    void Start()
    {
        states.Add(StateType.IDLE,new IdleState(this));
        states.Add(StateType.IDLE,new PatrolState(this));
        states.Add(StateType.IDLE,new ChaseState(this));
        states.Add(StateType.IDLE,new ReactState(this));
        states.Add(StateType.IDLE,new AttackState(this));

        TransitionState(StateType.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType type)
    {
        if(currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }

    public void FlipTo(Transform target)
    {

    }
}
