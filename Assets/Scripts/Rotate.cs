using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private Vector3 _rotationAxis;

	void Update()
	{
		transform.Rotate(_rotationAxis, _rotationSpeed);
	}
}
