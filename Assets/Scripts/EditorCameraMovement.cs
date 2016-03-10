using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditorCameraMovement : MonoBehaviour
{
	[SerializeField] private Text _heightText;
	[SerializeField] private string _baseText;
	[SerializeField] private GameObject _mapContainer;

	private float _heightOffset;

	void Start()
	{
		_heightOffset = transform.position.y;
		ChangeHeightText();
		ChangeHeightView();
	}

	public void ChangeHeight(float n)
	{
		Vector3 newPosition = transform.position;

		newPosition.y += n;
		transform.position = newPosition;
		ChangeHeightText();
		ChangeHeightView();
	}

	void ChangeHeightText()
	{
		_heightText.text = _baseText + (transform.position.y - _heightOffset).ToString();
	}

	void ChangeHeightView()
	{
		foreach (Transform child in _mapContainer.transform)
		{
			if (Mathf.Ceil(child.position.y) != transform.position.y - _heightOffset)
				child.gameObject.SetActive(false);
			else
				child.gameObject.SetActive(true);
		}
	}
}
