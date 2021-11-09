using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lop nay phu trach xu ly cac su kien nhan nut tren man hinh man choi
public class LoadIconByCharacter : MonoBehaviour {

	public GameObject[] listIconParent;
	private GameObject player;

	[SerializeField] Text[] textSkill;
	[SerializeField] GameObject[] cantSkill;

	private float timeReSkill1;
	private float timeReSkill2;

	// Use this for initialization
	void Start () {
		listIconParent [GameInfo.Id - 1].SetActive (true);
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		timeReSkill1 -= Time.deltaTime;
		timeReSkill2 -= Time.deltaTime;

		textSkill [0].text = timeReSkill1.ToString ("F1");
		textSkill [1].text = timeReSkill2.ToString ("F1");

		if (timeReSkill1 <= 0) {
			timeReSkill1 = 0;
			cantSkill [0].SetActive (false);
		}

		if (timeReSkill2 <= 0) {
			timeReSkill2 = 0;
			cantSkill [1].SetActive (false);
		}
			
	}

	public void attack(){
		player.GetComponent<ComboAttack> ().attackClick ();
		jumpAttack ();
	}

	public void cross(){
		player.GetComponent<PlayerMove> ().cross ();
	}

	public void jump(){
		player.GetComponent<PlayerJump> ().jump();
	}

	public void jumpAttack(){
		player.GetComponent<PlayerJump> ().jumpAttack();
	}

	public void skill1(){
		float valueSkill = player.GetComponent<ComboSkill> ().skill1 ();

		if (valueSkill != 0) {
			timeReSkill1 = valueSkill;
			cantSkill [0].SetActive (true);
		}
	}

	public void skill2(){
		float valueSkill = player.GetComponent<ComboSkill> ().skill2 ();

		if (valueSkill != 0) {
			timeReSkill2 = valueSkill;
			cantSkill [1].SetActive (true);
		}
	}
}
