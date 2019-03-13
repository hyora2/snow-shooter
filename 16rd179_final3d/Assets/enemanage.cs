using UnityEngine;
using System.Collections;

public class enemanage : MonoBehaviour {

	GameObject[] enemyObjects;
	int enemyNum = 0;

	// Use this for initialization
	void Start () {
		enemyObjects = GameObject.FindGameObjectsWithTag ("enemy");
		enemyNum = enemyObjects.Length;

	}
	

}
