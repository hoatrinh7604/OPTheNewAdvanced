using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingScript : MonoBehaviour {

	public GameObject rank;
	public GameObject scorename;
	public GameObject scorebounty;

	public string getCurency(decimal number){
		string temp = number.ToString ();
		string temp2 = "";
		int j = temp.Length % 3;
		for (int i = 0; i < temp.Length; i++) {
			if (i%3 == j && i!= 0) {
				temp2 += ",";
			}
			temp2 += temp [i];
		}
		return temp2;
	}

	public void setScore(string rank, string scorename, string scorebounty){
		this.rank.GetComponent<Text> ().text = rank;
		this.scorename.GetComponent<Text> ().text = scorename;
		this.scorebounty.GetComponent<Text> ().text = getCurency((decimal)int.Parse(scorebounty));
	}
}
