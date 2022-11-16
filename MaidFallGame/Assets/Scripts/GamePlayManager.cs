using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ゲームのプレイ状況マネージャー
/// </summary>
public class GamePlayManager
{
    /// <summary>
    /// インスタンス
    /// </summary>
    private static GamePlayManager instance;
    private Player player;

    private ResultDisplay result;

    private List<string> newPhotos;
    private Dictionary<string, int> photoCount;

    /// <summary>
    /// プレイ状態 初期値falseにする予定だけど今はTrue
    /// </summary>
    private bool isPlay;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GamePlayManager()
    {
        this.isPlay = false;
    }

    /// <summary>
    /// ゲッター
    /// </summary>
    /// <returns>instance</returns>
    public static GamePlayManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GamePlayManager();
        }
        return instance;
    }

    /// <summary>
    /// プレイ状態ゲッター
    /// </summary>
    /// <returns></returns>
    public bool GetIsPlay()
    {
        return this.isPlay;
    }

    public void SetResult(ResultDisplay result)
    {
        this.result = result;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public Player GetPlayer()
    {
        return this.player;
    }


    public void AddPhoto(string name)
    {
        if (!AlbumManager.GetInstance().GetIsShot(name))
        {
            if (!this.newPhotos.Contains(name))
            {
                this.newPhotos.Add(name);
            }
            AlbumManager.GetInstance().SetIsShot(name, true);
        }
        this.photoCount[name] += 1;
    }

    /// <summary>
    /// 一時停止
    /// </summary>
    public void Pause()
    {
        this.isPlay = false;
        GameObject.FindGameObjectWithTag("Pause").SetActive(true);
    }

    /// <summary>
    /// 再開
    /// </summary>
    public void Start()
    {
        this.isPlay = true;
        GameObject.FindGameObjectWithTag("Pause").SetActive(false);
    }

    /// <summary>
    /// ゲーム開始時の処理
    /// </summary>
    public void GameStart()
    {
        this.isPlay = true;
        this.newPhotos = new List<string>();
        this.photoCount = new Dictionary<string, int>();
        this.photoCount.Add("NORMAL_HEART_HEART", 0);
        this.photoCount.Add("CHINA_HEART_HEART", 0);
        this.photoCount.Add("SCHOOL_HEART_HEART", 0);
        this.photoCount.Add("WATER_HEART_HEART", 0);
        this.photoCount.Add("OTAKU_HEART_HEART", 0);
    }

    /// <summary>
    /// ゲーム終了
    /// </summary>
    public void GameFinish()
    {
        this.isPlay = false;
        //GameObject.FindGameObjectWithTag("Play").SetActive(false);
        this.result.gameObject.SetActive(true);
        GameManager.GetInstance().GameFinish();
        this.result.GameFinish(this.newPhotos, this.photoCount);
    }
}