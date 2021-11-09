using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// lop nayphuc vu viec khoi tao lai cac gia tri ban dau khi nguoi choi reset
public class StartNewGame : MonoBehaviour {

	[SerializeField] float baseBeri;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("IsNewGame") == 0) {

			PlayerPrefs.SetFloat ("Beri", 300000f); // baseBeri for new player 
			PlayerPrefs.SetFloat ("SoundBG", 0.5f); // start maxSound = 1f;
			PlayerPrefs.SetFloat ("SoundEF", 0.7f); // start maxSound = 1f;
			PlayerPrefs.SetInt ("GameDifficult", 1); // value = 1 is Easy; 2 is Medium; 3 is hard

			// Tao nhan vat dau tien == Luffy
			SaveAndLoadManager.createCharacter(1);
			PlayerPrefs.SetInt ("CurrentCharacter", 1);
			//PlayerPrefs.SetInt ("IsNewGame", 1);// to check player is new player
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Is new game: " + PlayerPrefs.GetInt ("IsNewGame"));

	}

	public void reloadScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void setStartNewGame(){
		//playButton [0].SetActive (false);
		//playButton [1].SetActive (true);

		PlayerPrefs.SetFloat ("Beri", 300000f); // baseBeri for new player 
		PlayerPrefs.SetFloat ("SoundBG", 0.5f); // start maxSound = 1f;
		PlayerPrefs.SetFloat ("SoundEF", 0.7f); // start maxSound = 1f;
		PlayerPrefs.SetInt ("GameDifficult", 1); // value = 1 is Easy; 2 is Medium; 3 is hard

		// Tao nhan vat dau tien == Luffy
		SaveAndLoadManager.createCharacter(1);
		PlayerPrefs.SetInt ("CurrentCharacter", 1);
		PlayerPrefs.SetInt ("IsNewGame", 0);// to check player is new player
	}
}
