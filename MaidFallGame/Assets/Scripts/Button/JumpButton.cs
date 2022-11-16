using UnityEngine;

/// <summary>
/// シーン遷移ボタン
/// </summary>
public class JumpButton : MonoBehaviour, Button
{
    [SerializeField] string sceneName;
    public void OnClick()
    {
        GameManager.GetInstance().JumpScene(sceneName);
    }
}