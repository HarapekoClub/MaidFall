using UnityEngine;

/// <summary>
/// 物理接触判定を持っているクラス用のMonoBehaviour
/// </summary>
public class Colider : MonoBehaviour
{

    /// <summary>
    /// 接触判定をサイズに合わせて初期化
    /// </summary>
    void Start()
    {
        this.Initialize();
        this.gameObject.GetComponent<BoxCollider2D>().size = this.gameObject.GetComponent<RectTransform>().sizeDelta;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    protected virtual void Initialize()
    {

    }

    /// <summary>
    /// 接触時にあたったものがメイドさんならメイドさんの接地判定を呼び出す
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Maid":
                this.OnMaid(collision.gameObject.GetComponent<Maid>());
                break;
            default:
                break;
        }
    }

    protected virtual void OnMaid(Maid maid)
    {
        maid.OnGround();
    }
}
