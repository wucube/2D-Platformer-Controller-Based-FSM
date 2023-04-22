using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家状态
/// </summary>
public class PlayerState: ScriptableObject,IState
{
    /// <summary>
    /// 动画状态名
    /// </summary>
    [SerializeField] private string stateName;

    /// <summary>
    /// 动画机的动画融合时间
    /// </summary>
    [SerializeField, Range(0f, 1f)] private float transitionDuration = 0.1f;

    /// <summary>
    /// 状态开始的时间
    /// </summary>
    private float stateStartTime;

    /// <summary>
    /// 状态的哈希值
    /// </summary>
    private int stateHash;

    /// <summary>
    /// 玩家当前的速度
    /// </summary>
    protected float currentSpeed;
    
    protected Animator animator;

    /// <summary>
    /// 玩家状态机
    /// </summary>
    protected PlayerStateMachine stateMachine;

    /// <summary>
    /// 玩家输入类
    /// </summary>
    protected PlayerInput input;

    /// <summary>
    /// 玩家控制器变量
    /// </summary>
    protected PlayerController player;

    /// <summary>
    /// 动画是否播放完成。根据当前动画状态的持续时间 是否大于等于当前动画的时间长度 取得
    /// </summary>
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    /// <summary>
    /// 动画状态的持续时间。现在时间 - 状态开始时间
    /// </summary>
    protected float StateDuration => Time.time - stateStartTime;

    /// <summary>
    /// 初始化玩家状态
    /// </summary>
    /// <param name="animator">动画机</param>
    /// <param name="input">玩家输入类</param>
    /// <param name="player">玩家控制器</param>
    /// <param name="stateMachine">玩家状态机</param>
    public void Initialize(Animator animator, PlayerInput input,PlayerController player,PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.input = input;
        this.player = player;
        this.stateMachine = stateMachine;
    }

    //取得动画字符串转哈希值
    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    /// <summary>
    /// 进入状态时播放动画并记录状态开始的
    /// </summary>
    public virtual void Enter()
    {
        //播放有融合时间的动画
        animator.CrossFade(stateHash,transitionDuration);
        //进入状态时，记录状态开始时间
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
