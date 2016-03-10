using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockTypeSelectorText : MonoBehaviour
{
	[SerializeField] private string[] _texts;

	private int _index = 0;
	private Text _text;
	private GameObject _selected;

	void Start()
	{
		if (_texts.Length == 0)
			throw new UnityEngine.PlayerPrefsException("No texts are given here");
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
	}

	public void Unselect()
	{
		_selected = null;
		transform.parent.gameObject.SetActive(false);
	}

	public void DeleteSelectedBlock()
	{
		Destroy(_selected);
		_selected = null;
		transform.parent.gameObject.SetActive(false);
	}

	public void Previous()
	{
		--_index;
		if (_index < 0)
			_index = _texts.Length - 1;
		_text.text = _texts[_index];
	}

	public void Next()
	{
		++_index;
		if (_index == _texts.Length)
			_index = 0;
		_text.text = _texts[_index];
	}
}
