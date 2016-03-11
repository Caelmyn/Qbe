using UnityEngine;
using System.Collections;

public class SelectingBlock : MonoBehaviour
{
	[SerializeField] private BlockTypeSelectorText _selectorText;

	[Header("UI to enable/disable")]
	[SerializeField] private GameObject _selectorUI;
	[SerializeField] private GameObject _newBlockButton;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit infos;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out infos))
			{
				_selectorUI.SetActive(true);
				_newBlockButton.SetActive(false);
				_selectorText.Select(infos.collider.gameObject);
			}
		}
	}
}
