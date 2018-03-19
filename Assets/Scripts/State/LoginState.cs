using System.Collections;
using System.Collections.Generic;
using BaseApps;
using UnityEngine;

public class LoginState : FSMState
{
    public LoginState()
    {
        stateID = StateID.LOGIN;
    }

    public override void OnEnter()
    {
        Debug.Log("Enter ARState");

        base.OnEnter();
    }

    private void TransitionRegisterState()
    {
        AppRuntime appRuntime = _FSMCaller as AppRuntime;
        appRuntime.SetTransition(Transition.TRANSITION_TO_REGISTER);
    }

    private void TransitionToAR()
    {
        
    }

    public override void Update()
    {
        
        base.Update();
    }

    public override void OnLeave()
    {
        Debug.Log("Leave ARState");

        base.OnLeave();
    }
}
