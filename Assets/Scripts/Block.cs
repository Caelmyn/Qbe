using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
	public int BlockType { get {return _blockType;} } 
	[SerializeField] private int _blockType;
}