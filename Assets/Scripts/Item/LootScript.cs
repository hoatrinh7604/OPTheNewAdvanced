using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// lop nay tinh toan ngau nhien so vat pham ma Enemy rot ra khi chet
public class LootScript : MonoBehaviour {

	[System.Serializable]
	public class DropItem{
		public int idItem;
		public GameObject item;
		public int dropRarity;
	}

	public List <DropItem> lootTable = new List<DropItem> ();
	public int dropChance;

	public void calculateLoot(int idEnemy, int level){
		int calc_dropChance = Random.Range (1, 100);

		if (calc_dropChance > dropChance) {
			return;
		} else {
			//int itemWeight = 0;

			// (int i = 0; i < lootTable.Count; i++) {
				//itemWeight += lootTable [i].dropRarity;
			//}



			for (int j = 0; j < lootTable.Count; j++) {
				int randomValue = Random.Range (0, 100);
				if (randomValue <= lootTable [j].dropRarity) {
					Vector3 ve = new Vector3 (transform.position.x + Random.Range(-5f, -2f),transform.position.y + Random.Range(5f, 10f), transform.position.z);
					GameObject g = Instantiate(lootTable[j].item, ve, Quaternion.identity) as GameObject;
					g.GetComponent<Rigidbody2D> ().AddForce (new Vector2(Random.Range(-100, 100), Random.Range(100, 500)));
					g.GetComponent<ItemScripts> ().setValue (idEnemy, level, lootTable[j].idItem);
					Destroy (g, 8f);
					//return;
				
				}

				//randomValue -= lootTable [j].dropRarity;
			}

			return;
		}

















	}




























}
