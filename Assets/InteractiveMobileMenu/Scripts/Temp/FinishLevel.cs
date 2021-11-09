using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour {

	public int nextLevelIndex;			//The next scene index;
	//private int levelIndex;				//This scene index

	[SerializeField] Text timePlay;
	[SerializeField] Text newBounty;
	[SerializeField] Text timeRunning;

	[SerializeField] GameObject star1;
	[SerializeField] GameObject star2;
	[SerializeField] GameObject star3;

	[SerializeField] GameObject starParent;

	[SerializeField] float maxTimeOfScene;
	[SerializeField] float currentTimeRun;

	// Use this for initialization
	void Start () 
	{
		//levelIndex = SceneManager.GetActiveScene().buildIndex;	//Getting current level index for saving needs;
	}

	void Update(){
		if (!PauseSystem.isPause) {
			currentTimeRun += Time.deltaTime;
			timeRunning.text = toTimeString ((int)currentTimeRun);
		}

		if (currentTimeRun < maxTimeOfScene - 30) {
			//timeRunning.color = Color.yellow;
		} else if (currentTimeRun < maxTimeOfScene) {
			timeRunning.color = Color.yellow;
		} else {
			timeRunning.color = Color.red;
		}
	}

	public void setStarScore(){
		//Debug.Log ("Notice leng 3");

		PauseSystem.pauseGame();
		starParent.SetActive(true);

		if (currentTimeRun < maxTimeOfScene - 30f) {// hoan thanh truoc 30s
			star1.SetActive(true);
			star2.SetActive(true);
			star3.SetActive(true);
			saveLevelScene(3); // duoc 3 sao

		} else if (currentTimeRun < maxTimeOfScene) {// hoanh thanh trong thoi gian
			star1.SetActive(true);
			star2.SetActive(true);
			saveLevelScene(2); 
		} else {// hoan thanh ngoai thoi gian toi da
			star1.SetActive(true);
			saveLevelScene(1); 
		}

		timePlay.text = toTimeString((int)currentTimeRun);
		newBounty.text = getCurency ((decimal)GameInfo.Bounty);

	}


	
	// Examples on how to finish level and save stats;
	/*
	void OnGUI (){
		if (GUI.Button(new Rect(0, Screen.height/2 - 105, Screen.width, 100), "Finish Level With 1 Star"))
		{
			Data.SaveData(levelIndex, true, 1);
			LoadNextLevel();
		}

		if (GUI.Button(new Rect(0, Screen.height/2, Screen.width, 100), "Finish Level With 2 Stars"))
		{
			Data.SaveData(levelIndex, true, 2);
			LoadNextLevel();
		}

		if (GUI.Button(new Rect(0, Screen.height/2 + 105, Screen.width, 100), "Finish Level With 3 Stars"))
		{
			Data.SaveData(levelIndex, true, 3);
			LoadNextLevel();
		}
	}
	*/

	public void saveLevelScene(int star){
		//Debug.Log ("Current scene =" + levelIndex);
		//Debug.Log ("Current scene 2 =" + SceneManager.GetActiveScene().buildIndex);
		//Debug.Log ("Current scene 3 =" + LevelSelectionLogic.currentLevelIndex);
		Data.SaveData (SceneManager.GetActiveScene().buildIndex, true, star);
		//LoadNextLevel ();
	}


	//What should we load depends on the OnFinish enum choice;
	public void LoadNextLevel()
	{
		PauseSystem.resumeGame ();
		SceneManager.LoadScene(nextLevelIndex);
	}

	public string toTimeString(int time){
		int minute = time / 60;
		int second = time % 60;
		string timeString = "";
		if (minute < 10)
			timeString += "0" + minute + ":";
		else
			timeString += minute + ":";
		
		if (second < 10)
			timeString += "0" + second;
		else
			timeString += second;

		return timeString;
	}

	//get currency
	public string getCurency(decimal number){
		string temp = number.ToString ();
		//Debug.Log (temp);
		string temp2 = "";
		int j = temp.Length % 3;
		for (int i = 0; i < temp.Length; i++) {
			if (i%3 == j && i!=0) {
				temp2 += ",";
			}
			temp2 += temp [i];
		}
		return temp2;
	}
}
