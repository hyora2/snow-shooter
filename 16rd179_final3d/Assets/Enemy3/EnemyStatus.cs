using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour {

	//敵の動きに関する変数
	public float MoveSpeed = 10f;
	private float Movetimeleft;

	public GameObject bullet;
	public Transform muzzle;
	public float bulletspeed = -1000f;
	private float Bullettimeleft;

	public const float maxHP = 1;		//最大値
	public float currentHP = maxHP;
	public Slider slider ;

	public ScoreCont Score;


	// Use this for initialization
	void Start () {
		Score = GameObject.Find ("GameCont").GetComponent<ScoreCont>();

	}
	
	// Update is called once per frame
	void Update () {
	
		//動きと弾

		Bullettimeleft -= Time.deltaTime;
		Movetimeleft -= Time.deltaTime;
		if (Movetimeleft <= 0.0f) {
			MoveSpeed = MoveSpeed * (-1.0f);
			Movetimeleft = 2.5f;
		}
		transform.position += new Vector3(MoveSpeed * Time.deltaTime,0,0);

		if (Bullettimeleft <= 0.0) {
			GameObject bullets = GameObject.Instantiate (bullet)as GameObject;

			Vector3 force;
			force = this.gameObject.transform.forward * bulletspeed;
			bullets.GetComponent<Rigidbody> ().AddForce (force);
			bullets.transform.position = muzzle.position;

			Bullettimeleft = Random.Range(1, 4);
		}


	}


	public void TakeDamage(float amount)
	{
		currentHP -= amount;	//HPを減らす処理
		if (currentHP <= 0)
		{
			


			currentHP = 0f;
			Destroy (gameObject);	//体力が無くなった時消滅させる処理
			Debug.Log("Dead!");
		
			Score.AddScore (100);	
		}
		slider.value = currentHP;	//スライダーの移動処理
	}



}
