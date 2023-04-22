using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家下落状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall",fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
   /// <summary>
   /// 动画曲线
   /// </summary>
   [SerializeField] private AnimationCurve speedCurve;

   [SerializeField] private float moveSpeed = 5f;
   
   public override void LogicUpdate()
   {
      if (player.IsGrounded)
      {
         stateMachine.SwitchState(typeof(PlayerState_Land));
      }
      
      if (input.Jump)
      {
         if (player.CanAirJump)
         {
            stateMachine.SwitchState(typeof(PlayerState_AirJump));
            return;
         }

         //掉落状态中，按下跳跃键，不能二段跳，就记录跳跃缓冲
         //input.HasJumpInputBuffer = true;
         //跳跃输入缓冲经过一片时间后，或者再次起跳后，跳跃输入缓冲为False
         input.SetJumpInputBufferTimer();

      }
   }
   public override void PhysicUpdate()
   {
      //根据状态持续时间，取得减少的值。将该值设为刚体Y轴值，实现掉落速度的完全可控。
      player.Move(moveSpeed);

      player.SetVelocityY(speedCurve.Evaluate(StateDuration));
   }
}
