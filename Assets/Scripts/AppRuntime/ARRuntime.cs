using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseApps;

public class ARRuntime : AppRuntime
{
    void Start()
    {
        MakeFSM();
    }

    protected override void MakeFSM()
    {
        LoginState loginState = new LoginState();
        loginState.AddTRANSITION(Transition.TRANSITION_TO_REGISTER, StateID.REGISTER);
        
        _FSM = new FSMSystem(this);
        _FSM.AddState(loginState);

        base.MakeFSM();
    }
}
