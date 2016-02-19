using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
	private Vector3 _checkPointPosition;

	void Start()
	{
		_checkPointPosition = new Vector3(0, transform.position.y, 0);
	}

	void Update()
	{
		if (transform.position.y < -3)
			transform.position = _checkPointPosition;
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "CheckPoint")
		{
			Vector3 newCheckPoint = c.transform.position;
			_checkPointPosition = new Vector3(newCheckPoint.x, Mathf.Ceil(newCheckPoint.y) + transform.position.y, newCheckPoint.z);
		}
	}
}
