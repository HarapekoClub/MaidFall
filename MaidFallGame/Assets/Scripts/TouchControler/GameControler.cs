public class GameControler : TouchControler
{
    protected override void OnA()
    {
        GameManager.GetInstance().JumpScene("HomeScene");
    }
    protected override void OnArrowLeft()
    {
        GamePlayManager.GetInstance().GetPlayer().Move(-1);
    }

    protected override void OnArrowRight()
    {
        GamePlayManager.GetInstance().GetPlayer().Move(1);
    }
}