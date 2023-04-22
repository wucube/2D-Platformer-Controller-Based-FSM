using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������Žű�
/// </summary>
public class SoundEffectsPlayer : MonoBehaviour
{
    public static AudioSource AudioSource { get; private set; }
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.playOnAwake = false;
    }
}
