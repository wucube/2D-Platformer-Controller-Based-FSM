using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家状态机
/// </summary>
public class PlayerStateMachine : StateMachine
{
    /// <summary>
    /// 玩家状态数组
    /// </summary>
    [SerializeField] private PlayerState[] states;

    private Animator animator;
    /// <summary>
    /// 玩家输入类
    /// </summary>
    private PlayerInput input;
    /// <summary>
    /// 玩家控制器
    /// </summary>
    private PlayerController player;

    private void Awake()
    {
        //从玩家对象的模型子对象上获取Animator组件
        animator = GetComponentInChildren<Animator>();

        input = GetComponent<PlayerInput>();

        player = GetComponent<PlayerController>();

        stateTable = new Dictionary<Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Initialize(animator,input,player,this);

            stateTable.Add(state.GetType(),state);
        }
    }
    void Start()
    {
        //玩家默认的状态是空闲状态，游戏开始时， 状态机以空闲状态启动

        //SwitchOn(idleState);
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
