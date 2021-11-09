using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay tinh toan gia tri ngau nhien cho cac vat pham ma Enemy roi ra khi chet
public class ItemScripts : MonoBehaviour {

	[SerializeField] float valueItem;

	public void setValue(int idEnemy, int level, int kindItem){
		if (kindItem == 1) {// beri 1
			valueItem = level * idEnemy * Random.Range (1, 5) * 10; 
		} else if (kindItem == 2) { // Beri 2
			valueItem = level * idEnemy * Random.Range (1, 5) * 1000; 
		} else if (kindItem == 3) { // Hp
			valueItem = level * idEnemy * Random.Range (1, 5) * 5; 
		}else if(kindItem == 4){// Mn
			valueItem = level * idEnemy * Random.Range (1, 5) * 6;
		}
	}

	public float getValue(){
		return valueItem;
	}
}
