using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Lop xu ly mua cac vat pham trong game
public class ShopButtonScripts : MonoBehaviour {

	[SerializeField] int currentIdItem;
	[SerializeField] int currentChar;

	[SerializeField] GameObject notificationBuy;
	[SerializeField] GameObject notificationUnlockCharacter;
	[SerializeField] GameObject notificationSuccess;
	[SerializeField] GameObject notificationUnlockedCharacter;
	[SerializeField] GameObject notificationBuyed;
	[SerializeField] GameObject notificationNotEnoughBeri;

	// for character
	[SerializeField] GameObject[] canBuy;
	[SerializeField] GameObject[] isBuyed;

	[SerializeField] Text beriText;

	void Update(){
		beriText.text = getCurency((decimal)PlayerPrefs.GetFloat ("Beri"));

		// Update can buy character
		for (int i = 0; i < canBuy.Length; i++) {// game only has 4 character
			if (checkCharacter (i + 1)) {
				isBuyed [i].SetActive (true);
				canBuy [i].SetActive (false);
			} else {
				canBuy [i].SetActive (true);
				isBuyed [i].SetActive (false);
			}
		}
	}

	public void backFunction()
	{
		SceneManager.LoadScene ("Character");
	}

	public void createCharacter(int idCharacter){
		SaveAndLoadManager.createCharacter (idCharacter);
	}

	// hien thi bang hoi mua v
	public void goToBuyCharacter(int idChar){
		if (idChar == 1) {
			checkBuyCharacter (1);
		} else if (idChar == 2) {
			checkBuyCharacter (2);
		} else if (idChar == 3) {
			checkBuyCharacter (3);
		} else if (idChar == 4) {//Xp1
			checkBuyCharacter(4);
		}
	}

	public void goToBuyItem(int idItem){
		if (idItem == 4) {//Xp1
			notificationBuy.SetActive (true);
			currentIdItem = 4;
		} else if (idItem == 5) {
			notificationBuy.SetActive (true);
			currentIdItem = 5;
		} else if (idItem == 6) {// Stat1
			notificationBuy.SetActive (true);
			currentIdItem = 6;
		} else if (idItem == 7) {
			notificationBuy.SetActive (true);
			currentIdItem = 7;
		} else if (idItem == 8) {
			notificationBuy.SetActive (true);
			currentIdItem = 8;
		} else if (idItem == 9) { // beri by dollar
			notificationBuy.SetActive (true);
			currentIdItem = 9;
		} else if (idItem == 10) {
			notificationBuy.SetActive (true);
			currentIdItem = 10;
		}
	}

	// 
	public void buyChar(){
		setBuyCharacter (currentChar);
	}

	public void buyItem(){
		if (currentIdItem == 4) {
			setBuyItemXp (currentIdItem);
		} else if (currentIdItem == 5) {
			setBuyItemXp (currentIdItem);
		} else if (currentIdItem == 6) {
			setBuyItemStat (currentIdItem);
		} else if (currentIdItem == 7) {
			setBuyItemStat (currentIdItem);
		} else if (currentIdItem == 8) {
			setBuyItemStat (currentIdItem);
		} else if (currentIdItem == 9) {
			setBuyItemBeri (currentIdItem);
		} else if (currentIdItem == 10) {
			setBuyItemBeri (currentIdItem);
		} else if (currentIdItem == 20) {// for Enel
			setBuyCharacter (20);
		}
	}

	public void checkBuyCharacter(int idCharacter){
		if (checkCharacter (idCharacter)) {
			notificationBuyed.SetActive (true);
		} else {
			notificationUnlockCharacter.SetActive (true);
			currentChar = idCharacter;
		}
	}

	// for Character
	public void setBuyCharacter(int idCharacter){
		notificationUnlockCharacter.SetActive (false);

		if (idCharacter == 1) {
			if (PlayerPrefs.GetFloat ("Beri") < 1000000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else if (!checkCharacter (idCharacter)) {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 1000000f);

				SaveAndLoadManager.createCharacter (idCharacter);
				notificationUnlockedCharacter.SetActive (true);
			} else {
				notificationBuyed.SetActive (true);
			}
		} else if (idCharacter == 2) {
			if (PlayerPrefs.GetFloat ("Beri") < 3000000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else if (!checkCharacter (idCharacter)) {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 3000000f);

				SaveAndLoadManager.createCharacter (idCharacter);
				notificationUnlockedCharacter.SetActive (true);
			} else {
				notificationBuyed.SetActive (true);
			}
		} else if (idCharacter == 3) {
			if (PlayerPrefs.GetFloat ("Beri") < 7000000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else if (!checkCharacter (idCharacter)) {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 7000000f);

				SaveAndLoadManager.createCharacter (idCharacter);
				notificationUnlockedCharacter.SetActive (true);
			} else {
				notificationBuyed.SetActive (true);
			}
		} else if (idCharacter == 4) {
			if (PlayerPrefs.GetFloat ("Beri") < 20000000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else if (!checkCharacter (idCharacter)) {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 20000000f);

				SaveAndLoadManager.createCharacter (4);
				notificationUnlockedCharacter.SetActive (true);
			} else {
				notificationBuyed.SetActive (true);
			}
		}

	}

	// for Xp item
	public void setBuyItemXp(int idItem){
		notificationBuy.SetActive (false);
		if (idItem == 4) {
			if (PlayerPrefs.GetFloat ("Beri") < 10000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 10000f);
				LevelUpSystem.UpdateXpInShop (10000);

				SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass (), GameInfo.Id);

				notificationSuccess.SetActive (true);
			}
		} else if (idItem == 5) {
			if (PlayerPrefs.GetFloat ("Beri") < 400000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 400000f);
				LevelUpSystem.UpdateXpInShop (500000);

				SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass (), GameInfo.Id);

				notificationSuccess.SetActive (true);
			}
		}
	}

	// for Stat item
	public void setBuyItemStat(int idItem){
		notificationBuy.SetActive (false);
		if (idItem == 6) {
			if (PlayerPrefs.GetFloat ("Beri") < 20000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 20000f);
				GameInfo.Points += 5;

				SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass (), GameInfo.Id);

				notificationSuccess.SetActive (true);
			}
		}else if (idItem == 7) {
			if (PlayerPrefs.GetFloat ("Beri") < 38000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 38000f);
				GameInfo.Points += 10;

				SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass (), GameInfo.Id);

				notificationSuccess.SetActive (true);
			}
		}else if (idItem == 8) {
			if (PlayerPrefs.GetFloat ("Beri") < 200000f) {
				notificationNotEnoughBeri.SetActive (true);
			} else {
				PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") - 200000f);
				GameInfo.Points += 5;

				SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass (), GameInfo.Id);

				notificationSuccess.SetActive (true);
			}
		}
	}

	// for Beri item
	public void setBuyItemBeri(int idItem){
		notificationBuy.SetActive (false);
		if (idItem == 9) {
			PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") + 500000);
			notificationSuccess.SetActive (true);
		} else if (idItem == 10) {
			PlayerPrefs.SetFloat ("Beri", PlayerPrefs.GetFloat ("Beri") + 10000000);
			notificationSuccess.SetActive (true);
		}
	}

	public bool checkCharacter(int idCharacter){
		if (PlayerPrefs.GetInt ("Character" + idCharacter) == 1) {
			return true;
		}
		return false;
	}

	public string getCurency(decimal number){
		string temp = number.ToString ();
		string temp2 = "";
		int j = temp.Length % 3;
		for (int i = 0; i < temp.Length; i++) {
			if (i%3 == j && i!= 0) {
				temp2 += ",";
			}
			temp2 += temp [i];
		}
		return temp2;
	}

	public int resetStat(){
		return 5 + (GameInfo.Level - 1) * 5;
	}
}
