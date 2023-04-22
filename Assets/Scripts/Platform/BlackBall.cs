using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 黑球对象脚本
/// </summary>
public class BlackBall : MonoBehaviour
{
   /// <summary>
   /// 开门事件频道变量
   /// </summary>
   [SerializeField] private VoidEventChannel gateTriggerEventChannel;

   [SerializeField] private float lifeTime = 10f;

   private void OnEnable()
   {
      gateTriggerEventChannel.AddListener(OnGateTriggered);
   }

   private void OnDisable()
   {
      gateTriggerEventChannel.RemoveListener(OnGateTriggered);
   }

   /// <summary>
   /// 开门事件处理器-销毁黑球
   /// </summary>
   void OnGateTriggered()
   {
      Destroy(gameObject,lifeTime);
   }
   /// <summary>
   /// 碰到玩家，调用玩家失败函数
   /// </summary>
   /// <param name="collision"></param>
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.TryGetComponent(out PlayerController player))
      {
         player.OnDefeated();
      }
   }
}
