using UnityEngine;
using System.Collections;

public class MainMenuDemo : MonoBehaviour
{
	[SerializeField] private GameObject[] _blocks;

	private Rigidbody _rigidbody;
	private int _blocksNumbers;
	private GameObject _lastObjectHit;
	private int _lastIndex;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>() as Rigidbody;
		if (_rigidbody == null)
			throw new UnityEngine.MissingComponentException("Missing Rigidbody component");
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Floor")
		{
			_rigidbody.AddForce(0, 5, 0, ForceMode.Impulse);
			_lastObjectHit = collision.collider.gameObject;
			Invoke("RandomizeObjectShown", 0.2f);
		}
	}

	void RandomizeObjectShown()
	{
		int newIndex;

		_lastObjectHit.SetActive(false);
		while ((newIndex = Random.Range(0, 4)) == _lastIndex);
		_blocks[newIndex].SetActive(true);
		_lastIndex = newIndex;
	}
}