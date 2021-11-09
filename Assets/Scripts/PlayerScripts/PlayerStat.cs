using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lop xu ly gia tri cua cac thanh Slider trong game
public class PlayerStat : MonoBehaviour {

	private Image content;

	[SerializeField] float loadSpeed;

	private float currentFill;
	public float MaxValue { get; set;}

	private float currentValue;

	public float CurrentValue{
		get{ return currentValue;}
		set{ 
			if (value > MaxValue) {
				currentValue = MaxValue;
			} else if (value < 0) {
				currentValue = 0;
			} else {
				currentValue = value;
			}

			currentFill = currentValue / MaxValue;
		}
	}

	// Use this for initialization
	void Start () {
		content = GetComponent<Image> ();
		//content.fillAmount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (currentValue);
		if (currentFill != content.fillAmount) {
			content.fillAmount = Mathf.Lerp (content.fillAmount, currentFill, Time.deltaTime * loadSpeed);
		}
	}

	public void setValueBar(float curValue, float maxValue){
		MaxValue = maxValue;
		CurrentValue = curValue;
	}
}
