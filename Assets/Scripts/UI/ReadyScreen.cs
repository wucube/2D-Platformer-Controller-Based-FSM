using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ׼������
/// </summary>
public class ReadyScreen : MonoBehaviour
{
    /// <summary>
    /// �ؿ���ʼ���¼�Ƶ������
    /// </summary>
    [SerializeField] private VoidEventChannel levelStartedEventChannel;

    [SerializeField] private AudioClip startVoice;

    /// <summary>
    /// �ؿ���ʼ-׼������Ķ����¼�����
    /// </summary>
    void LevelStart()
    {
        levelStartedEventChannel.Broadcast();

        GetComponent<Canvas>().enabled = false;

        GetComponent<Animator>().enabled = false;
    }
    /// <summary>
    /// ��������-׼������Ķ����¼�����
    /// </summary>
    void PlayStartVoice()
    {
        SoundEffectsPlayer.AudioSource.PlayOneShot(startVoice);
    }
}
