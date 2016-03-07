using UnityEngine;
using System.Collections;

public class SelectingBlock : MonoBehaviour
{
	[SerializeField] private BlockTypeSelectorText _selectorText;
	[SerializeField] private GameObject _selectorUI;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit infos;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out infos))
			{
				_selectorUI.SetActive(true);
				_selectorText.Select(infos.collider.gameObject);
			}
		}
	}
}
