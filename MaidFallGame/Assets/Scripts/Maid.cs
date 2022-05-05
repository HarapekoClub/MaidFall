using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メイド雛形
/// </summary>
public class Maid : Colider
{
    private Vector3 position;
    [SerializeField] private MaidType type;

    private float sec;
    private bool isFall;
    private const float INTERVAL = 1.0f;

    // Update is called once per frame
    void Update()
    {
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

    protected override void Initialize()
    {
        this.position = this.transform.position;
        // Debug.Log(this.position);
        // Debug.Log(this.gameObject.transform.localScale);
        this.sec = 0;
        this.isFall = true;
        base.Initialize();
    }

    public void Generated(MaidType type, Vector3 pos)
    {
        this.type = type;
        this.position = pos;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        this.gameObject.transform.position = this.position;
        this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Maids/" + type + "_" + MaidPause.HEART);
    }

    public MaidType GetMaidType()
    {
        return this.type;
    }

    private void Down()
    {
        this.position.y -= 1;
        this.gameObject.transform.position = this.position;
        // Debug.Log("pos: " + this.position);
    }

    public void OnGround()
    {

        this.isFall = false;
        this.sec = 0;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void Delete()
    {
        Debug.Log("good bye");
        Destroy(this.gameObject);
    }
}
