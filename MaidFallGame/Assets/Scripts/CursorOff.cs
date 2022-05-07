using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// カーソル初期設定クラス
/// </summary>
public class CursorOff : MonoBehaviour
{
	/// <summary>
	/// 初期に選択するボタン
	/// </summary>
	[SerializeField] private GameObject firstSelectButton;

	/// <summary>
	/// アタッチされたオブジェクトがアクティブ化した際に、カーソルを選択状態にする
	/// </summary>
	private void OnEnable()
	{
		EventSystem ev = EventSystem.current;
		ev.SetSelectedGameObject(firstSelectButton);
	}

	private void Update()
	{
		if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow)
		|| Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
		{
			GameManager.GetInstance().PlaySE(0);
		}
	}
}
