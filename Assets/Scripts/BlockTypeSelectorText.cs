using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockTypeSelectorText : MonoBehaviour
{
	[SerializeField] private string[] _texts;

	private int _index = 0;
	private Text _text;

	void Start()
	{
		if (_texts.Length == 0)
			throw new UnityEngine.PlayerPrefsException("No texts are given here");
		_text = GetComponent<Text>() as Text;
		if (_text == null)
			throw new UnityEngine.MissingComponentException("Missing Text component");
		_text.text = _texts[_index];
	}

	public void Select()
	{
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
