using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// lop xu ly khoi tao cac doi tuong TextPopup
public class FloatTextController : MonoBehaviour {
	private static FloatText[] popuptext = new FloatText[7];
	private static GameObject canvas;

	const string LocalPath = "Prefabs/TextPopup";

	public static void Initialize(){
		canvas = GameObject.Find ("Canvas");
		popuptext[0] = Resources.Load<FloatText> (LocalPath+1);// damage
		popuptext[1] = Resources.Load<FloatText> (LocalPath+2);// Xdamage
		popuptext[2] = Resources.Load<FloatText> (LocalPath+3);// health
		popuptext[3] = Resources.Load<FloatText> (LocalPath+4);// mana
		popuptext[4] = Resources.Load<FloatText> (LocalPath+5);// xp
		popuptext[5] = Resources.Load<FloatText> (LocalPath+6);// beri
		popuptext[6] = Resources.Load<FloatText> (LocalPath+7);// level up
	}

	public static void createFloatingText(int idPopUp, string text, Transform location){
		FloatText instance = Instantiate (popuptext[idPopUp - 1]);
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (new Vector2(location.position.x + Random.Range(-0.5f, 3f), location.position.y + Random.Range(-0.5f, 5f)));
		instance.transform.SetParent (canvas.transform, false);
		instance.transform.position = screenPosition;
		instance.setText (text);
	}

























}
