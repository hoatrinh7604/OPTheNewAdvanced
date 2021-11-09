using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay phuc vu tinh toan va hien thi so sao sau khi player ket thuc moi man choi
public class HighStarSystem : MonoBehaviour {

	[SerializeField] GameObject star1;
	[SerializeField] GameObject star2;
	[SerializeField] GameObject star3;

	[SerializeField] float maxTimeOfScene;
	[SerializeField] float currentTimeRun;

	void Update(){
		if (!PauseSystem.isPause) {
			currentTimeRun -= Time.deltaTime;
		}
	}

	public int getStarScore(){
		PauseSystem.pauseGame();

		if (currentTimeRun < maxTimeOfScene - 30f) {// hoan thanh truoc 30s
			star1.SetActive(true);
			star2.SetActive(true);
			star3.SetActive(true);
			return 3; // duoc 3 sao

		} else if (currentTimeRun < maxTimeOfScene) {// hoanh thanh trong thoi gian
			star1.SetActive(true);
			star2.SetActive(true);
			return 2;
		} else {// hoan thanh ngoai thoi gian toi da
			star1.SetActive(true);
			return 1; 
		}

	}
}
