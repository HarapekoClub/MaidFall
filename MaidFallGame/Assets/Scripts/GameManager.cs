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
    private bool isFirst = true;
    private AudioSource bgm;
    private AudioSource se;
    [SerializeField] private AudioClip[] bgmData;
    [SerializeField] private AudioClip[] seData;

    void Awake()
    {
        this.se = this.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        this.bgm = this.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.se = this.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        //this.bgm = this.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        if (isFirst) // 初回起動時のみの処理
        {
            this.bgm.clip = this.bgmData[0];
            this.bgm.Play();
            isFirst = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (this.bgm.clip.Equals(this.bgmData[0]))
        {
            if (this.bgm.time >= this.bgmData[0].length)
            {
                Debug.Log("BGM Change");
                this.bgm.clip = this.bgmData[1];
                this.bgm.loop = true;
                this.bgm.Play();
            }
        }
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
        if (!this.bgm.isPlaying)
        {
            this.bgm.clip = this.bgmData[0];
            this.bgm.loop = false;
            this.bgm.time = 0;
            this.bgm.Play();
        }
        DontDestroyOnLoad(instance);
    }

    public void PlaySE(int i)
    {
        if (i >= this.seData.Length)
        {
            return;
        }
        //this.se.clip = this.seData[i];
        this.se.PlayOneShot(this.seData[i]);
    }

    public void GameFinish()
    {
        this.bgm.Stop();

        this.se.PlayOneShot(this.seData[2]);
    }

}
