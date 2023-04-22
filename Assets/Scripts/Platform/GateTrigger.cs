using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 门触发器
/// </summary>
public class GateTrigger : MonoBehaviour
{
    /// <summary>
    /// 开门事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel gateTriggeredEventChannel;

    [SerializeField] private AudioClip pickUpSFX;

    [SerializeField] private ParticleSystem pickUpVFX;

    private void OnTriggerEnter(Collider other)
    {

        gateTriggeredEventChannel.Broadcast();

        //实例化拾取视效
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);

        SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);

        Destroy(gameObject);
    }
}
