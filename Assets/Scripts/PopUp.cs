using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour
{
	public void Show(bool state)
	{
		gameObject.SetActive(state);
	}
}
