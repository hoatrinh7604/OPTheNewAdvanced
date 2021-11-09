using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	[SerializeField] GameObject hideObject;

	void Start(){
		hideObject.SetActive (false);
	}

	public void openHide(){
		if (PlayerPrefsX.GetBool ("isFinished24")) {// Man cuoi
			hideObject.SetActive(true);
		}
	}
}
