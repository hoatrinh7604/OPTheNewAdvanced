using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly chay am thanh nen trong gametheo man hinh
public class BgSounds : MonoBehaviour {

	[SerializeField] AudioClip bgSound, bgOpen, bgFinish, bgGameOver;
	[SerializeField] int idLevelScene;

	private AudioSource aSound;
	private float volume;
	// Use this for initialization
	void Start () {
		volume = PlayerPrefs.GetFloat ("SoundBG");
		aSound = GetComponent<AudioSource> ();

		bgSound = Resources.Load<AudioClip> ("Sounds/Bgsounds/bgs" + idLevelScene);
		bgOpen = Resources.Load<AudioClip> ("Sounds/Bgsounds/soundopen");
		bgFinish = Resources.Load<AudioClip> ("Sounds/Bgsounds/soundfinish");
		bgGameOver = Resources.Load<AudioClip> ("Sounds/Bgsounds/soundgameover");

		aSound.loop = true;
		aSound.volume = 0.3f;

		playSound (1);
		//playSound ();
	}

	// Update is called once per frame
	void Update () {
		updateVolume ();
	}

	public void updateVolume(){
		volume = PlayerPrefs.GetFloat ("SoundBG");
		aSound.volume = volume;
	}

	public void playSound(int idSound){
		switch (idSound) {
		case 1:
			aSound.enabled = false;
			aSound.clip = bgSound;
			aSound.PlayOneShot (bgSound);
			aSound.enabled = true;
			aSound.loop = true;
			break;
		case 2:
			aSound.enabled = false;
			aSound.clip = bgOpen;
			aSound.PlayOneShot (bgOpen);
			aSound.enabled = true;
			aSound.loop = true;
			break;
		case 3:
			aSound.enabled = false;
			aSound.clip = bgFinish;
			aSound.PlayOneShot (bgFinish);
			aSound.enabled = true;
			aSound.loop = false;
			break;
		case 4:
			aSound.enabled = false;
			aSound.clip = bgGameOver;
			aSound.PlayOneShot (bgGameOver);
			aSound.enabled = true;
			aSound.loop = false;
			break;
		}
	}
}
