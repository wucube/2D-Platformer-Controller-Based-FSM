using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClearTimer : MonoBehaviour
{
    [SerializeField] private Text timeText;

    /// <summary>
    /// 游戏开始事件频道，开始计时
    /// </summary>
    [SerializeField] private VoidEventChannel levelStartedEventChannel;
    
    /// <summary>
    /// 游戏结束事件频道，停止计时
    /// </summary>
    [SerializeField] private VoidEventChannel levelClearedEventChannel;

    /// <summary>
    /// 玩家失败时的事件频道，停止计时
    /// </summary>
    [SerializeField] private VoidEventChannel playerDefeatedEventChannel;

    /// <summary>
    /// 通关时间文本显示事件频道
    /// </summary>
    [SerializeField] private StringEventChannel clearTimeTextEventChannel;
    
    /// <summary>
    /// 控制通关时间是否增加
    /// </summary>
    private bool stop = true;
    
    /// <summary>
    /// 通关时间
    /// </summary>
    private float clearTime;

    private void OnEnable()
    {
        levelStartedEventChannel.AddListener(LevelStart);
        levelClearedEventChannel.AddListener(LevelClear);
        playerDefeatedEventChannel.AddListener(HideUI);
    }

    private void OnDisable()
    {
        levelStartedEventChannel.RemoveListener(LevelStart);
        levelClearedEventChannel.RemoveListener(LevelClear);
        playerDefeatedEventChannel.RemoveListener(HideUI);
    }
    
    /// <summary>
    /// 关卡结束(通关)
    /// </summary>
    private void LevelClear()
    {
        HideUI();
        //将计时器的文本传入到胜利画面中
        clearTimeTextEventChannel.Broadcast(timeText.text);
    }

    /// <summary>
    /// 关卡开始
    /// </summary>
    private void LevelStart()
    {
        stop = false;
    }
    /// <summary>
    /// 隐藏计时器UI并停止计时
    /// </summary>
    void HideUI()
    {
        stop = true;
        GetComponent<Canvas>().enabled = false;
    }
    //FixedUpdate()每秒调用五十次，很适合实现时间更新功能，用Update函数也可以
    private void FixedUpdate()
    {
        if(stop) return; //通关时间不增加时，直接返回
        clearTime += Time.fixedDeltaTime;
        //将纯秒数的浮点数值转为标准时间格式
        timeText.text = System.TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
    }
}
