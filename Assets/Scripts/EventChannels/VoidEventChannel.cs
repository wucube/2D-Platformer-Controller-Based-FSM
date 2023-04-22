using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件频道
/// </summary>
[CreateAssetMenu(menuName = "Data/EventChannels/VoidEventChannel",fileName = "VoidEventChannel_")]
public class VoidEventChannel : ScriptableObject
{
    private event System.Action Delegate;

    /// <summary>
    /// 广播事件
    /// </summary>
    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    /// <summary>
    /// 订阅事件
    /// </summary>
    /// <param name="action"></param>
    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    /// <summary>
    /// 退订事件
    /// </summary>
    /// <param name="action"></param>
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
