using UnityEngine;

/// <summary>
/// メイド生成機
/// </summary>
public class MaidGenerator : MonoBehaviour
{
    /// <summary>
    /// 生成間隔
    /// </summary>
    private float interval = 3.0f;
    /// <summary>
    /// 秒数カウント
    /// </summary>
    private float sec;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        this.sec = 6;
    }

    /// <summary>
    /// プレイ中ならinterval秒ごとに生成
    /// </summary>
    void Update()
    {
        if (!GamePlayManager.GetInstance().GetIsPlay())
        {
            return;
        }
        this.sec += Time.deltaTime;
        if (this.sec > this.interval)
        {
            this.Generate();
            this.sec = 0;
        }
    }

    /// <summary>
    /// メイドさん生成
    /// </summary>
    private void Generate()
    {
        // Debug.Log("GENERATE");
        Maid maid = Instantiate(Resources.Load<GameObject>("Prefabs/Maid")).GetComponent<Maid>();
        maid.gameObject.transform.parent = this.gameObject.transform;

        // 本当は乱数で決定
        System.Random random = new System.Random();
        float x = random.Next() % 11 - 5;
        Vector3 pos = new Vector3(x, 3, 0);

        MaidType type = MaidType.NORMAL;
        switch (random.Next() % 5)
        {
            case 0:
                type = MaidType.NORMAL;
                break;
            case 1:
                type = MaidType.CHINA;
                break;
            case 2:
                type = MaidType.SCHOOL;
                break;
            case 3:
                type = MaidType.WATER;
                break;
            case 4:
                // type = MaidType.OTAKU;
                break;
        }

        maid.Generated(type, pos);
    }
}

