using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
/// 失败界面
/// </summary>
public class DefeatScreen : MonoBehaviour
{
    /// <summary>
    /// 玩家失败事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel playerDefeatedEventChannel;

    [SerializeField] private AudioClip[] voice;

    [SerializeField] private Button retryButton;

    [SerializeField] private Button quitButton;

    private void OnEnable()
    {
        playerDefeatedEventChannel.AddListener(ShowUI);

        retryButton.onClick.AddListener(SceneLoader.ReloadScene);

        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }

    private void OnDisable()
    {
        playerDefeatedEventChannel.RemoveListener(ShowUI);

        retryButton.onClick.RemoveListener(SceneLoader.ReloadScene);

        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
    }

    /// <summary>
    /// 显示UI
    /// </summary>
    void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;

        GetComponent<Animator>().enabled = true;

        AudioClip retryVoice = voice[Random.Range(minInclusive: 0, maxExclusive: voice.Length)];

        SoundEffectsPlayer.AudioSource.PlayOneShot(retryVoice);

        Cursor.lockState = CursorLockMode.None;
    }
}
