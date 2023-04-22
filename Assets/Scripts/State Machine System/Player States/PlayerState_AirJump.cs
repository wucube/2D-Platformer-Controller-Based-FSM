using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 空中跳跃状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJump",fileName = "PlayerState_AirJump")]
public class PlayerState_AirJump : PlayerState
{
    /// <summary>
    /// 跳跃的力
    /// </summary>
    [SerializeField] private float jumpForce = 7f;
    /// <summary>
    /// 移动速度
    /// </summary>
    [SerializeField] private float moveSpeed = 5f;

    /// <summary>
    /// 粒子特效
    /// </summary>
    [SerializeField] private ParticleSystem jumpVFX;

    /// <summary>
    /// 跳跃音效
    /// </summary>
    [SerializeField] private AudioClip jumpSFX;


    /// <summary>
    /// 进入空中跳跃状态：播放动画、计时，取消空中跳跃能力，刚体添加Y轴的力，播放音效与声效
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        //进入空中跳跃状态，立即取消空中跳能力
        player.CanAirJump = false;

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
