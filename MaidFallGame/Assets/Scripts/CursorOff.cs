using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
}
