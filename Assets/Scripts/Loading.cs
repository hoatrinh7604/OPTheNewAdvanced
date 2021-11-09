using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Lop phu trach hienthi giao dien loading trong game
public class Loading : MonoBehaviour {

	[SerializeField] GameObject loadingSceneOb;
	[SerializeField] Slider sliderLoading;

	AsyncOperation async;

	public void loadingExample(){
		StartCoroutine (loadingGame (LevelSelectionLogic.currentLevelIndex));
	}

	IEnumerator loadingGame(int levelScene){
		loadingSceneOb.SetActive (true);
		async = SceneManager.LoadSceneAsync (levelScene);
		async.allowSceneActivation = false;

		while (async.isDone == false) {
			sliderLoading.value = async.progress;
			if (async.progress == 0.9f) {
				sliderLoading.value = 1f;
				async.allowSceneActivation = true;

			}
			yield return null;
		}
	}
}
