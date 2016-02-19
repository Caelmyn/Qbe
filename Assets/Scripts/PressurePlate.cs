using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
	[SerializeField] private Color _colorUnactive;
	[SerializeField] private Color _colorActive;

	private Material _mat;

	void Start()
	{
		Renderer r = GetComponent<Renderer>() as Renderer;
		if (r == null)
			throw new UnityEngine.MissingComponentException("Missing Renderer component");
		_mat = r.material;
		if (_mat == null)
			throw new UnityEngine.MissingReferenceException("This components needs at least one Material attached to the Renderer");
		_mat.color = _colorUnactive;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			BoxCollider b = GetComponent<BoxCollider>() as BoxCollider;
			if (b != null)
				b.enabled = false;
			_mat.color = _colorActive;
			transform.localPosition = new Vector3(0, 0.26f, 0);
		}
	}
}
