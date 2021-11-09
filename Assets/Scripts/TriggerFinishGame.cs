using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Xu ly qua man choi cho nguoi choi
public class TriggerFinishGame : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "FinishedGame"){
			// save data character
			SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass(), GameInfo.Id);
			// One next scene level
			col.gameObject.GetComponentInParent<StoryManager>().setEndStory();

		}
	}
}
