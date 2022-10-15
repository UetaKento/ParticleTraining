using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatorStateMachineUtil))]
[RequireComponent(typeof(Animator))]
[DefaultExecutionOrder(-1)]

public class StateManager : SingletonMonoBehaviour<StateManager>
{
    private AnimatorStateMachineUtil _fsmUtil;

    private Animator _stateMachine;
    public Animator StateMachine => _stateMachine;

    private void OnEnable()
    {
        _fsmUtil = GetComponent<AnimatorStateMachineUtil>();
        _stateMachine = GetComponent<Animator>();
    }

    public void ChangeState(State state)
    {
        _fsmUtil.ChangeStateTo(state.ToString());
    }

    public void ChangeState(string stateName)
    {
        _fsmUtil.ChangeStateTo(stateName);
    }
}
