using UnityEngine;

public class HomeControler : TouchControler
{
    [SerializeField] SelectKeyControl keyCon;

    void Start()
    {
        keyCon.Add(this);
    }

    protected override void OnF1()
    {
        GameManager.GetInstance().JumpScene("TitleScene");
    }
    protected override void OnB()
    {
        this.keyCon.GetSelectedButton().OnClick();
    }

    protected override void OnA()
    {
        this.keyCon.GetSelectedButton().OnClick();
    }

    protected override void OnArrowDown()
    {
        this.keyCon.OnArrowDown();
    }

    protected override void OnArrowTop()
    {
        this.keyCon.OnArrowTop();
    }

    protected override void OnArrowLeft()
    {
        this.keyCon.OnArrowLeft();
    }

    protected override void OnArrowRight()
    {
        this.keyCon.OnArrowRight();
    }
}