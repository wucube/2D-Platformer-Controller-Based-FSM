using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态接口
/// </summary>
public interface IState
{
    /// <summary>
    /// 状态进入
    /// </summary>
    void Enter();
    /// <summary>
    /// 状态退出
    /// </summary>
    void Exit();
    /// <summary>
    /// 逻辑更新
    /// </summary>
    void LogicUpdate();
    /// <summary>
    /// 物理更新
    /// </summary>
    void PhysicUpdate();
}
