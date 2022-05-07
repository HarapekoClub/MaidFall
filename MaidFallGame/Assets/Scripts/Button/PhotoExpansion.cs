using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoExpansion : MonoBehaviour
{
	[SerializeField] Image expansionPhoto;

	public void OnClick()
	{
		expansionPhoto.sprite = GetComponent<Image>().sprite;
	}

}
