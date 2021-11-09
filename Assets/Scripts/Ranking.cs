using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct rank_data {
	public int id;
	public string name;
	public int level;
	public int bounty;
};

public class Ranking : MonoBehaviour {
	private BaseClass newPlayer;
	private List<rank_data> listC = new List<rank_data>();
	private List<rank_data> listRankingC = new List<rank_data>();

	public GameObject scorePrefab;
	public Transform scoreParent;

	void Start () {
		ListCharacter ();
		sortList ();
		//UpdateUI ();
		showPrefab();
	}

	private rank_data loadDataById(int idCharacter){
		rank_data tempData = new rank_data ();

		PlayerData data = new PlayerData (new BaseClass());
		data = SaveAndLoadManager.loadCharacter (idCharacter);
		tempData.id = idCharacter;
		tempData.name = data.name;
		tempData.level = data.stats [0];
		tempData.bounty = data.stats [9];

		return tempData;
		//Debug.Log (GameInfo.Id +" and " + GameInfo.Name);
	}

	public void ListCharacter()
	{
		Debug.Log ("Number character: "+PlayerPrefs.GetInt ("NumberCharacter"));
		for (int i = 1; i < 5; i++) {
			if (PlayerPrefs.GetInt ("Character" + i) != 0) {
				rank_data tempCharacter = loadDataById(i);
				listRankingC.Add (tempCharacter);
			}
		}
	}

	public void sortList()
	{
		rank_data tempData = new rank_data ();
		int leng = listRankingC.Count;
		Debug.Log ("Leng = " + leng);
		for (int i = 0; i < leng; i++) {
			for (int j = i + 1; j < leng; j++) {
				if (listRankingC [i].bounty < listRankingC [j].bounty) {
					tempData = listRankingC [i];
					listRankingC [i] = listRankingC [j];
					listRankingC [j] = tempData;
				}
			}
		}
	}

	private void showPrefab()
	{
		for (int i = 0; i < listRankingC.Count; i++) {
			Debug.Log ("12345 and "+ listRankingC.Count);
			GameObject tempGameO = Instantiate (scorePrefab);
			Debug.Log ("show "+ listRankingC[i].name);
			tempGameO.GetComponent<RankingScript> ().setScore ("#" + (i+1), listRankingC[i].name, listRankingC [i].bounty.ToString());
			tempGameO.transform.SetParent (scoreParent);
			tempGameO.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		}
	}
}
