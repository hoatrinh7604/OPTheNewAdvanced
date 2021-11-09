using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly va hien thi vi tri cua ke dich cuoi cung trong man
public class FindEnemyAlive : MonoBehaviour {

	[SerializeField] GameObject[] arrowCheck;
	[SerializeField] Transform posGoingMerry;

	private GameObject[] lastEnemy;
	private Transform player;

	[SerializeField] float rangeDistance;
	// Use this for initialization
	void Start () {
		setDisableArrowById (10);
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameInfo.NumEnemyAlive == 1) {

			float distance = player.position.x - findPosEnemyAlive();
			if (distance < -rangeDistance) {
				setDisableArrowById (1);// 0 is leftaroowRed
			} else if (distance > rangeDistance) {
				setDisableArrowById (0);// 1 is rightarrowRed
			} else {
				setDisableArrowById (10);
			}
		}else if(GameInfo.NumEnemyAlive < 1){
			if (player.position.x - posGoingMerry.position.x < -rangeDistance) {
				setDisableArrowById (2); // 2 is rightArrowGreen
			} else {
				setDisableArrowById (10);
			}
		}
	}

	public void setDisableArrowById(int id){
		for (int i = 0; i < arrowCheck.Length; i++) {
			if (id != i) {
				arrowCheck [i].SetActive (false);
			} else {
				arrowCheck [i].SetActive (true);
			}
		}
	}

	public float findPosEnemyAlive(){
		lastEnemy = GameObject.FindGameObjectsWithTag ("Enemy");

		for (int i = 0; i < lastEnemy.Length; i++) {
			if (lastEnemy [i].GetComponent<EnemyState> ().getIsDead ()) {
				continue;
			} else {
				return lastEnemy [i].transform.position.x;
			}
		}

		return 100000;
	}
}
