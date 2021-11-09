using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay phuc vu viec tuy chon do kho cho game
public class DifficultGameSetting : MonoBehaviour {

	[SerializeField] GameObject[] chooseDifficult = {null,null,null};

	void Start(){
		setDifficult (PlayerPrefs.GetInt("GameDifficult"));
	}

	public void setDifficult(int level){
		if (level == 1) {// easy
			chooseDifficult[0].SetActive(true);
			chooseDifficult [1].SetActive (false);
			chooseDifficult [2].SetActive (false);

			PlayerPrefs.SetInt ("GameDifficult", level);
		} else if (level == 2) {// medium
			chooseDifficult[1].SetActive(true);
			chooseDifficult [0].SetActive (false);
			chooseDifficult [2].SetActive (false);

			PlayerPrefs.SetInt ("GameDifficult", level);
		} else if (level == 3) {// hard
			chooseDifficult[2].SetActive(true);
			chooseDifficult [1].SetActive (false);
			chooseDifficult [0].SetActive (false);

			PlayerPrefs.SetInt ("GameDifficult", level);
		}

		//Debug.Log ("Level game: " + level);
	}
}
