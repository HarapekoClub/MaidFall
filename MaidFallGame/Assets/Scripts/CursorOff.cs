using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorOff : MonoBehaviour
{
	[SerializeField] private GameObject firstSelectButton;
	// Start is called before the first frame update
	void Start()
	{
		EventSystem ev = EventSystem.current;
		ev.SetSelectedGameObject(firstSelectButton);
	}
}
