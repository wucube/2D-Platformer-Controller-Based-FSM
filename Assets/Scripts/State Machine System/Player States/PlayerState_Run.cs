using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 玩家跑步状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run",fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
   /// <summary>
   /// 跑步速度
   /// </summary>
   [SerializeField] private float runSpeed = 5f;

   /// <summary>
   /// 玩家加速度
   /// </summary>
   [SerializeField] private float acceleration = 5f;

   public override void Enter()
   {
      //animator.Play("Run");
      base.Enter();
      currentSpeed = player.MoveSpeed;
   }

   public override void LogicUpdate()
   {
      //如果没有水平移动输入
      if (!input.Move)
      {
         stateMachine.SwitchState(typeof(PlayerState_Idle));
      }
      //如果按下跳跃键
      if (input.Jump)
      {
         stateMachine.SwitchState(typeof(PlayerState_JumpUp));
      }
      //不与地面接触就切换到土狼时间状态
      if (!player.IsGrounded)
      {
         stateMachine.SwitchState(typeof(PlayerState_CoyoteTime));
      }
      currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, acceleration * Time.deltaTime);
   }
   
   //物理更新写入物理状态更新函数中
   public override void PhysicUpdate()
   {
      //player.SetVelocityX(runSpeed);
      //player.Move(runSpeed);
      
      //传入当前速度
      player.Move(currentSpeed);
   }
}
