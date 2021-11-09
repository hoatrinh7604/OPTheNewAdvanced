using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Lop nay luu lai Id nhan vat ma player luachon, phuc vu cho viec khoi tao nhan vat trong man
public class CharacterSelect : MonoBehaviour {

	public static int characterId;

	public void charaterSelected(int characterIdSelected)
	{
		characterId = characterIdSelected;
		//Debug.Log (characterId);
	}
}
