using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumDisplay : MonoBehaviour
{

	[SerializeField] GameObject[] albumPanel;
	[SerializeField] Image[] albumPages;
	[SerializeField] Sprite[] photo;
	// Start is called before the first frame update
	void Start()
	{
		CheckPhoto();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void CheckPhoto()
	{
		Debug.Log("ここまできてる");
		if (AlbumManager.GetInstance().GetIsShot("NORMAL_HEART_HEART"))
		{
			//NORMAL_HEART_HEARTの画像を表示する
			//画像をenabledでアクティブ化する
			albumPages[0].sprite = photo[0];
		}
		else
		{
		}

		if (AlbumManager.GetInstance().GetIsShot("CHINA_HEART_HEART"))
		{
			//CHINA_HEART_HEARTの画像を表示する
			albumPages[1].sprite = photo[1];
		}
		else
		{
		}

		if (AlbumManager.GetInstance().GetIsShot("SCHOOL_HEART_HEART"))
		{
			//SCHOOL_HEART_HEARTの画像を表示する
			albumPages[2].sprite = photo[2];
		}
		else
		{
		}

		if (AlbumManager.GetInstance().GetIsShot("WATER_HEART_HEART"))
		{
			//WATER_HEART_HEARTの画像を表示する
			albumPages[3].sprite = photo[3];
		}
		else
		{
		}

		if (AlbumManager.GetInstance().GetIsShot("OTAKU_HEART_HEART"))
		{
			//OTAKU_HEART_HEARTの画像を表示する
			albumPages[4].sprite = photo[4];
		}
		else
		{
		}

		if (AlbumManager.GetInstance().GetIsShot("NORMAL_HEART_HEART") && AlbumManager.GetInstance().GetIsShot("CHINA_HEART_HEART")
		&& AlbumManager.GetInstance().GetIsShot("SCHOOL_HEART_HEART") && AlbumManager.GetInstance().GetIsShot("WATER_HEART_HEART")
		&& AlbumManager.GetInstance().GetIsShot("OTAKU_HEART_HEART"))
		{
			albumPages[5].sprite = photo[5];
		}

	}
}
