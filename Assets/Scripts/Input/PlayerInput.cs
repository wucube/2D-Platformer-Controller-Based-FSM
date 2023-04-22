using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// 玩家输入类
/// </summary>
public class PlayerInput:MonoBehaviour
{
    /// <summary>
    /// 跳跃输入缓冲时间
    /// </summary>
    [SerializeField] private float jumpInputBufferTime = 0.5f;
    
    /// <summary>
    /// 跳跃输入缓冲的等待窗口
    /// </summary>
    private WaitForSeconds waitJumpInputBufferTime;

    /// <summary>
    /// 玩家输入动作表类
    /// </summary>
    private PlayerInputActions playerInputActions;

    /// <summary>
    /// 获取轴方向输入信号
    /// </summary>
    private Vector2 axis => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();
    /// <summary>
    /// 获取输入轴的x轴
    /// </summary>
    public float AxisX => axis.x;
    /// <summary>
    /// 根据x轴判断是否有水平移动输入。玩家移动只用到左右移动。
    /// </summary>
    public bool Move => AxisX != 0f;

    /// <summary>
    /// 是否有跳跃输入的缓存
    /// </summary>
    public bool HasJumpInputBuffer { get; set; }
    /// <summary>
    /// 判断是否按下跳跃键
    /// </summary>
    public bool Jump => playerInputActions.GamePlay.Jump.WasPerformedThisFrame(); //主体表达式
    /// <summary>
    /// 判断是否松开按键
    /// </summary>
    public bool StopJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();
   
   void Awake()
    {
        playerInputActions = new PlayerInputActions();

        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime);
    }
    private void OnEnable()
    {
        //跳跃键松开时，跳跃输入缓冲设置为False
        playerInputActions.GamePlay.Jump.canceled+= delegate { HasJumpInputBuffer = false; };
    }

    // private void OnGUI()
    // {
    //     Rect rect = new Rect(200, 200, 200, 200);
    //     string message = "Has Jump Input Buffer:" + HasJumpInputBuffer;
    //     GUIStyle style = new GUIStyle();
    //     style.fontSize = 20;
    //     style.fontStyle = FontStyle.Bold;
    //     GUI.Label(rect,message,style);
    // }

    /// <summary>
    /// 启用玩家输入
    /// </summary>
    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
    /// <summary>
    /// 关闭玩家输入
    /// </summary>
    public void DisableGameplayInputs()
    {
        playerInputActions.GamePlay.Disable();
    }

    /// <summary>
    /// 设置跳跃输入缓冲
    /// </summary>
    public void SetJumpInputBufferTimer()
    {
        //先停止协程再开始协程，防止协程重复开启
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }
    /// <summary>
    /// 跳跃缓冲输入时间窗口
    /// </summary>
    /// <returns></returns>
    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;
        yield return waitJumpInputBufferTime;
        HasJumpInputBuffer = false;
    }

   
}
