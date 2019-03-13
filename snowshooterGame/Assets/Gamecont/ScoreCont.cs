using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScoreCont : MonoBehaviour {

	public Text scoreText ;
	public static int score = 0;


	// Use this for initialization
	void Start () {
		
		score = 0;
		scoreText.text = "Score\t" + score.ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static int getScorePoint(){
		return score;
	}

	//スコア処理
	public void AddScore(int newScorevalue){
		print ("new score" + newScorevalue);
		print ("score" + score);
		score += newScorevalue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score\t" + score.ToString ();
	}
}
