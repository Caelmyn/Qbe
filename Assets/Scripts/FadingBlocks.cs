using UnityEngine;
using System.Collections;

public class FadingBlocks : MonoBehaviour
{
	[SerializeField] private float _fadingTime;

	void Start() {}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
			Destroy(gameObject, _fadingTime);
	}
}
