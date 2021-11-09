using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly va cham giua tan cong cua nguoi cho va enemy
public class TriggerSystem : MonoBehaviour {

	private EnemyState eState;
	//private EnemyInfo eInfo;
	private bool isXdamage;

	private CharacterSound sound;

	GameObject player;

	const string nameAttack1 = "Attack1";
	const string nameAttack2 = "Attack2";
	const string nameAttack3 = "Attack3";
	const string nameAttack4 = "Attack4";
	const string nameJumpAttack = "JumpAttack";
	const string nameSkill1 = "Skill1";
	const string nameSkill2 = "Skill2";

	void Start(){
		FloatTextController.Initialize ();
		eState = GetComponentInParent<EnemyState> ();

		player = GameObject.FindGameObjectWithTag ("Player");

		sound = player.GetComponentInChildren<CharacterSound>();
	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == nameAttack1) {
			//int wayAttacked = col.gameObject.GetComponentInParent<PlayerMove> ().getFacingFollowInteger ();
			int wayAttacked = (int)col.gameObject.GetComponentInParent<Transform>().position.x;

			float dmg = setDamageCritical (PlayerInfo.playerDamage, 1.5f);
			dmg = setArmor(dmg);
			//float armor = eInfo.currentArmor;
			if (dmg <= 0) {
				dmg = 1;
			}

			if (isXdamage) {
				FloatTextController.createFloatingText (2, "-"+((int)dmg).ToString (), transform);
			} else {
				FloatTextController.createFloatingText (1, "-"+((int)dmg).ToString (), transform);
			}
				
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();

			// increate mana player when him attacked enemy = 10 % damage
			PlayerInfo.playerEnergy += PlayerInfo.playerMaxEnergy / 100;

			eState.beHurt (wayAttacked, knocked [0], col.gameObject.transform.position.x, dmg);

			sound.playSound (1);


		}else if (col.gameObject.tag == nameAttack2) {
			//int wayAttacked = col.gameObject.GetComponentInParent<PlayerMove> ().getFacingFollowInteger ();
			int wayAttacked = (int)col.gameObject.GetComponentInParent<Transform>().position.x;

			float dmg = setDamageCritical (PlayerInfo.playerDamage, 1.5f);
			dmg = setArmor(dmg);
			if (dmg <= 0) {
				dmg = 1;
			}

			if (isXdamage) {
				FloatTextController.createFloatingText (2, "-"+((int)dmg).ToString (), transform);
			} else {
				FloatTextController.createFloatingText (1, "-"+((int)dmg).ToString (), transform);
			}

			// increate mana player when him attacked enemy = 10 % damage
			PlayerInfo.playerEnergy += PlayerInfo.playerMaxEnergy / 100;

			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();
			eState.beHurt (wayAttacked, knocked [0], col.gameObject.transform.position.x, dmg);

			sound.playSound (1);

		}else if (col.gameObject.tag == nameAttack3) {
			//int wayAttacked = col.gameObject.GetComponentInParent<PlayerMove> ().getFacingFollowInteger ();
			int wayAttacked = (int)col.gameObject.GetComponentInParent<Transform>().position.x;

			float dmg = setDamageCritical (PlayerInfo.playerDamage, 1.5f);
			dmg = setArmor(dmg);
			if (dmg <= 0) {
				dmg = 1;
			}

			if (isXdamage) {
				FloatTextController.createFloatingText (2, "-"+((int)dmg).ToString (), transform);
			} else {
				FloatTextController.createFloatingText (1, "-"+((int)dmg).ToString (), transform);
			}

			// increate mana player when him attacked enemy = 10 % damage
			PlayerInfo.playerEnergy += PlayerInfo.playerMaxEnergy / 100;

			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();
			eState.beHurt (wayAttacked, knocked [0], col.gameObject.transform.position.x, dmg);

			sound.playSound (1);

		}else if (col.gameObject.tag == nameAttack4) {
			//int wayAttacked = col.gameObject.GetComponentInParent<PlayerMove> ().getFacingFollowInteger ();
			int wayAttacked = (int)col.gameObject.GetComponentInParent<Transform>().position.x;

			float dmg = setDamageCritical (PlayerInfo.playerDamage, 2f);
			dmg = setArmor(dmg);
			if (dmg <= 0) {
				dmg = 1;
			}

			if (isXdamage) {
				FloatTextController.createFloatingText (2, "-"+((int)dmg).ToString (), transform);
			} else {
				FloatTextController.createFloatingText (1, "-"+((int)dmg).ToString (), transform);
			}

			// increate mana player when him attacked enemy = 10 % damage
			PlayerInfo.playerEnergy += PlayerInfo.playerMaxEnergy  / 100;

			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();
			eState.beHurt (wayAttacked, knocked [0], col.gameObject.transform.position.x, dmg);

			sound.playSound (1);

		}else if (col.gameObject.tag == nameJumpAttack) {
			//int wayAttacked = col.gameObject.GetComponentInParent<PlayerMove> ().getFacingFollowInteger ();
			int wayAttacked = (int)col.gameObject.GetComponentInParent<Transform>().position.x;

			float dmg = setDamageCritical (2* PlayerInfo.playerDamage, 2.5f);
			dmg = setArmor(dmg);
			if (dmg <= 0) {
				dmg = 1;
			}

			if (isXdamage) {
				FloatTextController.createFloatingText (2, "-"+((int)dmg).ToString (), transform);
			} else {
				FloatTextController.createFloatingText (1, "-"+((int)dmg).ToString (), transform);
			}

			//Debug.Log ("JumpAttack: " + (PlayerInfo.playerDamage + (int)(0.5 * GameInfo.Strength)+ (int)(0.5 * GameInfo.Energy)));
			// increate mana player when him attacked enemy = 10 % damage
			//PlayerInfo.playerEnergy += PlayerInfo.playerHealth / 100;

			KnockedInfo temp = col.gameObject.GetComponent<KnockedInfo> ();

			if (temp.getCanKnocked ()) {
				eState.beKnocked (wayAttacked, temp.getKnockedSkill(), col.transform.position.x, dmg);
			} else {
				eState.beHurt (wayAttacked, temp.getKnockedSkill()[0], col.gameObject.transform.position.x, dmg);
			}

			//sound.playSound (1);
		}else if (col.gameObject.tag == nameSkill1) {
			//col.gameObject.GetComponent<SkillController> ().setBox2D ();
			//int wayAttacked = player.GetComponent<PlayerMove> ().getFacingFollowInteger ();
			int wayAttacked = (int)col.gameObject.GetComponentInParent<Transform>().position.x;

			//Debug.Log ("Skill1: " + (PlayerInfo.playerDamage + (GameInfo.Strength)));
			// increate mana player when him attacked enemy = 10 % damage
			//PlayerInfo.playerEnergy += PlayerInfo.playerHealth / 100;

			float dmg = 2*PlayerInfo.playerDamage + GameInfo.Level * 5 + PlayerInfo.playerMaxEnergy * 0.1f;
			dmg = setDamageCritical (dmg, 2.5f);
			dmg = setArmor(dmg);

			if (dmg <= 0) {
				dmg = 1;
			}

			if (isXdamage) {
				FloatTextController.createFloatingText (2, "-"+((int)dmg).ToString (), transform);
			} else {
				FloatTextController.createFloatingText (1, "-"+((int)dmg).ToString (), transform);
			}
			KnockedInfo temp = col.gameObject.GetComponent<KnockedInfo> ();
			//Debug.Log ("Damage: " + dmg);

			if (temp.getCanKnocked ()) {
				eState.beKnocked (wayAttacked, temp.getKnockedSkill(), player.transform.position.x, dmg);
			} else {
				eState.beHurt (wayAttacked, temp.getKnockedSkill()[0], player.transform.position.x, dmg);
			}

			//sound.playSound (1);
		}else if (col.gameObject.tag == nameSkill2) {
			//col.gameObject.GetComponent<SkillController> ().setBox2D ();
			//int wayAttacked = player.GetComponent<PlayerMove> ().getFacingFollowInteger ();
			int wayAttacked = (int)col.gameObject.GetComponentInParent<Transform>().position.x;

			//Debug.Log ("Skill2: " + (PlayerInfo.playerDamage + (int)(1.5 * GameInfo.Strength)+ (int)(1 * GameInfo.Energy)));
			// increate mana player when him attacked enemy = 10 % damage
			//PlayerInfo.playerEnergy += PlayerInfo.playerHealth / 100;
			float dmg = 2.2f * PlayerInfo.playerDamage + GameInfo.Level * 5 + PlayerInfo.playerMaxEnergy * 0.2f;

			dmg = setDamageCritical (dmg, 3f);
			dmg = setArmor(dmg);

			if (dmg <= 0) {
				dmg = 1;
			}

			if (isXdamage) {
				FloatTextController.createFloatingText (2, "-"+((int)dmg).ToString (), transform);
			} else {
				FloatTextController.createFloatingText (1, "-"+((int)dmg).ToString (), transform);
			}
			KnockedInfo temp = col.gameObject.GetComponent<KnockedInfo> ();

			if (temp.getCanKnocked ()) {
				eState.beKnocked (wayAttacked, temp.getKnockedSkill(), player.transform.position.x, dmg);
			} else {
				eState.beHurt (wayAttacked, temp.getKnockedSkill()[0], player.transform.position.x, dmg);
			}

			//sound.playSound (1);
		}
	}

	public float setDamageCritical(float dmg, float xDamage){
		int tempCritical = Random.Range (1, 100);

		if (GameInfo.Critical / 100 > tempCritical) {
			isXdamage = true;
			return dmg * xDamage;
		}
		isXdamage = false;
		return dmg;
	}

	public float setArmor(float dmg){
		//float percent = GameInfo.Armor / (GameInfo.Level * 5) * 100;// Mac dinh eney la 1/5 = 20%
		float percent = 20f;

		float randomValue = Random.Range (1, percent);
		dmg -= randomValue * dmg / 100; // giam dmg bang chinh luong ti le giam dam toi da cua armr

		return dmg;
	}
}
