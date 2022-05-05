
/// <summary>
/// ゲームのプレイ状況マネージャー
/// </summary>
public class GamePlayManager
{
    /// <summary>
    /// インスタンス
    /// </summary>
    private static GamePlayManager instance;
    /// <summary>
    /// プレイ状態 初期値falseにする予定だけど今はTrue
    /// </summary>
    private bool isPlay;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GamePlayManager()
    {
        this.isPlay = true;
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

    /// <summary>
    /// 一時停止
    /// </summary>
    public void Pause()
    {
        this.isPlay = false;
    }

    /// <summary>
    /// 再開
    /// </summary>
    public void Start()
    {
        this.isPlay = true;
    }

    /// <summary>
    /// ゲーム終了
    /// </summary>
    public void GameFinish()
    {
        this.isPlay = false;
    }
}