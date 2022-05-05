using UnityEngine;

public class Player : MonoBehaviour
{
    private const float INTERVAL = 5f;
    private const float MOVE_SPEED = 0.5f;
    private float sec;
    private float dir;
    private int hp;

    private Vector3 position;

    [SerializeField] Photo photo;

    void Start()
    {
        this.sec = 0;
        this.dir = 0;
        this.hp = 10;
        this.position = this.gameObject.transform.position;
    }

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
    }

    private void AddHP(int i)
    {
        this.hp += i;
        Debug.Log("HP : " + this.hp);
        if (hp <= 0)
        {
            GamePlayManager.GetInstance().GameFinish();
        }
    }

    public void GameFinish()
    {
        // ゲーム終了時の処理
        Debug.Log("Finish");
    }

    /// <summary>
    /// スコア計算と加算, 記録
    /// </summary>
    /// <param name="maid"></param>
    public void Shot(Maid maid)
    {
        this.AddHP(((int)maid.GetMaidType()));
        string photoName = "";
        this.photo.Shot(photoName);
        AlbumManager.GetInstance().SetIsShot(photoName, true);
    }

}