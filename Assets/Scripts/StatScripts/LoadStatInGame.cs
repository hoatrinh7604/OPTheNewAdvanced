using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lop xu ly viec thay doi cac chi so cua nhan vat trong man choi
public class LoadStatInGame : MonoBehaviour {

	private BaseClass newPlayer;
	//private string playerName = "Player1";

	//UI
	public Text levelText;
	public Text currentExText;

	public Text healthText;
	public Text energyText;
	public Text strengthText;
	public Text armorText;
	public Text speedText;
	public Text criticalText;

	//private int pointToSpend = 0;
	public Text pointText;

	// Use this for initialization
	void Start () {
		newPlayer = new BaseClass ();
		loadDataById (PlayerPrefs.GetInt("CurrentCharacter"));// load Luffy
		//UpdateUI ();
	}

	void Update(){
		currentExText.text = getXp().ToString ();

		if (newPlayer.Level < GameInfo.Level) {
			loadDataById (GameInfo.Id);
		}
	}

	// Luu lai thong so ma nguoi choi thay doi tren bang stat khi nguoi choi an save
	public void saveData(){
		newPlayer.CurrentEx = GameInfo.CurrentEx;
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
		PlayerInfo.setPlayerInfoWhenChangeStat (GameInfo.Id);
		//Debug.Log (GameInfo.Id +" and " + GameInfo.Name);
	}



	void UpdateUI(){

		levelText.text = newPlayer.Level.ToString();
		currentExText.text = getXp().ToString ();

		healthText.text = newPlayer.Health.ToString ();
		energyText.text = newPlayer.Energy.ToString ();
		strengthText.text = newPlayer.Strength.ToString ();
		armorText.text = newPlayer.Armor.ToString ();
		speedText.text = newPlayer.Speed.ToString ();
		criticalText.text = (newPlayer.Critical / 100).ToString ();
		strengthText.text = newPlayer.Strength.ToString ();

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
		int curXp = GameInfo.CurrentEx - (100 * newPlayer.Level * newPlayer.Level);

		int a = (int)(curXp*100 / totalDiffXp);

		return a;
	}
		
}
