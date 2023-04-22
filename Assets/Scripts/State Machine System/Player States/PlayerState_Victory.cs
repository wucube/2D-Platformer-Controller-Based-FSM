using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家胜利状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Victory",fileName = "PlayerState_Victory")]
public class PlayerState_Victory : PlayerState
{
    [SerializeField] private AudioClip[] voice;
    public override void Enter()
    {
        base.Enter();
        //进入胜利状态后关闭玩家输入
        input.DisableGameplayInputs();
        //播放胜利语音
        player.VoicePlayer.PlayOneShot(voice[Random.Range(minInclusive:0,maxExclusive:voice.Length)]);
    }
}
