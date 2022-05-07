public class HomeControler : TouchControler
{
    protected override void OnB()
    {
        GameManager.GetInstance().JumpScene("TitleScene");
    }

    protected override void OnA()
    {
        GameManager.GetInstance().JumpScene("GameScene");
    }
}