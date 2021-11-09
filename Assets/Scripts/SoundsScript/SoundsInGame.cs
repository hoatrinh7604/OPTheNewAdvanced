using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly cac am thanh thong bao
public class SoundsInGame : MonoBehaviour {

	[SerializeField] AudioClip hit, itemCoin, itemHealth, jump;

	[SerializeField] AudioSource aSound;

	private float volume;
	// Use this for initialization
	void Start () {
		volume = PlayerPrefs.GetFloat ("SoundEF");

		hit = Resources.Load<AudioClip> ("Sounds/hit");
		itemCoin = Resources.Load<AudioClip> ("Sounds/itemcoin");
		itemHealth = Resources.Load<AudioClip> ("Sounds/itemhealth");
		jump = Resources.Load<AudioClip> ("Sounds/jump");

		aSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		updateVolume ();
	}

	public void updateVolume(){
		volume = PlayerPrefs.GetFloat ("SoundEF");
		aSound.volume = volume;
	}

	public void playSound(int idSound){
		switch (idSound) {
			case 1:
			aSound.clip = hit;
			aSound.PlayOneShot (hit);
				break;
			case 2:
			aSound.clip = itemCoin;
			aSound.PlayOneShot (itemCoin);
				break;
			case 3:
			aSound.clip = itemHealth;
			aSound.PlayOneShot (itemHealth);
				break;
			case 4:
			aSound.clip = jump;
			aSound.PlayOneShot (jump);
				break;
		}
	}
		
}
