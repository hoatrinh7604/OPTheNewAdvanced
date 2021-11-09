using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will content info of charater
public class PlayerInfo : MonoBehaviour {

	public PlayerInfo(){
		setPlayerInfo (GameInfo.Id);
	}
	public static bool isDead { get; set;}
	public static float playerXp { get; set;}
	public static float playerHealth { get; set;}
	public static float playerMaxHealth { get; set;}
	public static float playerEnergy { get; set;}
	public static float playerMaxEnergy { get; set;}

	public static float playerDamage { get; set;}
	public static float playerArmor { get; set;}
	public static float playerSpeed { get; set;}
	public static int playerCritical { get; set;}

	// Set thong tin cac chi so nhan vat nguoi choi khi dang choi (ap dung ca khi nhan vat len level)
	// Gia tri = chi so co ban theo level + chi so stat cong them
	public static void setPlayerInfo (int idCharacter)
	{
		float n = (float)(GameInfo.Level - 1);
		float x1 = Mathf.Pow (1.04f, n);
		float x2 = Mathf.Pow (1.05f, n);

		if (idCharacter == 1) {// Luffy
			//BaseHealthClass newClass = new BaseHealthClass();
			playerHealth = 600 * x2 + GameInfo.Health * 10;
			playerEnergy = 400 * x2 + GameInfo.Energy * 2;
			playerDamage = 40 * x1 + GameInfo.Strength;
			playerArmor = 20 * x1 + GameInfo.Armor;

			playerMaxHealth = playerHealth;
			playerMaxEnergy = playerEnergy;
			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 2) {// Sanji
			//BaseSpeedClass newClass = new BaseSpeedClass();

			playerHealth = 500 * x1 + GameInfo.Health * 10;
			playerEnergy = 450 * x2 + GameInfo.Energy * 2;
			playerDamage = 50 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerMaxHealth = playerHealth;
			playerMaxEnergy = playerEnergy;
			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 3) {// Zoro
			//BaseStrengthClass newClass = new BaseStrengthClass();

			playerHealth = 600 * x2 + GameInfo.Health * 10;
			playerEnergy = 300 * x1 + GameInfo.Energy * 2;
			playerDamage = 60 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerMaxHealth = playerHealth;
			playerMaxEnergy = playerEnergy;
			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 4) {// Enel
			//BaseStrengthClass newClass = new BaseStrengthClass();

			playerHealth = 600 * x2 + GameInfo.Health * 10;
			playerEnergy = 300 * x1 + GameInfo.Energy * 2;
			playerDamage = 60 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerMaxHealth = playerHealth;
			playerMaxEnergy = playerEnergy;
			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		}

		isDead = false;

		//Debug.Log ("Player damage: "+playerDamage+ " health: " + playerHealth + " mana: " + playerEnergy + " armor: " +playerArmor );
	}


	// Reset info when level up
	public static void setPlayerInfoWhenLevelUp (int idCharacter)
	{
		float n = (float)(GameInfo.Level - 1);
		float x1 = Mathf.Pow (1.04f, n);
		float x2 = Mathf.Pow (1.05f, n);

		if (idCharacter == 1) {// Luffy
			//BaseHealthClass newClass = new BaseHealthClass();
			playerMaxHealth = 600 * x2 + GameInfo.Health * 10;
			playerMaxEnergy = 400 * x2 + GameInfo.Energy * 2;
			playerDamage = 40 * x1 + GameInfo.Strength;
			playerArmor = 20 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 2) {// Sanji
			//BaseSpeedClass newClass = new BaseSpeedClass();

			playerMaxHealth = 500 * x1 + GameInfo.Health * 10;
			playerMaxEnergy = 450 * x2 + GameInfo.Energy * 2;
			playerDamage = 50 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 3) {// Zoro
			//BaseStrengthClass newClass = new BaseStrengthClass();

			playerMaxHealth = 600 * x2 + GameInfo.Health * 10;
			playerMaxEnergy = 300 * x1 + GameInfo.Energy * 2;
			playerDamage = 60 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 4) {// Enel
			//BaseStrengthClass newClass = new BaseStrengthClass();

			playerMaxHealth = 600 * x2 + GameInfo.Health * 10;
			playerMaxEnergy = 300 * x1 + GameInfo.Energy * 2;
			playerDamage = 60 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		}

		float inHealth = playerMaxHealth * 0.1f;
		float inEnergy = playerMaxEnergy * 0.15f;

		//FloatTextController.createFloatingText (3, ((int)inHealth).ToString (), gameObject.transform);
		//FloatTextController.createFloatingText (4, ((int)inEnergy).ToString (), gameObject.transform);
		playerHealth += inHealth;
		playerEnergy += inEnergy;
		//isDead = false;
		//Debug.Log ("Player damage: "+playerDamage+ " health: " + playerHealth + " mana: " + playerEnergy + " armor: " +playerArmor );
	}

	// Reset info when level up
	public static void setPlayerInfoWhenChangeStat (int idCharacter)
	{
		float n = (float)(GameInfo.Level - 1);
		float x1 = Mathf.Pow (1.04f, n);
		float x2 = Mathf.Pow (1.05f, n);

		if (idCharacter == 1) {// Luffy
			//BaseHealthClass newClass = new BaseHealthClass();
			playerMaxHealth = 600 * x2 + GameInfo.Health * 10;
			playerMaxEnergy = 400 * x2 + GameInfo.Energy * 2;
			playerDamage = 40 * x1 + GameInfo.Strength;
			playerArmor = 20 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 2) {// Sanji
			//BaseSpeedClass newClass = new BaseSpeedClass();

			playerMaxHealth = 500 * x1 + GameInfo.Health * 10;
			playerMaxEnergy = 450 * x2 + GameInfo.Energy * 2;
			playerDamage = 50 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 3) {// Zoro
			//BaseStrengthClass newClass = new BaseStrengthClass();

			playerMaxHealth = 600 * x2 + GameInfo.Health * 10;
			playerMaxEnergy = 300 * x1 + GameInfo.Energy * 2;
			playerDamage = 60 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		} else if (idCharacter == 4) {// Enel
			//BaseStrengthClass newClass = new BaseStrengthClass();

			playerMaxHealth = 600 * x2 + GameInfo.Health * 10;
			playerMaxEnergy = 300 * x1 + GameInfo.Energy * 2;
			playerDamage = 60 * x2 + GameInfo.Strength;
			playerArmor = 15 * x1 + GameInfo.Armor;

			playerSpeed = GameInfo.Speed;
			playerXp = GameInfo.CurrentEx;
			playerCritical = GameInfo.Critical;
		}
			
		//isDead = false;
		//Debug.Log ("Player damage: "+playerDamage+ " health: " + playerHealth + " mana: " + playerEnergy + " armor: " +playerArmor );
	}
}
