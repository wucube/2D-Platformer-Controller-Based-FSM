using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态机基类
/// </summary>
public class StateMachine : MonoBehaviour
{
    /// <summary>
    /// 当前状态
    /// </summary>
    private IState currentState;
    /// <summary>
    /// 状态映射表
    /// </summary>
    protected Dictionary<System.Type, IState> stateTable;
    // Update is called once per frame
    void Update()
    {
        currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }

    /// <summary>
    /// 启动状态
    /// </summary>
    /// <param name="newState">要启动的新状态</param>
    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="newState">要切换的新状态</param>
    public void SwitchState(IState newState)
    {
        //先退出当前状态
        currentState.Exit();
        //对当前状态重新赋值并启动
        SwitchOn(newState);
    }
    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="newStateType">要切换的新状态的Type</param>
    public void SwitchState(System.Type newStateType)
    {
        SwitchState(stateTable[newStateType]);
    }
}
