using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Lop xu ly va hien thi cac hieu ung load text
public class FloatText : MonoBehaviour {

	[SerializeField] Animator anim;
	[SerializeField] Text damageText;

	void OnEnable(){
		AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo (0);
		Destroy (gameObject, clipInfo [0].clip.length);

		damageText = anim.GetComponent<Text> ();
	}

	public void setText(string text){
		damageText.text = text;
	}
}
