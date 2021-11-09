using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly cac am thanh cho cac nhan vat nguoi choi
public class CharacterSound : MonoBehaviour {

	[SerializeField] AudioClip hit, run, jump, skill1, skill2, die, hurt, mSkill1, mSkill2;

	[SerializeField] AudioSource aSound;

	private float volume;
	// Use this for initialization
	void Start () {
		volume = PlayerPrefs.GetFloat ("SoundEF");

		hit = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/hit");
		run = Resources.Load<AudioClip> ("Sounds/Character/Charactcer"+GameInfo.Id+"/run");
		jump = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/jump");
		skill1 = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/skill1");
		skill2 = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/skill2");
		hurt = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/hurt");
		die = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/die");
		mSkill1 = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/mskill1");
		mSkill2 = Resources.Load<AudioClip> ("Sounds/Character/Character"+GameInfo.Id+"/mskill2");

		aSound = GetComponent<AudioSource> ();
		aSound.volume = volume;
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
			aSound.clip = run;
			aSound.PlayOneShot (run);
			break;
		case 3:
			aSound.clip = jump;
			aSound.PlayOneShot (jump);
			break;
		case 4:
			aSound.clip = skill1;
			aSound.PlayOneShot (skill1);
			break;
		case 5:
			aSound.clip = skill2;
			aSound.PlayOneShot (skill2);
			break;
		case 6:
			aSound.clip = hurt;
			aSound.PlayOneShot (hurt);
			break;
		case 7:
			aSound.clip = die;
			aSound.PlayOneShot (die);
			break;
		case 8:
			aSound.clip = mSkill1;
			aSound.PlayOneShot (mSkill1);
			break;
		case 9:
			aSound.clip = mSkill2;
			aSound.PlayOneShot (mSkill2);
			break;
		}
	}
}
