using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour {

	public void OnButtonClicked(){
		SceneManager.LoadScene ("tute3");
	}

	public void OnButtonClicked2 (){
		SceneManager.LoadScene ("howtoplay");
	}

}
