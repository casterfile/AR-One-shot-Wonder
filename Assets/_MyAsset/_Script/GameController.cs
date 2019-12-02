using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private GameObject Enemy_1_1,Enemy_2_1,Enemy_3_1,Enemy_4_1;
	private GameObject Enemy_1_2,Enemy_2_2,Enemy_3_2,Enemy_4_2;
	private GameObject Enemy_1_3,Enemy_2_3,Enemy_3_3,Enemy_4_3;
	private GameObject Enemy_1_4,Enemy_2_4,Enemy_3_4,Enemy_4_4;
	private GameObject Enemy_1_5,Enemy_2_5,Enemy_3_5,Enemy_4_5;

	private GameObject Raw_Enemy_1,Raw_Enemy_2,Raw_Enemy_3,Raw_Enemy_4;
	private GameObject Heart_1,Heart_2,Heart_3;
	private GameObject SqFire, goGameOver,goGameWin;

	private int LiveCount = 3; 
	float timeLeft = 20;
	private Text textCountDown;
	private bool boolWin = false;

	private int Random1,Random1_1, counter;
	int CharEnemy1, CharEnemy2, CharEnemy3, CharEnemy4;
	// Use this for initialization
	void Start () {
		Enemy_1_1 = GameObject.Find("Enemy1/EnemyPrefab1");
		Enemy_1_2 = GameObject.Find("Enemy1/EnemyPrefab2");
		Enemy_1_3 = GameObject.Find("Enemy1/EnemyPrefab3");
		Enemy_1_4 = GameObject.Find("Enemy1/EnemyPrefab4");
		Enemy_1_5 = GameObject.Find("Enemy1/EnemyPrefab5");

		Enemy_2_1 = GameObject.Find("Enemy2/EnemyPrefab1");
		Enemy_2_2 = GameObject.Find("Enemy2/EnemyPrefab2");
		Enemy_2_3 = GameObject.Find("Enemy2/EnemyPrefab3");
		Enemy_2_4 = GameObject.Find("Enemy2/EnemyPrefab4");
		Enemy_2_5 = GameObject.Find("Enemy2/EnemyPrefab5");

		Enemy_3_1 = GameObject.Find("Enemy3/EnemyPrefab1");
		Enemy_3_2 = GameObject.Find("Enemy3/EnemyPrefab2");
		Enemy_3_3 = GameObject.Find("Enemy3/EnemyPrefab3");
		Enemy_3_4 = GameObject.Find("Enemy3/EnemyPrefab4");
		Enemy_3_5 = GameObject.Find("Enemy3/EnemyPrefab5");

		Enemy_4_1 = GameObject.Find("Enemy4/EnemyPrefab1");
		Enemy_4_2 = GameObject.Find("Enemy4/EnemyPrefab2");
		Enemy_4_3 = GameObject.Find("Enemy4/EnemyPrefab3");
		Enemy_4_4 = GameObject.Find("Enemy4/EnemyPrefab4");
		Enemy_4_5 = GameObject.Find("Enemy4/EnemyPrefab5");

		Heart_1 = GameObject.Find("Heart/Hear_1");
		Heart_2 = GameObject.Find("Heart/Hear_2");
		Heart_3 = GameObject.Find("Heart/Hear_3");

		goGameOver = GameObject.Find("GameOver");
		goGameWin = GameObject.Find("GameWin");
		goGameOver.SetActive (false);
		goGameWin.SetActive (false);

		SqFire = GameObject.Find("SqFire");
		SqFire.SetActive (false);
		boolWin = false;

		timeLeft = 20;

		textCountDown = GameObject.Find("TimerCountDown").GetComponent<Text>();

		Random1_1 = Random.Range(1,5);
		if(Random1_1 == 1){
			CharEnemy1 = 1;
			CharEnemy2 = 2;
			CharEnemy3 = 3;
			CharEnemy4 = 4;
		}else if(Random1_1 == 2){
			CharEnemy1 = 4;
			CharEnemy2 = 3;
			CharEnemy3 = 2;
			CharEnemy4 = 1;
		}else if(Random1_1 == 3){
			CharEnemy1 = 3;
			CharEnemy2 = 4;
			CharEnemy3 = 1;
			CharEnemy4 = 2;
		}else{
			CharEnemy1 = 2;
			CharEnemy2 = 1;
			CharEnemy3 = 4;
			CharEnemy4 = 3;
		}
		InvokeRepeating("FuncEnemy1", 0, 1.0f);

		LiveCount = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(LiveCount < 1){
			Heart_1.SetActive (false);
			Heart_2.SetActive (false);
			Heart_3.SetActive (false);
		}else if(LiveCount == 1){
			Heart_1.SetActive (true);
			Heart_2.SetActive (false);
			Heart_3.SetActive (false);
		}else if(LiveCount == 2){
			Heart_1.SetActive (true);
			Heart_2.SetActive (true);
			Heart_3.SetActive (false);
		}else if(LiveCount == 3){
			Heart_1.SetActive (true);
			Heart_2.SetActive (true);
			Heart_3.SetActive (true);
		} 

		if (boolWin == false) {
			timeLeft -= Time.deltaTime;
			int timeData = Mathf.RoundToInt (timeLeft);
			if(timeData < 10){
				textCountDown.text = "00:0"+timeData;
			}else{
				textCountDown.text = "00:"+timeData;
			}
			if ( timeLeft < 0 )
			{
				GameOver();
			}
		}

		if(LiveCount < 1 || LiveCount == 0){
			GameOver();
		}

	}

	private void GameOver(){
		goGameOver.SetActive (true);
		goGameWin.SetActive (false);
		SqFire.SetActive (true);
		boolWin = true;
	}

	private void FuncEnemy1(){
		
		counter = Random.Range (1, 10);

		if (counter == 3) {
			Random1_1 = Random.Range(1,5);
			GetEnemey (1, 3, CharEnemy1,Enemy_1_1,Enemy_1_2,Enemy_1_3,Enemy_1_4,Enemy_1_5);
			Random1_1 = Random.Range(1,5);
			GetEnemey (2, 3, CharEnemy2,Enemy_2_1,Enemy_2_2,Enemy_2_3,Enemy_2_4,Enemy_2_5);
			Random1_1 = Random.Range(1,5);
			GetEnemey (3, 3, CharEnemy3,Enemy_3_1,Enemy_3_2,Enemy_3_3,Enemy_3_4,Enemy_3_5);
			Random1_1 = Random.Range(1,5);
			GetEnemey (4, 3, CharEnemy4,Enemy_4_1,Enemy_4_2,Enemy_4_3,Enemy_4_4,Enemy_4_5);
		} else {
			Random1 = Random.Range(1,6);
			Random1_1 = Random.Range(1,5);
			GetEnemey (1, Random1, CharEnemy1,Enemy_1_1,Enemy_1_2,Enemy_1_3,Enemy_1_4,Enemy_1_5);

			Random1 = Random.Range(1,6);
			Random1_1 = Random.Range(1,5);
			GetEnemey (2, Random1, CharEnemy2,Enemy_2_1,Enemy_2_2,Enemy_2_3,Enemy_2_4,Enemy_2_5);

			Random1 = Random.Range(1,6);
			Random1_1 = Random.Range(1,5);
			GetEnemey (3, Random1, CharEnemy3,Enemy_3_1,Enemy_3_2,Enemy_3_3,Enemy_3_4,Enemy_3_5);

			Random1 = Random.Range(1,6);
			Random1_1 = Random.Range(1,5);
			GetEnemey (4, Random1, CharEnemy4,Enemy_4_1,Enemy_4_2,Enemy_4_3,Enemy_4_4,Enemy_4_5);
		}

	}


	private void GetEnemey(int Raw,int Col, int EnemyState, GameObject TempEnemy_1, GameObject TempEnemy_2, GameObject TempEnemy_3, GameObject TempEnemy_4, GameObject TempEnemy_5){
		TempEnemy_1.SetActive (false);TempEnemy_2.SetActive (false);TempEnemy_3.SetActive (false);TempEnemy_4.SetActive (false);TempEnemy_5.SetActive (false);

		if (Raw == 1) {
			if (Col == 1) {
				GetColEnemy(Raw,TempEnemy_1,EnemyState);
			}else if (Col == 2) {
				GetColEnemy(Raw,TempEnemy_2,EnemyState);
			}else if (Col == 3) {
				GetColEnemy(Raw,TempEnemy_3,EnemyState);
			}else if (Col == 4) {
				GetColEnemy(Raw,TempEnemy_4,EnemyState);
			}else if (Col == 5) {
				GetColEnemy(Raw,TempEnemy_5,EnemyState);
			}
		}
		if (Raw == 2) {
			if (Col == 1) {
				GetColEnemy(Raw,TempEnemy_1,EnemyState);
			}else if (Col == 2) {
				GetColEnemy(Raw,TempEnemy_2,EnemyState);
			}else if (Col == 3) {
				GetColEnemy(Raw,TempEnemy_3,EnemyState);
			}else if (Col == 4) {
				GetColEnemy(Raw,TempEnemy_4,EnemyState);
			}else if (Col == 5) {
				GetColEnemy(Raw,TempEnemy_5,EnemyState);
			}
		}
		if (Raw == 3) {
			if (Col == 1) {
				GetColEnemy(Raw,TempEnemy_1,EnemyState);
			}else if (Col == 2) {
				GetColEnemy(Raw,TempEnemy_2,EnemyState);
			}else if (Col == 3) {
				GetColEnemy(Raw,TempEnemy_3,EnemyState);
			}else if (Col == 4) {
				GetColEnemy(Raw,TempEnemy_4,EnemyState);
			}else if (Col == 5) {
				GetColEnemy(Raw,TempEnemy_5,EnemyState);
			}
		}
		if (Raw == 4) {
			if (Col == 1) {
				GetColEnemy(Raw,TempEnemy_1,EnemyState);
			}else if (Col == 2) {
				GetColEnemy(Raw,TempEnemy_2,EnemyState);
			}else if (Col == 3) {
				GetColEnemy(Raw,TempEnemy_3,EnemyState);
			}else if (Col == 4) {
				GetColEnemy(Raw,TempEnemy_4,EnemyState);
			}else if (Col == 5) {
				GetColEnemy(Raw,TempEnemy_5,EnemyState);
			}
		}
	}

	private void GetColEnemy(int Raw, GameObject EnemyLocal,int EnemyState){
		EnemyLocal.SetActive (true);
		GameObject TempEnemy1 = EnemyLocal.gameObject.transform.GetChild (0).gameObject;
		GameObject TempEnemy2 = EnemyLocal.gameObject.transform.GetChild (1).gameObject;
		GameObject TempEnemy3 = EnemyLocal.gameObject.transform.GetChild (2).gameObject;
		GameObject TempEnemy4 = EnemyLocal.gameObject.transform.GetChild (3).gameObject;

		TempEnemy1.SetActive (false);
		TempEnemy2.SetActive (false);
		TempEnemy3.SetActive (false);
		TempEnemy4.SetActive (false);


		if(Raw == 1){
			if (EnemyState == 1) {
				Raw_Enemy_1 =  TempEnemy1;
			}else if (EnemyState == 2) {
				Raw_Enemy_1 = TempEnemy2;
			}else if (EnemyState == 3) {
				Raw_Enemy_1 = TempEnemy3;
			}else{
				Raw_Enemy_1 = TempEnemy4;
			}
			Raw_Enemy_1.SetActive (true);

		}

		if(Raw == 2){
			if (EnemyState == 1) {
				Raw_Enemy_2 =  TempEnemy1;
			}else if (EnemyState == 2) {
				Raw_Enemy_2 = TempEnemy2;
			}else if (EnemyState == 3) {
				Raw_Enemy_2 = TempEnemy3;
			}else{
				Raw_Enemy_2 = TempEnemy4;
			}
			Raw_Enemy_2.SetActive (true);

		}
		if(Raw == 3){
			if (EnemyState == 1) {
				Raw_Enemy_3 =  TempEnemy1;
			}else if (EnemyState == 2) {
				Raw_Enemy_3 = TempEnemy2;
			}else if (EnemyState == 3) {
				Raw_Enemy_3 = TempEnemy3;
			}else{
				Raw_Enemy_3 = TempEnemy4;
			}
			Raw_Enemy_3.SetActive (true);
		}
		if(Raw == 4){
			if (EnemyState == 1) {
				Raw_Enemy_4 =  TempEnemy1;
			}else if (EnemyState == 2) {
				Raw_Enemy_4 = TempEnemy2;
			}else if (EnemyState == 3) {
				Raw_Enemy_4 = TempEnemy3;
			}else{
				Raw_Enemy_4 = TempEnemy4;
			}
			Raw_Enemy_4.SetActive (true);

		}
	}

	public void Fire(){
		if (counter == 3) {
			print ("Fire Now");
			SqFire.SetActive (true);
			boolWin = true;
			goGameOver.SetActive (false);
			goGameWin.SetActive (true);
		} else {
			print ("Failed");
			 
			LiveCount--;
		}
	}

}
