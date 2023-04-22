using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 玩家空闲状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle",fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    /// <summary>
    /// 玩家减速度
    /// </summary>
    [SerializeField] private float deceleration = 5f;

    public override void Enter()
    {
        //animator.Play("Idle");
        base.Enter();
        //currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        //是否有水平移动输入
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        
        //是否按下跳跃键
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }

        //是否与地面接触
        if (!player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
    }

    public override void PhysicUpdate()
    {
        //玩家移动分左右两个方向 乘玩家当前朝向的值
        player.SetVelocityX(currentSpeed * player.transform.localScale.x);
    }
}
