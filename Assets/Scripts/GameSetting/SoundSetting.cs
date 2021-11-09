using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lop nay xu ly am luong trong game
public class SoundSetting : MonoBehaviour {
	
	[SerializeField] Slider bgSoundBar;
	[SerializeField] Slider soundEffectBar;


	// Use this for initialization
	void Start () {
		bgSoundBar.maxValue = 1f;
		soundEffectBar.maxValue = 1f;

		bgSoundBar.value = PlayerPrefs.GetFloat ("SoundBG");
		soundEffectBar.value = PlayerPrefs.GetFloat ("SoundEF");
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat ("SoundBG", bgSoundBar.value);
		PlayerPrefs.SetFloat ("SoundEF", soundEffectBar.value);

		//Debug.Log ("Current volume: "+ PlayerPrefs.GetFloat ("SoundBG"));
	}

}
