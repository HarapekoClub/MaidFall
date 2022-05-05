using System.Collections;
using System.Collections.Generic;

/// <summary>
/// アルバムの管理者
/// シングルトンで実装
/// </summary>
public class AlbumManager
{
    private static AlbumManager instance;

    private Dictionary<string, bool> album;

    private AlbumManager()
    {
        this.album = new Dictionary<string, bool>();
        this.SetAlbum();
    }

    /// <summary>
    /// アルバムのゲッター(シングルトン)
    /// </summary>
    /// <returns></returns>
    public static AlbumManager GetInstance()
    {
        if (instance == null)
        {
            instance = new AlbumManager();
        }
        return instance;
    }

    private void SetAlbum()
    {
        // アルバムの初期設定、全ての写真を非所持
        // 写真名は「メイド衣装_メイドポーズ_プレイヤーポーズ」
        this.album.Add("NORMAL_HEART_HEART", false);
        // this.album.Add("NORMAL_HEART_GOOD", false);
        // this.album.Add("NORMAL_GOOD_HEART", false);
        // this.album.Add("NORMAL_GOOD_GOOD", false);

        this.album.Add("CHINA_HEART_HEART", false);
        // this.album.Add("CHINA_HEART_GOOD", false);
        // this.album.Add("CHINA_GOOD_HEART", false);
        // this.album.Add("CHINA_GOOD_GOOD", false);

        this.album.Add("SCHOOL_HEART_HEART", false);
        // this.album.Add("SCHOOL_HEART_GOOD", false);
        // this.album.Add("SCHOOL_GOOD_HEART", false);
        // this.album.Add("SCHOOL_GOOD_GOOD", false);

        this.album.Add("WATER_HEART_HEART", false);
        // this.album.Add("WATER_HEART_GOOD", false);
        // this.album.Add("WATER_GOOD_HEART", false);
        // this.album.Add("WATER_GOOD_GOOD", false);

        this.album.Add("OTAKU_HEART_HEART", false);
        // this.album.Add("OTAKU_HEART_GOOD", false);
        // this.album.Add("OTAKU_GOOD_HEART", false);
        // this.album.Add("OTAKU_GOOD_GOOD", false);
    }

    /// <summary>
    /// 写真が取られたかどうかを更新する
    /// </summary>
    /// <param name="name">更新する写真名</param>
    /// <param name="isShot">更新する値</param>
    public void SetIsShot(string name, bool isShot)
    {
        if (this.album.ContainsKey(name))
        {
            this.album[name] = isShot;
        }
    }

    /// <summary>
    /// 写真が取られたかどうかを取得する
    /// </summary>
    /// <param name="name">取得する写真名</param>
    /// <returns>撮ったかどうか</returns>
    public bool GetIsShot(string name)
    {
        if (this.album.ContainsKey(name))
        {
            return false;
        }
        return this.album[name];
    }
}