using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 土狼时间状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime",fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    /// <summary>
    /// 跑步速度
    /// </summary>
    [SerializeField] private float runSpeed = 5f;

    /// <summary>
    /// 土狼时间的持续时间
    /// </summary>
    [SerializeField]private float coyoteTime = 0.1f;

    public override void Enter()
    {
        base.Enter();
        //取消重力影响
        player.SetUseGravity(false);
    }
    public override void Exit()
    {
        //重启重力影响
        player.SetUseGravity(true);
    }
    public override void LogicUpdate()
    {
        //计时到达或松开按键就下落
        if (StateDuration>coyoteTime||!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
    }
    //物理更新写入物理状态更新函数中
    public override void PhysicUpdate()
    {
        //player.SetVelocityX(runSpeed);
        //player.Move(runSpeed);
      
        //传入当前速度
        player.Move(runSpeed);
    }
}
