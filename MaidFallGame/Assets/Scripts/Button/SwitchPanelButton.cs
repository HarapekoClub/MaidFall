using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanelButton : MonoBehaviour, Button
{

	/// <summary>
	/// 切り替えるオブジェクト
	/// </summary>
	[SerializeField] GameObject onPanel;
	[SerializeField] GameObject offPanel;


	/// <summary>
	/// クリックされた際にオブジェクトをアクティブ化、非アクティブ化する
	/// </summary>
	public void OnClick()
	{
		onPanel.SetActive(true);
		offPanel.SetActive(false);
	}
}
