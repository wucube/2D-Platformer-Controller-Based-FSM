using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景加载器
/// </summary>
public class SceneLoader 
{
    /// <summary>
    /// 场景重载
    /// </summary>
    public static void ReloadScene()
    {
        //取得当前激活场景下标
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //重新加载激活场景
        SceneManager.LoadScene(sceneIndex);
    }
    /// <summary>
    /// 退出游戏
    /// </summary>
    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    /// <summary>
    /// 加载下个场景
    /// </summary>
    public static void LoadNextScene()
    {
        //得到当前激活场景下标+1，即下个场景
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //场景下标大于所有场景数量，做特殊处理，如加载开始场景
        if (sceneIndex >= SceneManager.sceneCount)
        {
            ReloadScene();
            //提前加载场景后，提前返回
            return;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
