using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 准备界面
/// </summary>
public class ReadyScreen : MonoBehaviour
{
    /// <summary>
    /// 关卡开始的事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel levelStartedEventChannel;

    [SerializeField] private AudioClip startVoice;

    /// <summary>
    /// 关卡开始-准备界面的动画事件函数
    /// </summary>
    void LevelStart()
    {
        levelStartedEventChannel.Broadcast();

        GetComponent<Canvas>().enabled = false;

        GetComponent<Animator>().enabled = false;
    }
    /// <summary>
    /// 播放语音-准备界面的动画事件函数
    /// </summary>
    void PlayStartVoice()
    {
        SoundEffectsPlayer.AudioSource.PlayOneShot(startVoice);
    }
}
