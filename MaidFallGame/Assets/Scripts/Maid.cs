using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メイドさん
/// </summary>
public class Maid : Colider
{
    /// <summary>
    /// 位置情報
    /// </summary>
    private Vector3 position;
    /// <summary>
    /// 種類
    /// </summary>
    private MaidType type;
    /// <summary>
    /// 秒数カウント
    /// </summary>
    private float sec;
    /// <summary>
    /// 落下状態 初期値 true
    /// </summary>
    private bool isFall;
    /// <summary>
    /// 落下間隔
    /// </summary>
    private const float INTERVAL = 1.0f;

    // Update is called once per frame
    /// <summary>
    /// ゲーム中なら落下する、落下中じゃなくなったら消える
    /// </summary>
    void Update()
    {
        if (!GamePlayManager.GetInstance().GetIsPlay())
        {
            return;
        }
        sec += Time.deltaTime;
        if (this.sec > INTERVAL)
        {
            if (isFall)
            {
                this.Down();
            }
            else
            {
                this.Delete();
            }
            sec = 0;
        }

    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Initialize()
    {
        this.position = this.transform.position;
        // Debug.Log(this.position);
        // Debug.Log(this.gameObject.transform.localScale);
        this.sec = 0;
        this.isFall = true;
        base.Initialize();
    }

    /// <summary>
    /// 生成時の処理
    /// </summary>
    /// <param name="type">メイド種類</param>
    /// <param name="pos">生成位置</param>
    public void Generated(MaidType type, Vector3 pos)
    {
        this.type = type;
        this.position = pos;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        this.gameObject.transform.position = this.position;
        this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Maids/" + type + "_" + MaidPause.HEART);
    }

    /// <summary>
    /// 種類のゲッター
    /// </summary>
    /// <returns></returns>
    public MaidType GetMaidType()
    {
        return this.type;
    }

    /// <summary>
    /// 落下
    /// </summary>
    private void Down()
    {
        this.position.y -= 1;
        this.gameObject.transform.position = this.position;
        // Debug.Log("pos: " + this.position);
    }

    /// <summary>
    /// 接地
    /// </summary>
    public void OnGround()
    {
        this.isFall = false;
        this.sec = 0;
    }

    /// <summary>
    /// 接触
    /// </summary>
    /// <param name="collision"></param>
    protected override void OnCollisionEnter2D(Collision2D collision)
    {

    }

    /// <summary>
    /// 削除
    /// </summary>
    private void Delete()
    {
        Debug.Log("good bye");
        Destroy(this.gameObject);
    }
}
