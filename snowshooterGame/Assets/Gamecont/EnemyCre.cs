using UnityEngine;
using System.Collections;

public class EnemyCre : MonoBehaviour {

	public GameObject snowman_s;
	public GameObject snowman_m;
	public GameObject snowman_l;
	public GameObject snowman_sta;

	public float max_x ;
	public float min_x ;
	public float max_z ;
	public float min_z ;
	float x = 0, y = 0, z = 0;

	int snow_count = 0;
	int limit = 50;

	public float timeleft = 1f;
	public float ran = 1f;
	private int area = 0;

	// Use this for initialization
	void Start () {
		

	
	
	}
	
	// Update is called once per frame
	void Update () {
		int swi = -1;

		if (snow_count >= limit)
			return;
		timeleft -= Time.deltaTime;
		if (timeleft <= 0) {
			ran = Random.Range (0f, 1f);
			swi = area_ret (ran);


			switch (swi) {
				
			case 1://Aエリア　敵m または 敵L
				ran = Random.Range (0f, 1f);

				if (ran >= 0.3f) {
					//範囲制限
					  max_x = 25f;
					  min_x = -25f;
					  max_z = 18f;
					  min_z = 2f;
					//制限内でランダムな位置
					 x = Random.Range (min_x, max_x);
					 y = -2f;
					 z = Random.Range (min_z, max_z);
					//生成
					enecreM (x, y, z);

				} else {
					//範囲制限
					 max_x = 20f;
					 min_x = 20f;
					 max_z = 18f;
					 min_z = 12f;
					//制限内でランダムな位置
					 x = Random.Range (min_x, max_x);
					 y = -2f;
					 z = Random.Range (min_z, max_z);
					//生成
					enecreL (x, y, z);


				}
				break;
		
			case 2:	//Bエリア　敵L
				//範囲制限
				 max_x = 25f;
				 min_x = 17f;
				 max_z = 25f;
				 min_z = 23f;
				//制限内でランダムな位置
				x = Random.Range (min_x, max_x);
				y = 1.3f;
				z = Random.Range (min_z, max_z);
				//生成
				enecreL (x, y, z);

				break;

			case 3:	//Cエリア 敵Static
				//範囲制限
				max_x = -27f;
				min_x = -28f;
				max_z = 25f;
				min_z = 23f;
				//制限内でランダムな位置
				x = Random.Range (min_x, max_x);
				y = 1.3f;
				z = Random.Range (min_z, max_z);
				//生成
				enecreSTA (x, y, z);
	
				break;

			case 4://Dエリア　敵static
				//範囲制限
				max_x = 5f;
				min_x = -1f;
				max_z = 32f;
				min_z = 30f;
				//制限内でランダムな位置
				x = Random.Range (min_x, max_x);
				y = 6.3f;
				z = Random.Range (min_z, max_z);
				//生成
				enecreSTA (x, y, z);

				break;

			case 5://Eエリア　敵sta
				//範囲制限
				max_x = 30f;
				min_x = 27f;
				max_z = 32f;
				min_z = 30f;
				//制限内でランダムな位置
				x = Random.Range (min_x, max_x);
				y = 6.3f;
				z = Random.Range (min_z, max_z);
				//生成
				enecreSTA (x, y, z);

				break;

			default:
				break;

			}

			timeleft = Random.Range (1, 3);
			return;
		}
	
	}


	//敵生成の処理
	void enecreS(float x, float y, float z){
		Instantiate (snowman_s, new Vector3 (x, y, z), Quaternion.identity);
		snow_count++;
	}

	void enecreM (float x, float y, float z){
		Instantiate (snowman_m, new Vector3 (x, y, z), Quaternion.identity);
		snow_count++;

	}

	void enecreL (float x, float y, float z){
		Instantiate (snowman_l, new Vector3 (x, y, z), Quaternion.identity);
		snow_count++;

	}

	void enecreSTA(float x, float y, float z){
		Instantiate (snowman_sta, new Vector3 (x, y, z), Quaternion.identity);
		snow_count++;
	}

	int area_ret(float f){
		float han = f * 10f;
		if (han >= 7f) {
			return 1;
		} else if (han < 7f && han >= 5f) {
			return 2;
		} else if (han < 5f && han >= 4f) {
			return 3;
		} else if (han < 4f && han >= 3f) {
			return 4;
		} else if (han < 3f && han >= 2f) {
			return 5;
		} else if (han < 2f && han >= 1f) {
			return 6;
		} else {
			return 0;
		}

		return 0;
	}

}
