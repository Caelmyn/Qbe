using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditorCameraMovement : MonoBehaviour
{
	[SerializeField] private Text _heightText;
	[SerializeField] private string _baseText;

	private float _heightOffset;

	void Start()
	{
		_heightOffset = transform.position.y;
		ChangeHeightText();
	}

	public void ChangeHeight(float n)
	{
		Vector3 newPosition = transform.position;

		newPosition.y += n;
		transform.position = newPosition;
		ChangeHeightText();
	}

	void ChangeHeightText()
	{
		_heightText.text = _baseText + (transform.position.y - _heightOffset).ToString();
	}
}
