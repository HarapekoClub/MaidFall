using UnityEngine;

/// <summary>
/// プレイヤーの接地判定
/// </summary>
public class PlayerColider : Colider
{
    /// <summary>
    /// プレイヤー
    /// </summary>
    [SerializeField] private Player player;

    /// <summary>
    /// 接触したメイドさんの情報を取得してプレイヤーにわたす
    /// </summary>
    /// <param name="maid"></param>
    protected override void OnMaid(Maid maid)
    {
        base.OnMaid(maid);
        this.player.Shot(maid);
    }
}