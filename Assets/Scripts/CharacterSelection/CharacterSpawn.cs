using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay phu trach viec tao nhan vat duoc chon trong man theo Id tu CharacterSelect
public class CharacterSpawn : MonoBehaviour {

	public GameObject[] characters;
	public Transform characterSpawnPoint;

	void Awake () {
		//Instantiate (characters[CharacterSelect.characterId], characterSpawnPoint.position, characterSpawnPoint.rotation);
		Instantiate (characters[GameInfo.Id - 1], characterSpawnPoint.position, characterSpawnPoint.rotation);
	}

}
