﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class howtobutton : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnButtonClicked3(){
		SceneManager.LoadScene ("title");
	}


}
