using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay luu tru cac thong tin cua mot chieu thuc: gia tri knocked
public class KnockedInfo : MonoBehaviour {
	[SerializeField] bool canknocked;
	[SerializeField] float[] knocked = {10,10};

	public float[] getKnockedSkill(){
		return knocked;
	}

	public bool getCanKnocked(){
		return canknocked;
	}
}
