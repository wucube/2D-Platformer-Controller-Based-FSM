using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 玩家地面检测器
/// </summary>
public class PlayerGroundDetector : MonoBehaviour
{
    /// <summary>
    /// 球型范围检测的半径
    /// </summary>
    [SerializeField] private float detectionRadius = 0.1f;

    /// <summary>
    /// 碰撞层
    /// </summary>
    [SerializeField] private LayerMask groundLayer;

    /// <summary>
    /// 存储接触到的碰撞体
    /// </summary>
    private Collider[] _colliders = new Collider[1];

    /// <summary>
    /// 根据范围检测到的碰撞体数量判断是否与地面接触
    /// </summary>
    public bool IsGround =>
        Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, _colliders, groundLayer) != 0;
    // {
    //     get
    //     {
    //         返回值为Int,投射球检测到的碰撞体数量，
    //         return Physics.OverlapSphereNonAlloc(transform.position,detectionRadius,_colliders,groundLayer)!=0;//相比于上面，不会内存重新分配，不会在运行时产生垃圾回收
    //     }
    // }

    /// <summary>
    /// 投射出来的球显示在编辑器的场景窗口中
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,detectionRadius);
    }

}
