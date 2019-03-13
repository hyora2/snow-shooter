using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour {
	public Text resultscore;

	// Use this for initialization
	void Start () {
		int resultScore = ScoreCont.getScorePoint();
		resultscore.text = "RESULT:\t" + resultScore.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnButtonClicked(){
		SceneManager.LoadScene ("title");
	}


}
