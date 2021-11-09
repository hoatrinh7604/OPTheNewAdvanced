using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly cac am thanh cho Enemy
public class EnemySound : MonoBehaviour {
	[SerializeField] int idEnemy;
	[SerializeField] AudioClip hit, run, runAttack, skill1, skill2, hurt, die;

	[SerializeField] AudioSource aSound;

	private float volume;
	// Use this for initialization
	void Start () {
		volume = PlayerPrefs.GetFloat ("SoundEF");

		hit = Resources.Load<AudioClip> ("Sounds/Enemy/Enemy"+idEnemy+"/hit");
		run = Resources.Load<AudioClip> ("Sounds/Enemy/Enemy"+idEnemy+"/run");
		runAttack = Resources.Load<AudioClip> ("Sounds/Enemy/Enemy"+idEnemy+"/runattack");
		skill1 = Resources.Load<AudioClip> ("Sounds/Enemy/Enemy"+idEnemy+"/skill1");
		skill2 = Resources.Load<AudioClip> ("Sounds/Enemy/Enemy"+idEnemy+"/skill2");
		hurt = Resources.Load<AudioClip> ("Sounds/Enemy/Enemy"+idEnemy+"/hurt");
		die = Resources.Load<AudioClip> ("Sounds/Enemy/Enemy"+idEnemy+"/die");

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
			aSound.clip = runAttack;
			aSound.PlayOneShot (runAttack);
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
			aSound.enabled = false;
			aSound.clip = die;
			aSound.enabled = true;
			aSound.PlayOneShot (die);
			break;
		}
	}
}
