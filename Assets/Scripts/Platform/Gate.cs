using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 门对象脚本
/// </summary>
public class Gate : MonoBehaviour
{
    /// <summary>
    /// 开门事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel gateTriggeredEventChannel;
    
    void Start()
    {
        //场景中只有一个门，可用该方法寻找
        //_gateTrigger = FindObjectOfType<GateTrigger>();
    }

    private void OnEnable()
    {
        //开门事件频道监听开门函数
        gateTriggeredEventChannel.AddListener(Open);
    }

    private void OnDisable()
    {
        //开门事件频道移除监听开门函数 
        gateTriggeredEventChannel.RemoveListener(Open);
    }
    
    /// <summary>
    /// 开门后即销毁门物体自身
    /// </summary>
    void Open()
    {
        Destroy(gameObject);
    }
}
