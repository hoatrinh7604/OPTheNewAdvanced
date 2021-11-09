using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// lop nay chua thong tin ve cac gia tri thuoc tinh cua Enemy, va khoi tao Enemy
public class EnemyInfo : MonoBehaviour {

	[SerializeField] int idEnemy;

	[SerializeField] int level;
	[SerializeField] Text levelText;
	[SerializeField] Text nameText;

	const string gameDifficult = "GameDifficult";

	public string nameEnemy { get; set;}
	public float maxHealth { get; set;}
	public float maxMana { get; set;}
	public float currentHealth { get; set;}
	public float currentmana { get; set;}
	public float currentDmg { get; set;}
	public float currentArmor { get; set;}

	public float enemyScore { get; set;}
	public float enemyXp { get; set;}


	// set stat follow current level
	public void setStatFollowLevel(){
		setLevel (PlayerPrefs.GetInt(gameDifficult));

		NPC baseEnemyInfo = new NPC();
		baseEnemyInfo.setBaseInfo (idEnemy);

		float n = Mathf.Pow (1.06f, (float)(level - 1));
		float m = Mathf.Pow (1.045f, (float)(level - 1));
		currentHealth = maxHealth = baseEnemyInfo.baseHealth * n + level * 20;
		currentmana = maxMana = baseEnemyInfo.baseMana* n + level * 5;
		currentDmg = baseEnemyInfo.baseDmg * n + level* 5;
		currentArmor = baseEnemyInfo.baseArmor * n + level;

		enemyScore = baseEnemyInfo.baseScore * n;
		enemyXp = baseEnemyInfo.baseXp * m;

		nameEnemy = baseEnemyInfo.nameEnemy;
		levelText.text = "Lv." + level;
		nameText.text = nameEnemy;

		//Debug.Log ("Enemy "+ idEnemy + ": " + maxHealth + "; " + maxMana + "; " + currentDmg + "; " + currentArmor + "; xp =" + enemyXp );
	}

	public int getLevel(){
		return level;
	}

	public void setLevel(int kindOfPlay){
		int levelScene = SceneManager.GetActiveScene ().buildIndex - 3;

		if (kindOfPlay == 1) {// easy
			level = Random.Range (levelScene, levelScene + 3);
		} else if (kindOfPlay == 2) {// medium
			if (GameInfo.Level > levelScene) {
				level = GameInfo.Level + Random.Range (3, 5);
			} else {
				level = levelScene + Random.Range (3, 5);
			}
		} else if (kindOfPlay == 3) {// hard
			if (GameInfo.Level > levelScene) {
				level = GameInfo.Level + Random.Range (5, 10);
			} else {
				level = levelScene + Random.Range (5, 10);
			}
		} else {
			level = Random.Range (levelScene, levelScene + 3);
		}

		//Debug.Log ("Game difficult:" + kindOfPlay);
	}

	public int getIdEnemy(){
		return idEnemy;
	}

	public int getDameForSkill(int idSkill){
		if (idSkill == 1) {
			return (int)(currentDmg + idEnemy * 10 + maxMana * 0.1f);
		} else if (idSkill == 2) {
			return (int)(currentDmg + idEnemy * 10 + maxMana * 0.3f);
		} else {
			return 0;
		}
	}
}
