using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly va cham giua nhan vat nguoi choi va cac vat pham
public class TriggerItems : MonoBehaviour {

	const string nameBeri = "ItemBeri";
	const string nameHealth = "ItemHealth";
	const string nameMana = "ItemMana";

	private SoundsInGame sound;

	void Start(){
		sound = GameObject.FindGameObjectWithTag ("Sounds").GetComponent<SoundsInGame> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == nameBeri) {
			float increateValue = col.gameObject.GetComponent<ItemScripts> ().getValue ();

			FloatTextController.createFloatingText (6, "+"+((int)increateValue).ToString (), transform);

			float value = PlayerPrefs.GetFloat ("Beri") + increateValue;
			PlayerPrefs.SetFloat ("Beri", value);
			//Debug.Log("New Beri = " + value);

			Destroy (col.gameObject);

			sound.playSound (2);
		}else if(col.gameObject.tag == nameHealth){
			float increateValue = col.gameObject.GetComponent<ItemScripts> ().getValue ();

			FloatTextController.createFloatingText (3, "+"+((int)increateValue).ToString (), transform);

			PlayerInfo.playerHealth += increateValue;
			Destroy (col.gameObject);
			sound.playSound (3);
		}else if(col.gameObject.tag == nameMana){
			float increateValue = col.gameObject.GetComponent<ItemScripts> ().getValue ();

			FloatTextController.createFloatingText (4, "+"+((int)increateValue).ToString (), transform);

			PlayerInfo.playerEnergy += increateValue;
			Destroy (col.gameObject);
			sound.playSound (3);
		}
	}
}
