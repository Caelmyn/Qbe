using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	[SerializeField] private string _collisionTag;
	[SerializeField] private int _jumpHeight;
	[SerializeField] private float _moveSpeed;

	private bool _inAir = true;
	private Rigidbody _rigidbody;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>() as Rigidbody;
		if (_rigidbody == null)
			throw new UnityEngine.MissingComponentException("Missing Rigidbody component");
			_rigidbody.maxAngularVelocity = 7;
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Space) && !_inAir)
		{
			_rigidbody.AddForce(0, _jumpHeight, 0, ForceMode.Impulse);
			_inAir = true;
		}
		if (Input.GetKey(KeyCode.D))
			transform.Translate(_moveSpeed, 0, 0);
		if (Input.GetKey(KeyCode.Q))
			transform.Translate(-_moveSpeed, 0, 0);
		if (Input.GetKey(KeyCode.Z))
			transform.Translate(0, 0, _moveSpeed);
		if (Input.GetKey(KeyCode.S))
			transform.Translate(0, 0, -_moveSpeed);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == _collisionTag)
			_inAir = false;
	}
}