using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MapSerializer : MonoBehaviour
{
	[SerializeField] private string _fileName;

	void Start() {}

	public void Serialize()
	{
		List<string> lines = new List<string>();
		foreach (Transform child in transform)
		{
			Block type = child.gameObject.GetComponent<Block>() as Block;
			if (type == null)
				throw new UnityEngine.MissingComponentException("Missing Block component on GameObject " + child.name);
			if (type.BlockType < 0)
				continue;
			string line = type.BlockType.ToString() + "," + Mathf.Floor(child.position.x).ToString() + "," + Mathf.Ceil(child.position.y).ToString() + "," + Mathf.Floor(child.position.z).ToString();
			lines.Add(line);
			Debug.Log(line);
		}
		File.WriteAllLines(Application.streamingAssetsPath + "/" + _fileName, lines.ToArray());
	}
}
