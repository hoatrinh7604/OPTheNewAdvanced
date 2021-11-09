using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Hien thi thong tin cac thanh Slider nguoi choi trong man choi
public class ManagerController : MonoBehaviour {
	public static float outWar = -1;
	[SerializeField] PlayerStat pHealthBar;
	[SerializeField] PlayerStat pManaBar;
	[SerializeField] PlayerStat pXpBar;

	[SerializeField] Text textCurHealth;
	[SerializeField] Text textMaxHealth;
	[SerializeField] Text textCurMana;
	[SerializeField] Text textMaxMana;

	[SerializeField] Text textLevel;
	[SerializeField] Text textBounty;
	[SerializeField] Text textBeri;

	//private float currentHealth;
	//private float currentMana;
	//private float currentXp;

	// Use this for initialization
	void Start () {
		// set bar health follow player
		pHealthBar.setValueBar (PlayerInfo.playerHealth, PlayerInfo.playerHealth);
		pManaBar.setValueBar (PlayerInfo.playerEnergy, PlayerInfo.playerEnergy);
		pXpBar.setValueBar (getCurrentLevelXp(), getCurrentLevelXp());

		textCurHealth.text = ((int)PlayerInfo.playerHealth).ToString();
		textMaxHealth.text = "/" + ((int)PlayerInfo.playerMaxHealth).ToString();

		textCurMana.text = ((int)PlayerInfo.playerEnergy).ToString();
		textMaxMana.text = "/" + ((int)PlayerInfo.playerMaxEnergy).ToString ();

		//currentHealth = PlayerInfo.playerHealth;
		//currentMana = PlayerInfo.playerEnergy;
		//currentXp = getCurrentXp();
		//currentHealth = maxHealth;	
	}
	
	// Update is called once per frame
	void Update () {
		outWar -= Time.deltaTime;

		textLevel.text = (GameInfo.Level).ToString();
		textBounty.text = getCurency((decimal)GameInfo.Bounty);
		textBeri.text = getCurency((decimal)PlayerPrefs.GetFloat ("Beri"));


		if (!PlayerInfo.isDead) {
			//currentMana = PlayerInfo.playerEnergy;
			pXpBar.MaxValue = getCurrentLevelXp ();
			pHealthBar.MaxValue = PlayerInfo.playerMaxHealth;
			pManaBar.MaxValue = PlayerInfo.playerMaxEnergy;
			//currentXp = getCurrentXp ();

			if (outWar < 0) {
				PlayerInfo.playerHealth += PlayerInfo.playerMaxHealth * Time.deltaTime * GameInfo.Level / 2000;
				PlayerInfo.playerEnergy += PlayerInfo.playerMaxEnergy * Time.deltaTime * GameInfo.Level / 2000;
			}

			textMaxHealth.text = "/" + ((int)PlayerInfo.playerMaxHealth).ToString();
			textMaxMana.text = "/" + ((int)PlayerInfo.playerMaxEnergy).ToString ();

			// Prevented the stat is out of range (0, max)
			pHealthBar.CurrentValue = PlayerInfo.playerHealth;
			PlayerInfo.playerHealth = pHealthBar.CurrentValue;

			pManaBar.CurrentValue = PlayerInfo.playerEnergy;
			PlayerInfo.playerEnergy = pManaBar.CurrentValue;

			pXpBar.MaxValue = getCurrentLevelXp ();
			pXpBar.CurrentValue = getCurrentXp ();

			textCurHealth.text = ((int)PlayerInfo.playerHealth).ToString();
			textCurMana.text = ((int)PlayerInfo.playerEnergy).ToString();
			//currentXp = pXpBar.CurrentValue;
		} else {
			pHealthBar.CurrentValue = 0;
			textCurHealth.text = "0";
		}


	}

	public int getXp(){
		int xpNextLevel = 100 * (GameInfo.Level + 1) * (GameInfo.Level + 1);
		//int diffXp = xpNextLevel - GameInfo.CurrentEx;

		int totalDiffXp = xpNextLevel - (100 * GameInfo.Level * GameInfo.Level);
		int curXp = GameInfo.CurrentEx - (100 * GameInfo.Level * GameInfo.Level);

		int a = (int)(curXp*100 / totalDiffXp);

		return a;
	}

	public float getCurrentXp(){
		int curXp = GameInfo.CurrentEx - (100 * GameInfo.Level * GameInfo.Level);
		return (float)curXp;
	}

	public float getCurrentLevelXp(){
		int xpNextLevel = 100 * (GameInfo.Level + 1) * (GameInfo.Level + 1);
		//int diffXp = xpNextLevel - GameInfo.CurrentEx;

		int totalDiffXp = xpNextLevel - (100 * GameInfo.Level * GameInfo.Level);
		return (float)totalDiffXp;
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
