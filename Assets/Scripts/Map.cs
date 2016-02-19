using UnityEngine;
using System.Collections;
using System.IO;

public class Map : MonoBehaviour
{
	[SerializeField] private string _fileName;
	[SerializeField] private GameObject _player;
	[SerializeField] private GameObject[] _blocks;
	[SerializeField] private float _blocksOffset;
	[SerializeField] private float _plateOffset;

	void Start()
	{
		string[] lines = File.ReadAllLines(Application.streamingAssetsPath + "/" + _fileName);
		foreach(string line in lines)
			BuildMap(line);
		Instantiate(_player, new Vector3(0, 0, 0), Quaternion.identity);
	}

	void BuildMap(string infos)
	{
		string[] split = infos.Split(",".ToCharArray());
		Debug.Log(infos);
		int blockType = int.Parse(split[0]);
		Vector3 itemPosition = new Vector3(int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]));
		GameObject g = Instantiate(_blocks[blockType], itemPosition, Quaternion.identity) as GameObject;

		if (blockType == 0 || blockType == 4)
			g.transform.Translate(0, _blocksOffset, 0);
		else
			g.transform.Translate(0, _plateOffset, 0);
		g.transform.SetParent(transform);
	}
}