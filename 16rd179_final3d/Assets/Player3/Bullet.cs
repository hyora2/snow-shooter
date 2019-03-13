using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

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


		if (collision.gameObject.tag == "enemy") {
			var hit = collision.gameObject;
			var health = hit.GetComponent<EnemyStatus> ();
			if (health != null) {
				health.TakeDamage (0.5f);
				health.slider.value -= 0.3f;
			}

			Destroy (gameObject);
		}
	}


/*




	void Start()
	{

		Destroy (gameObject, lefttime);

	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "del" || collision.gameObject.tag == "ene_head" || collision.gameObject.tag == "enemy") 
		{
			Destroy (this.gameObject);
		}


	}
*/

}
