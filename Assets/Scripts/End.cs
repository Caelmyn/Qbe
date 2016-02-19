using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class End : MonoBehaviour
{
	void Start() {}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player")
			SceneManager.LoadScene("MainMenu");
	}
}