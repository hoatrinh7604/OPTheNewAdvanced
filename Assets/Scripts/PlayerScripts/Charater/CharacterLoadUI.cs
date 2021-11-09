using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lop nay hien thi bieu tuong nhan vat trong man choi
public class CharacterLoadUI : MonoBehaviour {

	[SerializeField] GameObject[] listFace;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		enableObjectById (GameInfo.Id);
	}

	public void enableObjectById(int id){
		for (int i = 0; i < listFace.Length; i++) {
			if ((i + 1) == id) {
				listFace [i].SetActive (true); 
			} else {
				listFace [i].SetActive (false);
			}
		}
	}
}
