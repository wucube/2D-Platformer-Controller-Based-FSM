using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ʤ����ʯ����ű�
/// </summary>
public class VictoryGem : MonoBehaviour
{
    /// <summary>
    /// ͨ���¼�Ƶ������
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
