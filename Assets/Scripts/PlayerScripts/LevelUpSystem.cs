using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay xu ly thang cap cho nhan vat nguoi choi
public class LevelUpSystem : MonoBehaviour {
	public int XP;
	public int currentLevel;

	// Save data when character level up
	public static void levelUpAndSave(int times){
		GameInfo.Level += times;
		GameInfo.Points += 5 * times;

		// Tang chi so critical theo cap
		int tempCritical = (int)(GameInfo.Critical * Mathf.Pow(1.03f, (float)times));
		//Debug.Log (times);
		if (tempCritical > 10000) {
			GameInfo.Critical = 10000;
		} else {
			GameInfo.Critical = tempCritical;
		}

		// tang chi so toc do di chuyen theo cap
		GameInfo.Speed = (int)(GameInfo.Speed * Mathf.Pow(1.003f, (float)times));

		SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass (), GameInfo.Id);

		// Set lai gia tri cac thong tin nhan vat khi len cap
		PlayerInfo.setPlayerInfoWhenLevelUp (GameInfo.Id);

		// update stat
	}

	// update Xp when player play game
	public static void UpdateXp(int xp){
		//Debug.Log ("Update xp = " + xp);
		//Debug.Log ("Current Xp 1= " + GameInfo.CurrentEx);
		//Debug.Log ("Next level =" + (100 * (GameInfo.Level+ 1) * (GameInfo.Level + 1)));


		GameInfo.CurrentEx += xp;
		//Debug.Log ("Current Xp 2=" + GameInfo.CurrentEx);
		// Get level follow XP
		int ourLevel = (int)(0.1f * Mathf.Sqrt(GameInfo.CurrentEx));
		//Debug.Log ("Level Player: " + GameInfo.Level);
		if (ourLevel != GameInfo.Level && ourLevel<100) {
			FloatTextController.createFloatingText (7, "Level up!", GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMove> ().transform);
			levelUpAndSave (ourLevel - GameInfo.Level);
			//currentLevel = ourLevel;
		}

		// to test and show info
		/*
		int xpNextLevel = 100 * (currentLevel + 1) * (currentLevel + 1);
		int diffXp = xpNextLevel - GameInfo.CurrentEx;

		int totalDiffXp = xpNextLevel - (100 * currentLevel * currentLevel);
		int test = GameInfo.CurrentEx - (100 * currentLevel * currentLevel);

		int a = (int)(test*100 / totalDiffXp);
		levelUp ();
		Debug.Log (a + "%");
		*/

	}

	// update Xp when player play game
	public static void UpdateXpInShop(int xp){
		GameInfo.CurrentEx += xp;
		// Get level follow XP
		int ourLevel = (int)(0.1f * Mathf.Sqrt(GameInfo.CurrentEx));
		//Debug.Log ("Level Player: " + GameInfo.Level);
		if (ourLevel != GameInfo.Level) {
			//FloatTextController.createFloatingText (7, "Level up!", GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMove> ().transform);
			levelUpAndSave (ourLevel - GameInfo.Level);
			//currentLevel = ourLevel;
		}

	}
		
}
