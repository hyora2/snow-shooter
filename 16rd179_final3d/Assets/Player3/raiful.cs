using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class raiful : MonoBehaviour {

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

		if (collision.gameObject.tag == "enemy" ) {
			//var hit2 = GetComponent<PlayerHP> ();
			var hit = collision.gameObject;
			var health = hit.GetComponent<EnemyStatus> ();
			if (health != null) {
				health.TakeDamage (0.8f);
				health.slider.value -= 0.4f;
			}

			Destroy (gameObject);
		}
	}

}