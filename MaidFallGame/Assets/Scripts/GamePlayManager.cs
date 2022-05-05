

public class GamePlayManager
{
    private static GamePlayManager instance;

    private bool isPlay;

    private GamePlayManager()
    {
        this.isPlay = true;
    }

    public static GamePlayManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GamePlayManager();
        }
        return instance;
    }

    public bool GetIsPlay()
    {
        return this.isPlay;
    }


    public void Pause()
    {
        this.isPlay = false;
    }

    public void Start()
    {
        this.isPlay = true;
    }

    public void GameFinish()
    {
        this.isPlay = false;
    }
}