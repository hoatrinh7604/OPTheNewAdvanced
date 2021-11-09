using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay phuc vu hien thi huong dan trong game
public class TutorialGame : MonoBehaviour {

	[SerializeField] GameObject listParent;
	[SerializeField] GameObject[] listTutorial;

	[SerializeField] GameObject buttonBack;
	[SerializeField] GameObject buttonContinue;
	[SerializeField] int currentId;

	// Use this for initialization
	void Start () {
		currentId = 0;
		//listParent.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentId == 0) {
			buttonBack.SetActive (false);
		} else if (currentId == listTutorial.Length - 1) {
			buttonContinue.SetActive (false);
		} else {
			buttonBack.SetActive (true);
			buttonContinue.SetActive (true);
		}
	}

	public void skip(){
		listTutorial [currentId].SetActive (false);
		currentId++;
	}

	public void back(){
		
		currentId--;
		listTutorial [currentId].SetActive (true);

	}

	public void setEndTutorial(){

	}

	public void getTutorial(){
		listParent.SetActive (true);
		buttonContinue.SetActive (true);
	}
}
