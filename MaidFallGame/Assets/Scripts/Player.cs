using UnityEngine;
using TMPro;

/// <summary>
/// プレイヤークラス
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// 体力が減る間隔
    /// </summary>
    private const float INTERVAL = 5f;
    /// <summary>
    /// 移動距離
    /// </summary>
    private const float MOVE_SPEED = 0.5f;
    /// <summary>
    /// 秒数カウント
    /// </summary>
    private float sec;
    /// <summary>
    /// 移動方向
    /// </summary>
    private float dir;
    /// <summary>
    /// 体力
    /// </summary>
    private int hp;
    /// <summary>
    /// 位置情報
    /// </summary>
    private Vector3 position;
    /// <summary>
    /// 写真 Unity Editorで設定
    /// </summary>
    [SerializeField] Photo photo;
    [SerializeField] TextMeshProUGUI hpText;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        this.sec = 0;
        this.dir = 0;
        this.hp = 10;
        this.position = this.gameObject.transform.position;
        this.hpText.text = "HP : " + this.hp;
        GamePlayManager.GetInstance().GameStart();
    }

    /// <summary>
    /// プレイ状態だったら移動したり体力減ったり
    /// </summary>
    void Update()
    {
        if (!GamePlayManager.GetInstance().GetIsPlay())
        {
            return;
        }
        this.sec += Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0)
            this.dir = Input.GetAxis("Horizontal");
        if (this.sec > INTERVAL)
        {
            this.AddHP(-1);
            this.sec = 0;
        }


        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            this.Move();
    }

    /// <summary>
    /// 移動
    /// プレイ状態だったらdir方向に, MOVE_SPEED分だけ移動
    /// </summary>
    private void Move()
    {
        if (!GamePlayManager.GetInstance().GetIsPlay())
        {
            return;
        }
        float move = 0f;
        if (dir == 0)
        {
            move = 0;
        }
        else if (dir > 0)
        {
            move = MOVE_SPEED;
        }
        else
        {
            move = -MOVE_SPEED;
        }
        this.dir = 0;
        this.position.x += move;
        this.gameObject.transform.position = this.position;
        this.AddHP(-1);
        GameManager.GetInstance().PlaySE(0);
    }

    /// <summary>
    /// 体力増減
    /// 引数だけ体力を増減させて終了判定
    /// </summary>
    /// <param name="i">増減値</param>
    private void AddHP(int i)
    {
        this.hp += i;
        Debug.Log("HP : " + this.hp);
        this.hpText.text = "HP : " + this.hp;
        if (hp <= 0)
        {
            GamePlayManager.GetInstance().GameFinish();
        }
    }

    /// <summary>
    /// ゲーム終了時の処理
    /// </summary>
    public void GameFinish()
    {
        Debug.Log("Finish");
    }

    /// <summary>
    /// スコア計算と加算, 記録
    /// </summary>
    /// <param name="maid"></param>
    public void Shot(Maid maid)
    {
        this.AddHP(((int)maid.GetMaidType()));
        string photoName = maid.GetMaidType() + "_HEART_HEART";
        this.photo.Shot(photoName);

        GamePlayManager.GetInstance().AddPhoto(photoName);

        AlbumManager.GetInstance().SetIsShot(photoName, true);
        GameManager.GetInstance().PlaySE(1);
    }

}