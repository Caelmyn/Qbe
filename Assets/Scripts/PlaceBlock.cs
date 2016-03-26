using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaceBlock : MonoBehaviour
{
	[SerializeField] private GameObject _map;
	[SerializeField] private GameObject _baseBlock;
	[SerializeField] private Text _xPosition;
	[SerializeField] private Text _yPosition;
	[SerializeField] private Text _heightPosition;

	public void Place()
	{
		GameObject newObject = Instantiate(_baseBlock) as GameObject;

		newObject.transform.Translate(new Vector3(int.Parse(_xPosition.text), int.Parse(_heightPosition.text), int.Parse(_yPosition.text)));
		newObject.transform.SetParent(_map.transform);
	}
}
