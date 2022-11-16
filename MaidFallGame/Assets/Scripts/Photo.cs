using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 写真立てクラス
/// </summary>
public class Photo : MonoBehaviour
{
    /// <summary>
    /// 写真の保存場所のパス
    /// </summary>
    private const string PATH = "Sprites/Photos/";
    /// <summary>
    /// 写真の
    /// </summary>
    private const float INTERVAL = 5.0f;
    /// <summary>
    /// UI上の画像
    /// </summary>
    private Image image;
    /// <summary>
    /// 秒数カウント
    /// </summary>
    private float sec;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        this.image = this.gameObject.GetComponent<Image>();
        this.image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    /// <summary>
    /// 時間の経過を計測してINTERVAL秒経過したら画像の透明度を0にする
    /// </summary>
    void Update()
    {
        if (this.sec > INTERVAL)
        {
            this.image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
        else
        {
            this.sec += Time.deltaTime;
        }
    }

    /// <summary>
    /// 引数の写真を画像に反映して透明度を100にする
    /// </summary>
    /// <param name="name">写真名</param>
    public void Shot(string name)
    {
        Debug.Log(PATH + name);
        this.sec = 0;
        this.image.sprite = Resources.Load<Sprite>(PATH + name);
        this.image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }

}