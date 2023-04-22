using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家着陆状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    /// <summary>
    /// 玩家僵直时间
    /// </summary>
    [SerializeField] private float stiffTime = 0.2f;

    //着地特效
    [SerializeField] private ParticleSystem landVFX;

    public override void Enter()
    {
        base.Enter();
        //落地后不能二段跳
        player.CanAirJump = false;
        //玩家停止移动
        player.SetVelocity(Vector3.zero);
        //创建着地特效
        Instantiate(landVFX, player.transform.position, Quaternion.identity);
    }
    public override void LogicUpdate()
    {
        // 如果玩家胜利，则进入胜利状态
        if (player.Victory)
        {
            stateMachine.SwitchState(typeof(PlayerState_Victory));
        }

        //存在跳跃缓冲输入 或 按跳跃键，进入跳跃状态
        if (input.HasJumpInputBuffer || input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        //如果当前状态持续时间小于硬值时间，则返回
        if (StateDuration < stiffTime) return;

        //如果有水平移动输入，就进入跑步状态
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        //如果当前状态的动画播放完毕，就进入闲置状态
        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
       
    }
}