using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// lop nay xu ly khi nguoi choi tuy chon trong man choi
public class PauseSystem : MonoBehaviour {

	public static bool isPause = false;
	//public GameObject gameOverPanel;
	/*
	void Update(){
		if(Input.GetKeyDown(KeyCode.P)){
			pauseGame ();
		}
		if(Input.GetKeyDown(KeyCode.O)){
			resumeGame ();
		}
	}
	*/



	public static void pauseGame(){
		Time.timeScale = 0f;
		isPause = true;
	}


	public void restartGame(){
		resumeNormalGame ();

		StoryManager.idPiece = 1; //  cai lai story cua man

		//Debug.Log ("Scene loading: " + SceneManager.GetActiveScene ().buildIndex);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public static void resumeGame(){
		Time.timeScale = 1f;
		isPause = false;
	}

	public void remoteHome(){
		//isPause = false;
		StoryManager.idPiece = 1;// reset lai gia tri idpiece ve 1 (bat dau man)
		SceneManager.LoadScene("StartMenu");
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void pauseNormalGame(){
		Time.timeScale = 0f;
		isPause = true;
	}

	public void resumeNormalGame(){
		Time.timeScale = 1f;
		isPause = false;
	}
}
