using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockTypeSelectorText : MonoBehaviour
{
	[SerializeField] private GameObject _map;
	[SerializeField] private string[] _texts;
	[SerializeField] private GameObject[] _blockReferences;

	private int _index = 0;
	private Text _text;
	private GameObject _selected;
	private Vector3 _selectedGridPosition;

	void Start()
	{
		if (_texts.Length == 0)
			throw new UnityEngine.MissingReferenceException("No texts are given here");
		if (_blockReferences.Length == 0)
			throw new UnityEngine.MissingReferenceException("No objects references are given here");
		_text = GetComponent<Text>() as Text;
		if (_text == null)
			throw new UnityEngine.MissingComponentException("Missing Text component");
		_text.text = _texts[_index];
		transform.parent.gameObject.SetActive(false);
	}

	public void Select(GameObject newSelected)
	{
		_selected = newSelected;
		Block blockScript = _selected.GetComponent<Block>() as Block;
		if (blockScript == null)
			throw new UnityEngine.MissingComponentException("Missing Block component");
		if (blockScript.BlockType < 0)
		{
			_index = _texts.Length - 1;
			_text.text = _texts[_index];
		}
		else
			_text.text = _texts[blockScript.BlockType];
		_selectedGridPosition = new Vector3(Mathf.FloorToInt(_selected.transform.position.x), Mathf.CeilToInt(_selected.transform.position.y), Mathf.FloorToInt(_selected.transform.position.z));
	}

	public void Unselect()
	{
		_selected = null;
		_selectedGridPosition = Vector3.zero;
		transform.parent.gameObject.SetActive(false);
	}

	public void DeleteSelectedBlock()
	{
		Destroy(_selected);
		_selected = null;
		_selectedGridPosition = Vector3.zero;
		transform.parent.gameObject.SetActive(false);
	}

	public void Previous()
	{
		--_index;
		if (_index < 0)
			_index = _texts.Length - 1;
		_text.text = _texts[_index];
		ChangeBlock();
	}

	public void Next()
	{
		++_index;
		if (_index == _texts.Length)
			_index = 0;
		_text.text = _texts[_index];
		ChangeBlock();
	}

	void ChangeBlock()
	{
		Destroy(_selected);
		_selected = Instantiate(_blockReferences[_index]) as GameObject;
		_selected.transform.Translate(_selectedGridPosition);
		_selected.transform.parent = _map.transform;
	}
}