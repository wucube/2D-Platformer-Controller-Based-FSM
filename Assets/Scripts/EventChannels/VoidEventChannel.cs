using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �¼�Ƶ��
/// </summary>
[CreateAssetMenu(menuName = "Data/EventChannels/VoidEventChannel",fileName = "VoidEventChannel_")]
public class VoidEventChannel : ScriptableObject
{
    private event System.Action Delegate;

    /// <summary>
    /// �㲥�¼�
    /// </summary>
    public void Broadcast()
    {
        Delegate?.Invoke();
    }
    /// <summary>
    /// �����¼�
    /// </summary>
    /// <param name="action"></param>
    public void AddListener(System.Action action)
    {
        Delegate += action;
    }
    /// <summary>
    /// �˶��¼�
    /// </summary>
    /// <param name="action"></param>
    public void RemoveListener(System.Action action)
    {
        Delegate -= action;
    }
}
