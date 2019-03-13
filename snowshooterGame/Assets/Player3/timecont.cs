using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timecont : MonoBehaviour {
	private float Gametime = 61;
	public Text timetext;
	public Text timeUptext;

	// Use this for initialization
	void Start () {
		timeUptext.text = "";
		timetext.text = ((int)Gametime).ToString();
	}
	
	// Update is called once per frame
	void Update () {

		Gametime -= Time.deltaTime;
		if (Gametime < 0) {
			Gametime = 0;
			//timeUptext.text = "   TIME UP!";
			SceneManager.LoadScene ("finish");
		}
		timetext.text = "Time\t" + ((int)Gametime).ToString ();


	}
}
