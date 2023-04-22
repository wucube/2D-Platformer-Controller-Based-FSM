using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 胜利界面
/// </summary>
public class VictoryScreen : MonoBehaviour
{
    /// <summary>
    /// 玩家通关的事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel levelClearedEventChannel;

    [SerializeField] private Button nextLevelButton;

    /// <summary>
    /// 显示通关时间的事件频道
    /// </summary>
    [SerializeField] private StringEventChannel clearTimeTextEventChannel;

    [SerializeField] private Text timeText;

    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(ShowUI);

        //通关时间文本显示事件频道订阅设置文本函数
        clearTimeTextEventChannel.AddListener(SetTimeText);

        nextLevelButton.onClick.AddListener(SceneLoader.LoadNextScene);
    }
    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(ShowUI);
        //通关时间文本显示事件频道退订设置文本函数
        clearTimeTextEventChannel.RemoveListener(SetTimeText);
        nextLevelButton.onClick.RemoveListener(SceneLoader.LoadNextScene);
    }
    
    /// <summary>
    /// 设置时间文本的值
    /// </summary>
    /// <param name="obj"></param>
    private void SetTimeText(string obj)
    {
        timeText.text = obj;
    }

    /// <summary>
    /// 显示UI
    /// </summary>
    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
}
