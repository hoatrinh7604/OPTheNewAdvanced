using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class nay chua cac thong tin lien quan den tan cong cua Enemy
public class EnemyAttack : MonoBehaviour {

	[SerializeField] int numAttack;// So don tan cong toi da
	[SerializeField] int currentAttack;// Don tan cong hien tai
	public static bool isAttacking;// Co dang tan cong
	[SerializeField] float delayAttack; // Thoi gian de tan cong lai
	[SerializeField] float currentTimeToAttack; // Thoi gian con lai de co the tan cong tiep
	[SerializeField] float[] forceAttack;

	private bool canNextCombo; // Co the tan cong don tiep theo

	// Luu tru cac chuoi de dung lai nhieu lan
	private const string animFrozenPlayer = "FrozenEnemy";
	private const string attackText = "Attack";

	private Animator anim;
	private Rigidbody2D r2;
	private EnemyMove eMove;
	private EnemyState eState;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
		eMove = GetComponent<EnemyMove> ();
		eState = GetComponent<EnemyState> ();

		currentAttack = 1;
		currentTimeToAttack = -1f;
		canNextCombo = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Neu trong khoang tan cong va thoi gian hoi cua cac don tan cong
		if (eMove.getCanAttack() && eState.getCanDo() && (eState.getNumOfBeHurt()> eState.getNumCanAttack() || currentTimeToAttack < 0 && anim.GetFloat(animFrozenPlayer) < 0f )) {
			if (canNextCombo && !eState.getIsDead() && !PauseSystem.isPause) {
				setAttack (currentAttack);
			}
		}
			
	}

	// Ham tinh toan cac thong so khi tan cong theo id doan tan cong
	void setAttack(int idAttack){
		float time = getTimeOfAnimation (attackText + idAttack);
		canNextCombo = false;

		anim.SetFloat (animFrozenPlayer, time);

		//Debug.Log (attackText + currentAttack);
		anim.Play (attackText + idAttack);

		StartCoroutine (waitEndAnimation (time));
		r2.AddForce (new Vector2 ((forceAttack[idAttack-1])* eMove.getDirectionMove(), 0));

		eState.resetNumOfBeHurt ();
	}

	public void resetAttack(){
		currentTimeToAttack = -1f;
	}

	// Get time of animation by name
	float getTimeOfAnimation(string nameOfAnim){
		float time = 0;
		RuntimeAnimatorController ac = anim.runtimeAnimatorController;   

		for (int i = 0; i < ac.animationClips.Length; i++)
			if (ac.animationClips[i].name == nameOfAnim)
				time = ac.animationClips[i].length;

		return time;
	}

	IEnumerator waitEndAnimation(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		currentAttack++;

		anim.SetFloat (animFrozenPlayer, -1f);

		canNextCombo = true;
		if (currentAttack > numAttack) {
			currentAttack = 1;
			currentTimeToAttack = delayAttack;
			StartCoroutine (waitTimeCanAttackAgain (delayAttack));
		}
	}

	IEnumerator waitTimeCanAttackAgain(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		currentTimeToAttack = -1f;
	}
}
