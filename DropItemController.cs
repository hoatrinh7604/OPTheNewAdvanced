using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour {

	private static GameObject g;
	private static Transform tranRandom;

	private static GameObject canvas;

	public static void Initialize(){
		canvas = GameObject.Find ("Canvas");
	}

	public static void createItem(int idEnemy, GameObject[] itemObject, Transform tran){
		//itemObject.GetComponent<ItemScripts> ().setValue (idEnemy);

		//for (int i = 0; i < itemObject.Length; i++) {
			//for (int j = 0; j < createRandomAmount (idEnemy, i + 1); j++) {
				g = Instantiate (itemObject[0]);
				Vector2 screenPosition = Camera.main.WorldToScreenPoint (new Vector2(tran.position.x + Random.Range(-5f, 5f), tran.position.y + Random.Range(-0.5f, 5f)));
				g.transform.SetParent (canvas.transform, false);
				g.transform.position = screenPosition;

				//g.GetComponent<ItemScripts> ().setValue (idEnemy);
			//}
		//


		//GameObject g = Instantiate (itemObject[0], tran) as GameObject;
		//Vector2 screenPosition = Camera.main.WorldToScreenPoint (new Vector2(tran.position.x + Random.Range(-0.5f, 3f), tran.position.y + Random.Range(-0.5f, 5f)));
		//g.transform.position = screenPosition;
		//Debug.Log ("Item");
	}

	public static int createRandomAmount(int idEnemy, int kindItem){
		if (kindItem == 1) {
			return Random.Range (idEnemy, idEnemy + 5);
		} else if (kindItem == 2) {
			if (idEnemy > 13) {
				return Random.Range (1, 3);
			} else if (idEnemy > 3) {
				return Random.Range (1, 2);
			}
		} else if (kindItem == 3) {
			return Random.Range (1, idEnemy);
		}
		return 0;
	}
		
}
