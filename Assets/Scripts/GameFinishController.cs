using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lop xu ly viec khoi tao cac Enemy trong man choi, mo man choitiep theo khi hoan thanh
public class GameFinishController : MonoBehaviour {
	[SerializeField] bool hasBoss;
	[SerializeField] int numEnemyInScene = 0;
	[SerializeField] int minEnemyOfLevel;
	[SerializeField] int maxEnemyOfLevel;

	[SerializeField] Transform tranToCreateEnemy;
	[SerializeField] Transform tranToCreateEnemyMedium;
	[SerializeField] Transform tranToCreateEnemyEnd;
	[SerializeField] Transform tranForBoss;
	[SerializeField] Transform tranForBossEnd;

	[SerializeField] GameObject merry;
	[SerializeField] GameObject arrowFinish;

	private Vector3 tempVecter3 = new Vector3();
	private int increateMax;

	[System.Serializable]
	public class typeOfEnemy{
		public int idEnemy;
		public GameObject enemyPrefabs;
	}

	[SerializeField] GameObject[] boss;

	public List <typeOfEnemy> list = new List<typeOfEnemy>(); 

	// Use this for initialization
	void Start () {
		//numEnemyInScene = listEnemy.Length;
		setNumEnemyFollowDifficult();

		if (hasBoss) {
			for (int i = 0; i < boss.Length; i++) {
				createRandomBoss (boss [i]);
			}
		}

		for (int i = list.Count - 1; i >= 0; i--) {
			createRandomEnemy (list [i].idEnemy, list[i].enemyPrefabs);
		}

		GameInfo.NumEnemyAlive = numEnemyInScene;

		//Debug.Log ("Num of enemy: " + numEnemyInScene);
	}

	void Update(){
		if (GameInfo.NumEnemyAlive <= 0) {
			arrowFinish.SetActive (true);
			merry.SetActive (true);
		} else {
			merry.SetActive (false);
			arrowFinish.SetActive (false);
		}
	}

	public void createRandomEnemy(int idEnemy, GameObject g){
		int i = Random.Range (minEnemyOfLevel, (maxEnemyOfLevel - numEnemyInScene)/ idEnemy);

		for (int j = 0; j < i; j++) {
			if (numEnemyInScene < maxEnemyOfLevel) {
				if (idEnemy == 1) {
					tempVecter3 = new Vector3 (Random.Range (tranToCreateEnemy.position.x, tranToCreateEnemyEnd.position.x), tranToCreateEnemy.position.y, tranToCreateEnemy.position.z);
					Instantiate (g, tempVecter3, Quaternion.identity);
				} else {
					tempVecter3 = new Vector3 (Random.Range (tranToCreateEnemyMedium.position.x, tranToCreateEnemyEnd.position.x), tranToCreateEnemyMedium.position.y, tranToCreateEnemyMedium.position.z);
					Instantiate (g, tempVecter3, Quaternion.identity);
				}

				numEnemyInScene++;
			}
		}
	}

	public void createRandomBoss(GameObject g){
		
		if (numEnemyInScene < maxEnemyOfLevel) {
			tempVecter3 = new Vector3 (Random.Range (tranForBoss.position.x, tranForBossEnd.position.x), tranForBoss.position.y, tranForBoss.position.z);
			Instantiate (g, tempVecter3, Quaternion.identity);

			numEnemyInScene += 1;
		}

	}

	public void setNumEnemyFollowDifficult(){

		if(PlayerPrefs.GetInt("GameDifficult") == 1){
			increateMax = Random.Range(1, 5);
		}else if(PlayerPrefs.GetInt("GameDifficult") == 2){
			increateMax = Random.Range(5, 10);;
		}else if(PlayerPrefs.GetInt("GameDifficult") == 3){
			increateMax = Random.Range(10, 20);
		}

		maxEnemyOfLevel += increateMax;
	}
		
}
