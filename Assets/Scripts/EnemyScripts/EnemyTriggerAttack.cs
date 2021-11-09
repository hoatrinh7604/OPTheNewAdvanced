using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay xu ly va cham giua tan cong cua Enemy voi nhan vat
public class EnemyTriggerAttack : MonoBehaviour {
	private PlayerState player;
	private EnemySound sound;

	const string nameEAttack1 = "EAttack1";
	const string nameEAttack2 = "EAttack2";
	const string nameEAttack3 = "EAttack3";
	const string nameEAttack4 = "EAttack4";
	const string nameEAttack5 = "EAttack5";
	const string nameERunAttack = "ERunAttack";
	const string nameESKill1 = "ESkill1";
	const string nameESkill2 = "ESkill2";

	void Start(){
		player = GetComponentInParent<PlayerState> ();
		//sound = GameObject.FindGameObjectWithTag ("Sounds").GetComponent<SoundsInGame>();
	}

	void OnTriggerEnter2D(Collider2D col){
		//Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == nameEAttack1) {
			
			int dmg = (int)col.gameObject.GetComponentInParent<EnemyInfo>().currentDmg;
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();

			player.beHurt (knocked [0], col.gameObject.transform.position.x, dmg);

			sound = col.gameObject.GetComponentInParent<EnemyInfo> ().GetComponentInChildren<EnemySound> ();
			sound.playSound (1);
			//Debug.Log ("dam: " + dmg);
			///Debug.Log ("Knocked X = " + knocked[0]);
			//Debug.Log ("Knocked Y = " + knocked [1]);

		}else if (col.gameObject.tag == nameEAttack2) {
			
			int dmg = (int)col.gameObject.GetComponentInParent<EnemyInfo>().currentDmg;
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();

			player.beHurt (knocked [0], col.gameObject.transform.position.x, dmg);

			sound = col.gameObject.GetComponentInParent<EnemyInfo> ().GetComponentInChildren<EnemySound> ();
			sound.playSound (1);

		}else if (col.gameObject.tag == nameEAttack3) {
			
			int dmg = (int)col.gameObject.GetComponentInParent<EnemyInfo>().currentDmg;
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();

			player.beHurt (knocked [0], col.gameObject.transform.position.x, dmg);

			sound = col.gameObject.GetComponentInParent<EnemyInfo> ().GetComponentInChildren<EnemySound> ();
			sound.playSound (1);

		}else if (col.gameObject.tag == nameEAttack4) {

			int dmg = (int)col.gameObject.GetComponentInParent<EnemyInfo>().currentDmg;
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();

			player.beHurt (knocked [0], col.gameObject.transform.position.x, dmg);

			sound = col.gameObject.GetComponentInParent<EnemyInfo> ().GetComponentInChildren<EnemySound> ();
			sound.playSound (1);

		}else if (col.gameObject.tag == nameEAttack5) {

			int dmg = (int)col.gameObject.GetComponentInParent<EnemyInfo>().currentDmg;
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();

			player.beHurt (knocked [0], col.gameObject.transform.position.x, dmg * 2);

			sound = col.gameObject.GetComponentInParent<EnemyInfo> ().GetComponentInChildren<EnemySound> ();
			sound.playSound (1);

		}else if (col.gameObject.tag == nameERunAttack) {

			int dmg = (int)col.gameObject.GetComponentInParent<EnemyInfo>().currentDmg;
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();

			//player.beHurt (knocked [0], col.gameObject.transform.position.x);
			if (col.gameObject.GetComponent<KnockedInfo> ().getCanKnocked()) {
				player.beKnockedDown (knocked, col.gameObject.transform.position.x, dmg);
			} else {
				player.beHurt (knocked [0], col.gameObject.transform.position.x, dmg);
			}

			sound = col.gameObject.GetComponentInParent<EnemyInfo> ().GetComponentInChildren<EnemySound> ();
			sound.playSound (1);

		}else if (col.gameObject.tag == nameESKill1) {
			col.gameObject.GetComponent<SkillController> ().setBox2D ();

			GameObject g = col.gameObject.GetComponent<SkillController> ().thisEnemySkilling;

			int dmg = (int)g.GetComponent<EnemyInfo>().getDameForSkill (1);
			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();
			//Debug.Log ("Damage skill 1:" + dmg);
			if (col.gameObject.GetComponent<KnockedInfo> ().getCanKnocked()) {
				player.beKnockedDown (knocked, g.transform.position.x, dmg);
			} else {
				player.beHurt (knocked [0], g.transform.position.x, dmg);
			}

		}else if (col.gameObject.tag == nameESkill2) {

			GameObject g = col.gameObject.GetComponent<SkillController> ().thisEnemySkilling;

			int dmg = (int)g.GetComponent<EnemyInfo>().getDameForSkill (2);

			float[] knocked = col.gameObject.GetComponent<KnockedInfo> ().getKnockedSkill ();
			//Debug.Log ("Damage skill 2:" + dmg);
			if (col.gameObject.GetComponent<KnockedInfo> ().getCanKnocked()) {
				player.beKnockedDown (knocked, g.transform.position.x, dmg);
			} else {
				player.beHurt (knocked [0], g.transform.position.x, dmg);
			}

		}
	}
}
