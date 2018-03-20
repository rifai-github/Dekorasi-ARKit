using UnityEngine;
using System;
using BaseApps;
using System.Collections;
using System.Collections.Generic;


public abstract class FSMState
{
    protected MonoBehaviour _FSMCaller;
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();
    protected StateID stateID;
    public StateID _PreviousState;
    public StateID ID { get { return stateID; } }
    public StateID PreviousSTATE_ID { get { return _PreviousState; } }

    public void AddTRANSITION(Transition trans, StateID id)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("The Transition is error");
            return;
        }

        if (id == StateID.NullStateID)
        {
            Debug.LogError("The State is error");
            return;
        }

        if (map.ContainsKey(trans))
        {
            Debug.LogError("The FSM already have this transition for state");
            return;
        }
        map.Add(trans, id);
    }

    public void DeleteTransition(Transition trans)
    {
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("The Transition is null, or not fully initialized");
            return;
        }

        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }

        Debug.Log("The Transition is not on the transition _Map");
    }

    public StateID GetOutputState(Transition trans)
    {
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }

        return StateID.NullStateID;
    }

    public virtual void OnEnter() { }

    public virtual void OnLeave() { }

    public virtual void Update() { }

    public void SetFSMCaller(MonoBehaviour inMonoScript)
    {

        _FSMCaller = inMonoScript;
    }
}

public class FSMSystem
{
    private List<FSMState> states;

    private StateID currentStateID;
    public StateID GetCurrentStateID { get { return currentStateID; } }
    private FSMState currentState;
    public FSMState GetCurrentState { get { return currentState; } }
    private MonoBehaviour caller;
    public MonoBehaviour GetCaller { get { return caller; } }

    public FSMSystem(MonoBehaviour fsmCaller)
    {
        states = new List<FSMState>();
        caller = fsmCaller;
    }
    public void AddState(FSMState stateToAdd)
    {
        if (stateToAdd == null)
        {
            Debug.LogError("there is no state to add");
        }

        stateToAdd.SetFSMCaller(caller);

        if (states.Count == 0)
        {
            states.Add(stateToAdd);
            currentState = stateToAdd;
            currentStateID = stateToAdd.ID;
            currentState.OnEnter();
            return;
        }

        foreach (FSMState state in states)
        {
            if (state.ID == stateToAdd.ID)
            {
                Debug.LogError("state is already there");
                return;
            }
        }
        states.Add(stateToAdd);
    }

    public void DeleteState(StateID stateID)
    {
        if (stateID == StateID.NullStateID)
        {
            Debug.LogError("the state id is null");
            return;
        }

        foreach (FSMState state in states)
        {
            if (state.ID == stateID)
            {
                states.Remove(state);
                return;
            }
        }
        Debug.LogError("the state is not found in the fsm map");
    }

    public void PerformTransition(Transition transition)
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("the transition is null");
            return;
        }

        StateID stateID = currentState.GetOutputState(transition);
        if (stateID == StateID.NullStateID)
        {
            Debug.LogError("the state of transition is null ::" + currentState.ID.ToString() + transition.ToString());
            return;
        }

        currentStateID = stateID;
        StateID previousState = currentState.ID;
        foreach (FSMState state in states)
        {
            if (state.ID == currentStateID)
            {
                currentState.OnLeave();
                currentState = state;
                currentState._PreviousState = previousState;
                currentState.OnEnter();
                break;
            }
        }
    }
}