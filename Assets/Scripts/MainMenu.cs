using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Lop ap dung cho man hinh chinh, xu ly co ban cac chuc nang
public class MainMenu : MonoBehaviour {

	[SerializeField] GameObject newGame;

	public void getPlayGame(){
		if (PlayerPrefs.GetInt ("IsNewGame") == 0) {
			newGame.SetActive (true);
		} else {
			playGame ();
		}
	}

	public void playGame()
	{
		PlayerPrefs.SetInt ("IsNewGame", 1);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void shopGame()
	{
		SceneManager.LoadScene ("ShopGame");
	}

	public void backToMainMenu(){
		SceneManager.LoadScene ("StartMenu");
	}

	public void quitGame()
	{
		Debug.Log ("Quit!");
		Application.Quit ();
	}
}
