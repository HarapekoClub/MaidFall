using UnityEngine;

/// <summary>
/// 物理接触判定
/// </summary>
public class Colider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.Initialize();
        this.gameObject.GetComponent<BoxCollider2D>().size = this.gameObject.GetComponent<RectTransform>().sizeDelta;
    }

    protected virtual void Initialize()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
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
