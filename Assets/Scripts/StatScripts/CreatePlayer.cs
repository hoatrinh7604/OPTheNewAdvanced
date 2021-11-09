using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

// Phu trach viec Set, save, load thong tin nhan vat trong scene Character
public class CreatePlayer : MonoBehaviour {

	private BaseClass newPlayer;
	//private string playerName = "Player1";

	//UI
	public Text nameText;
	public Text levelText;
	public Text currentExText;

	public Text healthText;
	public Text energyText;
	public Text strengthText;
	public Text armorText;
	public Text speedText;
	public Text criticalText;

	public Text bountyText;
	public Text biographyText;

	public Text beriText;

	//private int pointToSpend = 0;
	public Text pointText;

	// change Character
	[SerializeField] GameObject[] changeObject = {null, null};
	[SerializeField] GameObject[] listFace;

	// Use this for initialization
	void Start () {
		newPlayer = new BaseClass ();
		loadDataById (PlayerPrefs.GetInt("CurrentCharacter"));// load Luffy
		//UpdateUI ();
	}

	void Update(){
		// update beri
		beriText.text =getCurency((decimal)PlayerPrefs.GetFloat("Beri"));

	
		if (getNumCharacterCanUse () > 1 && getNextIdCharacter() > 1) {
			changeObject [1].SetActive (true);
		} else {
			changeObject [1].SetActive (false);
		}
			
		if (GameInfo.Id > 1) {
			changeObject [0].SetActive (true);
		} else {
			changeObject [0].SetActive (false);
		}
	}

	// Luu lai thong so ma nguoi choi thay doi tren bang stat khi nguoi choi an save
	public void saveData(){
		SaveAndLoadManager.saveCharacter (newPlayer, newPlayer.Id);
		loadDataById (GameInfo.Id);
	}

	public void loadCurrentData(){
		loadDataById (GameInfo.Id);
	}

	public void loadDataById(int idCharacter){
		PlayerPrefs.SetInt ("CurrentCharacter", idCharacter);

		PlayerData data = new PlayerData (new BaseClass());
		data = SaveAndLoadManager.loadCharacter (idCharacter);
		newPlayer.Id = idCharacter;

		newPlayer.Name = data.name;
		newPlayer.Level = data.stats [0];
		newPlayer.CurrentEx = data.stats [1];
		newPlayer.Health = data.stats [2];
		newPlayer.Energy = data.stats [3];
		newPlayer.Strength = data.stats [4];
		newPlayer.Armor = data.stats [5];
		newPlayer.Speed = data.stats [6];
		newPlayer.Critical = data.stats [7];
		newPlayer.Points = data.stats [8];
		newPlayer.Bounty = data.stats [9];

		newPlayer.Biography = data.biography;

		UpdateUI ();
		updatGameInfo ();
		//Debug.Log (GameInfo.Id +" and " + GameInfo.Name);
	}

	public void resetData(){
		SaveAndLoadManager.resetCharacter (newPlayer.Id);
		loadDataById (GameInfo.Id);
	}

	// Del all file data of character
	// Becarefull with it
	public void deleteFile(){
		SaveAndLoadManager.deleteAllFile ();
		//Debug.Log ("Delete!");
	}
	
	void UpdateUI(){

		nameText.text = newPlayer.Name;
		levelText.text = newPlayer.Level.ToString();
		currentExText.text = getXp().ToString ();

		healthText.text = newPlayer.Health.ToString ();
		energyText.text = newPlayer.Energy.ToString ();
		strengthText.text = newPlayer.Strength.ToString ();
		armorText.text = newPlayer.Armor.ToString ();
		speedText.text = newPlayer.Speed.ToString ();
		criticalText.text = (newPlayer.Critical / 100).ToString ();
		strengthText.text = newPlayer.Strength.ToString ();

		bountyText.text = getCurency((decimal)newPlayer.Bounty);
		biographyText.text = newPlayer.Biography;

		pointText.text = newPlayer.Points.ToString ();
	}

	// Update GameInfo
	public void updatGameInfo(){
		GameInfo.Id = newPlayer.Id;
		GameInfo.Level = newPlayer.Level;
		GameInfo.Name = newPlayer.Name;
		GameInfo.CurrentEx = newPlayer.CurrentEx;

		GameInfo.Strength = newPlayer.Strength;
		GameInfo.Health = newPlayer.Health;
		GameInfo.Energy = newPlayer.Energy;
		GameInfo.Armor = newPlayer.Armor;
		GameInfo.Speed = newPlayer.Speed;
		GameInfo.Critical = newPlayer.Critical;
		GameInfo.Points = newPlayer.Points;
		GameInfo.Bounty = newPlayer.Bounty;
		GameInfo.Biography = newPlayer.Biography;
	}

	// Set when incre or decre
	public void setHealth(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Health += amount;
				newPlayer.Points -= 1;
				UpdateUI ();
				//Debug.Log (GameInfo.Health + " and " + newPlayer.Health);
			} else if (amount < 0 && newPlayer.Health > GameInfo.Health) {
				// if click button deButton
				newPlayer.Health += amount; // amount < 0
				newPlayer.Points += 1;
				UpdateUI ();
			}
		} else {
			//Debug.Log ("No class choosen!");
		}
	}

	public void setEnergy(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Energy += amount;
				newPlayer.Points -= 1;
				UpdateUI ();
			} else if (amount < 0 && newPlayer.Energy > GameInfo.Energy) {
				// if click button deButton
				newPlayer.Energy += amount; // amount < 0
				newPlayer.Points += 1;
				UpdateUI ();
			}
		} else {
			//Debug.Log ("No class choosen!");
		}
	}

	public void setStrength(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Strength += amount;
				newPlayer.Points -= 1;

				UpdateUI ();
			} else if (amount < 0 && newPlayer.Strength > GameInfo.Strength) {
				// if click button deButton
				newPlayer.Strength += amount; // amount < 0
				newPlayer.Points += 1;

				UpdateUI ();
			}
		} else {
			//Debug.Log ("No class choosen!");
		}
	}

	public void setArmor(int amount){
		if (newPlayer.Id > 0) {
			if (amount > 0 && newPlayer.Points > 0) {
				// if click inButton
				newPlayer.Armor += amount;
				newPlayer.Points -= 1;
				UpdateUI ();
			} else if (amount < 0 && newPlayer.Armor > GameInfo.Armor) {
				// if click button deButton
				newPlayer.Armor += amount; // amount < 0
				newPlayer.Points += 1;
				UpdateUI ();
			}
		} else {
			//Debug.Log ("No class choosen!");
		}
	}

	// get %Xp
	public int getXp(){
		int xpNextLevel = 100 * (newPlayer.Level + 1) * (newPlayer.Level + 1);
		//int diffXp = xpNextLevel - newPlayer.CurrentEx;

		int totalDiffXp = xpNextLevel - (100 * newPlayer.Level * newPlayer.Level);
		int curXp = newPlayer.CurrentEx - (100 * newPlayer.Level * newPlayer.Level);

		int a = (int)(curXp*100 / totalDiffXp);

		return a;
	}

	// Get currency
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

	// get num of the character can use
	public int getNumCharacterCanUse(){
		int num = 0;
		for (int i = 1; i < 5; i++) {
			if (PlayerPrefs.GetInt ("Character" + i) == 1) {
				num++;
			}
		}
		//Debug.Log ("num = " + num);
		return num;
	}

	public int getNextIdCharacter(){
		for (int i = 1; i < 5; i++) {
			if (PlayerPrefs.GetInt ("Character" + i) == 1) {
				if (GameInfo.Id < i) {
					return i;
				}
			}
		}
		return 1;
	}

	public int getPreIdCharacter(){
		for (int i = 4; i > 0; i--) {
			if (PlayerPrefs.GetInt ("Character" + i) == 1) {
				if (GameInfo.Id > i) {
					return i;
				}
			}
		}
		return 1;
	}

	public void changeCharacter(bool right){
		/*
		if (GameInfo.Id == 1) {
			listFace [2].SetActive (true);
			listFace [1].SetActive (false);
			listFace [0].SetActive (false);

			GameInfo.Id = 2;
			loadDataById (GameInfo.Id);
		}else if (GameInfo.Id == 2) {
			listFace [2].SetActive (true);
			listFace [0].SetActive (false);
			listFace [1].SetActive (false);

			GameInfo.Id = 3;
			loadDataById (GameInfo.Id);
		}else if (GameInfo.Id == 3) {
			listFace [0].SetActive (true);
			listFace [1].SetActive (false);
			listFace [2].SetActive (false);

			GameInfo.Id = 1;
			loadDataById (GameInfo.Id);
		}
		*/
		if (right) {
			loadDataById (getNextIdCharacter());
		} else {
			loadDataById (getPreIdCharacter());
		}


		setDisableGameObjectWithOutId (GameInfo.Id);
		//Debug.Log ("Id player:" + GameInfo.Id);

	}
		
		
	public void setDisableGameObjectWithOutId(int id){
		for (int i = 0; i < 4; i++) {
			if ((id-1) == i) {
				listFace [i].SetActive (true);
			} else {
				listFace [i].SetActive (false);
			}
		}
	}
		
}
	
