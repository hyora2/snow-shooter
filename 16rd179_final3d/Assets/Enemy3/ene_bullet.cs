using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ene_bullet : MonoBehaviour {

	public float lefttime = 7.0f;
	void Start()
	{
		Destroy (gameObject, lefttime);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "stage") {
			Destroy (gameObject);
		}


		if (collision.gameObject.tag == "Player") {
			var hit = collision.gameObject;
			var health = hit.GetComponent<PlayerStatus> ();
			if (health != null) {
				health.TakeDamage (0.07f);
				health.HPslider.value -= 0.07f;
			}

			Destroy (gameObject);
		}

	}
}

