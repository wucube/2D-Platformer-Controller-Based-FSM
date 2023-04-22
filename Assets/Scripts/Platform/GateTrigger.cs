using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ŵ�����
/// </summary>
public class GateTrigger : MonoBehaviour
{
    /// <summary>
    /// �����¼�Ƶ������
    /// </summary>
    [SerializeField] private VoidEventChannel gateTriggeredEventChannel;

    [SerializeField] private AudioClip pickUpSFX;

    [SerializeField] private ParticleSystem pickUpVFX;

    private void OnTriggerEnter(Collider other)
    {

        gateTriggeredEventChannel.Broadcast();

        //ʵ����ʰȡ��Ч
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);

        SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);

        Destroy(gameObject);
    }
}
