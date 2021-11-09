using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// lop nay phuc vu cho chuc nang reset du lieu trong game
public class ResetGame : MonoBehaviour {

	public void resetGame(){
		// Del all playerPref
		PlayerPrefs.DeleteAll ();

		// Del all file of character
		SaveAndLoadManager.deleteAllFile ();

		StartNewGame newGame = new StartNewGame ();
		newGame.setStartNewGame ();

		//Debug.Log ("Game is Reseted!");
	}
}
