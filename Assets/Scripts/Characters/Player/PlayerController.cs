using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 玩家控制器
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 游戏通关事件频道变量
    /// </summary>
    [SerializeField] private VoidEventChannel levelClearedEventChannel;

    /// <summary>
    /// 地面接触检测器
    /// </summary>
    private PlayerGroundDetector groundDetector;

    private PlayerInput input;

    private Rigidbody rigidbody;
    
    /// <summary>
    /// 玩家是否胜利
    /// </summary>
    public bool Victory { get; private set; }

    /// <summary>
    /// 语音音源
    /// </summary>
    public AudioSource VoicePlayer { get; private set; }

    /// <summary>
    /// 玩家是否能在空中跳跃
    /// </summary>
    public bool CanAirJump { get; set; }


    /// <summary>
    /// 玩家移动速度，取玩家刚体速度X轴值的绝对值。
    /// </summary>
    public float MoveSpeed => Mathf.Abs(rigidbody.velocity.x);


    /// <summary>
    /// 玩家是否在地面上
    /// </summary>
    public bool IsGrounded => groundDetector.IsGround;

    /// <summary>
    /// 玩家是否正在下落。玩家刚体速度为负 且 不在地面上，就在下落
    /// </summary>
    public bool IsFalling => rigidbody.velocity.y < 0f && !IsGrounded;

    void Awake()
    {
        //取得地面检测器脚本组件
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();

        input = GetComponent<PlayerInput>();

        rigidbody = GetComponent<Rigidbody>();

        //获取子物体，语音播放器上的音源组件
        VoicePlayer = GetComponentInChildren<AudioSource>();
    }
    void Start()
    {
        input.EnableGamePlayInputs();
    }

    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(OnLevelCleared);
    }

    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(OnLevelCleared);
    }

    /// <summary>
    /// 通关事件处理器
    /// </summary>
    private void OnLevelCleared()
    {
        Victory = true;
    }
    /// <summary>
    /// 玩家失败函数
    /// </summary>
    public void OnDefeated()
    {
        //关闭玩家输入
        input.DisableGameplayInputs();
        //进入漂浮状态，刚体速度为0
        rigidbody.velocity = Vector3.zero;
        //取消重力影响
        rigidbody.useGravity = false;
        //关闭玩家碰撞检测，防止与尖刺产生新碰撞
        rigidbody.detectCollisions = false;
        //通过状态机，将玩家切换到失败状态
        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }

    /// <summary>
    /// 根据水平轴的输入，移动角色，改变角色朝向
    /// </summary>
    /// <param name="speed"></param>
    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.AxisX, 1f, 1f);
        }
        //右方向速度为正，左方向输入速度为负，无输入速度为0。契合AxisX的值
        SetVelocityX(speed * input.AxisX);
    }
    /// <summary>
    /// 修改刚体速度
    /// </summary>
    /// <param name="velocity"></param>
    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }
    
    /// <summary>
    /// 设置刚体的X轴的速度，用于左右移动
    /// </summary>
    /// <param name="velocityX"></param>
    public void SetVelocityX(float velocityX)
    {
        rigidbody.velocity = new Vector3(velocityX, rigidbody.velocity.y);
    }

    /// <summary>
    /// 设置刚体的Y轴速度。
    /// </summary>
    /// <param name="velocityY"></param>
    public void SetVelocityY(float velocityY)
    {
        rigidbody.velocity = new Vector3(rigidbody.velocity.x, velocityY);
    }
    /// <summary>
    /// 是否开启玩家刚体的重力
    /// </summary>
    /// <param name="value"></param>
    public void SetUseGravity(bool value)
    {
        rigidbody.useGravity = value;
    }
}
