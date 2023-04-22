using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家跳跃状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/JumpUp",fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
   /// <summary>
   /// 跳跃的力
   /// </summary>
   [SerializeField] private float jumpForce = 7f;

   /// <summary>
   /// 移动速度
   /// </summary>
   [SerializeField] private float moveSpeed = 5f;

   [SerializeField] private ParticleSystem jumpVFX;

   [SerializeField] private AudioClip jumpSFX;
   public override void Enter()
   {
      base.Enter();
      //进入跳跃状态，取消跳跃缓冲输入
      input.HasJumpInputBuffer = false;

      player.SetVelocityY(jumpForce);

      player.VoicePlayer.PlayOneShot(jumpSFX);
      Instantiate(jumpVFX, player.transform.position, Quaternion.identity);
   }
   public override void LogicUpdate()
   {
      //没按跳跃按键， 立即进入掉落状态
      if (input.StopJump||player.IsFalling)
      {
         stateMachine.SwitchState(typeof(PlayerState_Fall));
      }
   }
   public override void PhysicUpdate()
   {
      //传入到玩家移动函数中
      player.Move(moveSpeed);
   }
}
