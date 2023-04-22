using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家漂浮状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Float",fileName = "PlayerState_Float")]
public class PlayerState_Float : PlayerState
{
    /// <summary>
    /// 玩家失败事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel playerDefeatedEventChannel;

    /// <summary>
    /// 漂浮速度
    /// </summary>
    [SerializeField] private float floatingSpeed = 0.5f;

    /// <summary>
    /// 漂浮偏移位置，死亡后首先漂浮至的位置
    /// </summary>
    [SerializeField] private Vector3 floatingPositionOffset;

    /// <summary>
    /// 视效偏移位置
    /// </summary>
    [SerializeField] private Vector3 vfxOffset;

    [SerializeField] private ParticleSystem vfx;

    /// <summary>
    /// 下一个随机移动点
    /// </summary>
    private Vector3 floatingPosition;


    public override void Enter()
    {
        base.Enter();

        //广播玩家失败事件频道
        playerDefeatedEventChannel.Broadcast();

        Transform playerTransform = player.transform;
        //修正特效的生成位置
        Vector3 vfxPosition = playerTransform.position + new Vector3(playerTransform.localScale.x * vfxOffset.x, vfxOffset.y); 
        Instantiate(vfx, vfxPosition, Quaternion.identity, playerTransform);

        //更新随机移动点值 玩家当前位置+偏移值
        floatingPosition = player.transform.position + floatingPositionOffset;
    }
    public override void LogicUpdate()
    {
        //玩家持续朝随机移动点移动
        Transform playerTransform = player.transform;

        //如果玩家当前位置与目标漂浮点位置大于每帧的移动距离，则让角色朝目标点位移
        if (Vector3.Distance(playerTransform.position, floatingPosition) > floatingSpeed * Time.deltaTime)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, floatingPosition,floatingSpeed * Time.deltaTime);
        }
        //否则让目标点随机改变位置
        else
        {
            floatingPosition += (Vector3)Random.insideUnitCircle;
        }
    }
}
