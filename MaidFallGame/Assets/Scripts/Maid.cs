using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// メイド雛形
/// </summary>
public class Maid : Colider
{
    private Vector3 position;

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
        this.sec = 0;
        this.isFall = true;
        base.Initialize();
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

    private void Delete()
    {
        Debug.Log("good bye");
        Destroy(this.gameObject);
    }
}
