using UnityEngine;
using System.Collections;

public class ShuttleObject : MonoBehaviour
{

	void Start()
	{
		float x = Random.value * 0.5f + 0.5f;
		float y = Random.value * 0.5f + 0.5f;
		float z = Random.value * 0.5f + 0.5f;
		transform.position = new Vector3(x, y, z);
		Debug.Log($"x{x}, y {y}, z {z}");

		iTween.RotateBy(gameObject, iTween.Hash("y", 1, "easeType", "linear", "loopType", "loop", "delay", 0, "time", 3));
	}
}

