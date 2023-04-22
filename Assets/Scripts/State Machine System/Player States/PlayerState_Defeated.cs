using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家失败状态
/// </summary>
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Defeated",fileName = "PlayerState_Defeated")]
public class PlayerState_Defeated : PlayerState
{
   [SerializeField] private ParticleSystem vfx;
   [SerializeField] private AudioClip[] voice;

   public override void Enter()
   {
      base.Enter();

      //进入失败状态后，播放特效与随机语音
      Instantiate(vfx, player.transform.position, Quaternion.identity);
      AudioClip deathVoice = voice[Random.Range(minInclusive: 0, maxExclusive: voice.Length)];
      player.VoicePlayer.PlayOneShot(deathVoice);
   }

   public override void LogicUpdate()
   {
      //失败状态结束就进入漂浮状态
      if(IsAnimationFinished)
         stateMachine.SwitchState(typeof(PlayerState_Float));
   }
}
