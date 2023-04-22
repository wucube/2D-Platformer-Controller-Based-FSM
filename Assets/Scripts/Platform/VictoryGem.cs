using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 胜利宝石对象脚本
/// </summary>
public class VictoryGem : MonoBehaviour
{
    /// <summary>
    /// 通关事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel LevelClearedEventChannel;

    [SerializeField] private AudioClip pickUpSFX;

    [SerializeField] private ParticleSystem pickUpVFX;

    private void OnTriggerEnter(Collider other)
    {
        LevelClearedEventChannel.Broadcast();

        SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);

        Instantiate(pickUpVFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
