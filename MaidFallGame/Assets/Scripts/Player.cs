using UnityEngine;

public class Player : MonoBehaviour
{
    private const float INTERVAL = 0.5f;
    private const float MOVE_SPEED = 0.5f;
    private float sec;
    private float dir;

    private Vector3 position;

    [SerializeField] Photo photo;

    void Start()
    {
        this.sec = 0;
        this.dir = 0;
        this.position = this.gameObject.transform.position;
    }

    void Update()
    {
        this.sec += Time.deltaTime;
        this.dir = Input.GetAxis("Horizontal");
        if (this.sec > INTERVAL)
        {
            if (this.IsMovable())
            {
                this.Move();
            }

            this.sec = 0;
        }
    }

    private bool IsMovable()
    {
        return true;
    }

    private void Move()
    {
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
        this.position.x += move;
        this.gameObject.transform.position = this.position;
    }

    /// <summary>
    /// スコア計算と加算, 記録
    /// </summary>
    /// <param name="maid"></param>
    public void Shot(Maid maid)
    {
        string photoName = "";
        this.photo.Shot(photoName);
        AlbumManager.GetInstance().SetIsShot(photoName, true);
    }

}