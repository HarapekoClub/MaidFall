using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbumDisplay : MonoBehaviour
{
	[SerializeField] GameObject[] Photo;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void CheckPhoto()
	{
		if (AlbumManager.GetInstance().GetIsShot("NORMAL_HEART_HEART"))
		{
			//NORMAL_HEART_HEARTの画像を表示する
			//画像をenabledでアクティブ化する
		}
		else if (AlbumManager.GetInstance().GetIsShot("CHINA_HEART_HEART"))
		{
			//CHINA_HEART_HEARTの画像を表示する
		}
		else if (AlbumManager.GetInstance().GetIsShot("SCHOOL_HEART_HEART"))
		{
			//SCHOOL_HEART_HEARTの画像を表示する
		}
		else if (AlbumManager.GetInstance().GetIsShot("WATER_HEART_HEART"))
		{
			//WATER_HEART_HEARTの画像を表示する
		}
		else if (AlbumManager.GetInstance().GetIsShot("OTAKU_HEART_HEART"))
		{
			//OTAKU_HEART_HEARTの画像を表示する
		}

	}
}
