using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ボタンを十字キーで選択、決定するクラス
/// </summary>

public class SelectKeyControl : MonoBehaviour
{
	/// <summary>
	/// 選択するボタン
	/// </summary>
	[SerializeField] GameObject[] button;

	/// <summary>
	/// 現在選択しているボタンの番号
	/// </summary>
	private int buttonNum;

	/// <summary>
	/// 現在選択しているボタンオブジェクト
	/// </summary>
	private GameObject nowButton;

	// Start is called before the first frame update
	void Start()
	{
		buttonNum = 0;
		nowButton = button[buttonNum];
	}

	// Update is called once per frame
	/// <summary>
	/// ボタン番号を押された矢印によって加減させることで選択するボタンを変更
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (buttonNum < button.Length - 1)
			{
				buttonNum++;
			}
			else if (buttonNum < button.Length)
			{
				buttonNum = button.Length - 1;
			}

			GameManager.GetInstance().PlaySE(0);
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (buttonNum != 0)
			{
				buttonNum--;
			}
			else if (buttonNum < 0)
			{
				buttonNum = 0;
			}

			GameManager.GetInstance().PlaySE(0);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (buttonNum != 0)
			{
				buttonNum--;
			}
			else if (buttonNum < 0)
			{
				buttonNum = 0;
			}

			GameManager.GetInstance().PlaySE(0);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (buttonNum < button.Length - 1)
			{
				buttonNum++;
			}
			else if (buttonNum < button.Length)
			{
				buttonNum = button.Length - 1;
			}

			GameManager.GetInstance().PlaySE(0);
		}

		if (buttonNum < button.Length)
		{
			nowButton = button[buttonNum];
		}
		Select();
	}

	/// <summary>
	/// 現在選択されているボタンを選択状態にする
	/// </summary>
	private void Select()
	{
		EventSystem ev = EventSystem.current;
		ev.SetSelectedGameObject(nowButton);
	}
}
