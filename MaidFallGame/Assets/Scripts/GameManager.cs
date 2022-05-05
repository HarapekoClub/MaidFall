using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームマネージャー
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    private static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ゲームマネージャーのゲッター
    /// </summary>
    /// <returns></returns>
    public static GameManager GetInstance()
    {
        if (!GameObject.FindGameObjectWithTag("GameManager"))
        {
            Debug.Log("GameManagerを生成します");
            instance = Instantiate(Resources.Load<GameObject>("Prefabs/GameManager")).GetComponent<GameManager>();
        }

        return instance;
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    /// <param name="sceneName">遷移先のシーン名</param>
    public void JumpScene(string sceneName)
    {
        Debug.Log("シーン" + sceneName + "に移動します");
        SceneManager.LoadScene(sceneName);
    }


}
