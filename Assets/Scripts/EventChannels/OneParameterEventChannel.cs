using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 有一个参数的事件频道
/// </summary>
/// <typeparam name="T">泛型参数</typeparam>
public class OneParameterEventChannel<T> : ScriptableObject
{
    private event System.Action<T> Delegate;

    public void Broadcast(T obj)
    {
        Delegate?.Invoke(obj);
    }

    public void AddListener(Action<T> action)
    {
        Delegate += action;
    }

    public void RemoveListener(Action<T> action)
    {
        Delegate -= action;
    }
}


