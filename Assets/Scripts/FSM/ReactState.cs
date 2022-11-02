using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactState : IState
{
    private FSM manager;
    private Parameter parameter;

    public ReactState(FSM _manager)
    {
        this.manager = _manager;
        this.parameter = _manager.parameter;
    }

    //进入时
    public void OnEnter()
    {

    }

    //执行时
    public void OnUpdate()
    {

    }

    //退出时
    public void OnExit()
    {

    }
}
