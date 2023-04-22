using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 星星宝石类
/// </summary>
public class StarGem : MonoBehaviour
{
    /// <summary>
    /// 重生的时间
    /// </summary>
    [SerializeField] private float resetTime = 3.0f;
    //拾取音效
    [SerializeField] private AudioClip pickUpSFX;
    //拾取粒子特效
    [SerializeField] private ParticleSystem pickUpVFX;

    private Collider _collider;
    private MeshRenderer _meshRenderer;
    private WaitForSeconds _waitResetTime;
    private void Awake()
    {
        
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _waitResetTime = new WaitForSeconds(resetTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            player.CanAirJump = true;
            //关掉星星的碰撞体和网格渲染器
            _collider.enabled = false;
            _meshRenderer.enabled = false;
            //播放音效
            SoundEffectsPlayer.AudioSource.PlayOneShot(pickUpSFX);
            Instantiate(pickUpVFX, transform.position, transform.rotation);
            //Invoke(nameof(Reset),resetTime);
            StartCoroutine(ResetCoroutine());//使用协程替代延迟调用函数，性能会更好一些
        }
    }
    //宝石重生
    private void Reset()
    {
        _collider.enabled = true;
        _meshRenderer.enabled = true;
    }

    IEnumerator ResetCoroutine()
    {
        yield return _waitResetTime;
        Reset();
    }
}
