using UnityEngine;

public class PlayerColider : Colider
{
    [SerializeField] private Player player;
    protected override void OnMaid(Maid maid)
    {
        base.OnMaid(maid);
        this.player.Shot(maid);
    }
}