using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStatus : MonoBehaviour {
	//移動関係の定数
	public float Rlimit = 30f;		//右の限界
	public float Llimit = -30f;		//左の限界

	//Snowの変数
	public const float maxAmount = 1f;		//最大値
	public float currentSnow = maxAmount;
	public Slider Snowslider ;

	//HPの変数
	public const float maxHP = 1;		//最大値
	public float currentHP = maxHP;
	public Slider HPslider ;


	//弾の変数
	public GameObject bullet;
	public GameObject raiful;
	public Transform muzzle;
	public float speed = 900f;
	public float speed2 = 1500f;
	public float SnowRem_lefttime = 2f;

	//スコア関係
	public Text scoreText ;
	int score;

	public Text Gameovertext;
	public static int finish = 0;

	// Use this for initialization
	void Start () {
		Gameovertext.text = "";
		score = 0;

	}
	
	// Update is called once per frame
	void Update () {

		//移動処理//
		/*
		if(Input.GetKey(KeyCode.W)){
			transform.position += new Vector3(0,0,1 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.position += new Vector3(0,0,-1 * Time.deltaTime);
		}
		*/
		if(Input.GetKey(KeyCode.RightArrow)){	//KeyCode.D
			if(transform.position.x >= Rlimit) return;
			transform.position += new Vector3(20 * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){	//KeyCode.A
			if(transform.position.x < Llimit) return;
			transform.position += new Vector3(-20 * Time.deltaTime,0,0);
		}

		//回転処理
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Rotate(50 * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Rotate(-50 * Time.deltaTime,0,0);
		}
		/*
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(0, -50 * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(0, 50 * Time.deltaTime, 0);
		}
	*/
	
		//弾の発射処理


		//普通の弾（bullet)
		if (Input.GetKeyDown (KeyCode.D)) {
			if (currentSnow <= 0) {
				return;
			}

			GameObject bullets = GameObject.Instantiate (bullet)as GameObject;

			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			bullets.GetComponent<Rigidbody> ().AddForce (force);
			bullets.transform.position = muzzle.position;

			SnowTakeDamage (0.02f);

		}

		//速い弾（raiful)
		if (Input.GetKeyDown (KeyCode.S)) {
			if (currentSnow <= 0) {
				return;
			}

			GameObject raifuls = GameObject.Instantiate (raiful)as GameObject;

			Vector3 force;
			force = this.gameObject.transform.forward * speed2;
			raifuls.GetComponent<Rigidbody> ().AddForce (force);
			raifuls.transform.position = muzzle.position;

			SnowTakeDamage (0.05f);
		}

		//デバッグ用回復処理
		if (Input.GetKeyDown (KeyCode.X)) {
			SnowRemoveDamage (0.5f);

		}
		//時間経過回復
		SnowRem_lefttime -= Time.deltaTime;
		if (SnowRem_lefttime <= 0.0f) {
			SnowRemoveDamage (0.1f);
			SnowRem_lefttime = 3f;
		}


	}

	//雪が減る処理
	public void SnowTakeDamage(float amount)
	{
		currentSnow -= amount;	//HPを減らす処理
		if (currentSnow <= 0)
		{
			currentSnow = 0f;
			//Destroy (gameObject);	//体力が無くなった時消滅させる処理
			Debug.Log("No snow");
		}
		Snowslider.value = currentSnow;	//スライダーの移動処理
	}

	//雪の回復処理
	public void SnowRemoveDamage(float amount)
	{
		currentSnow = currentSnow + amount;
		//Debug.Log ("Remove");
		if (currentSnow > maxAmount) {
			currentSnow = maxAmount;

		}
		Snowslider.value = currentSnow;

	}

	//HPを減らす処理
	public void TakeDamage(float amount)
	{
		currentHP -= amount;	//HPを減らす処理
		if (currentHP <= 0)
		{
			currentHP = 0f;
			//Destroy (gameObject);	//体力が無くなった時消滅させる処理
			Debug.Log("Dead!");
			//Gameovertext.text = "GAME OVER!";
			finish = 1;
			SceneManager.LoadScene ("finish");

		}
		HPslider.value = currentHP;	//スライダーの移動処理
	}

	//HP回復処理
	public void RemoveDamage(float amount)
	{
		currentHP = currentHP + amount;
		//Debug.Log ("Remove");
		if (currentHP > maxAmount) {
			currentHP = maxAmount;

		}
		HPslider.value = currentHP;

	}

	//スコア処理
	public void AddScore(int newScorevalue){
		print ("new score" + newScorevalue);
		print ("score" + score);
		score += newScorevalue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = score.ToString ();
	}


}
