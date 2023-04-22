using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��һ���������¼�Ƶ��
/// </summary>
/// <typeparam name="T">���Ͳ���</typeparam>
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


