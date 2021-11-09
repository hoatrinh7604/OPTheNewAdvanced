using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// lop nay chua xu ly cac dieu kien ve ky nang cua Enemy trung binh
public class EnemySkill : MonoBehaviour {

	[SerializeField] int numSkill;// So don tan cong toi da
	[SerializeField] int currentSkill;// Don tan cong hien tai
	[SerializeField] float[] delaySkill; // Thoi gian hoi chieu cua skill
	[SerializeField] float[] currentTimeToSkill; // Thoi gian con lai de co the tan cong tiep

	[SerializeField] float[] forceSkillX; // luc day theo truc X
	[SerializeField] float[] forceSkillY; // luc day theo truc Y

	[SerializeField] float manaToSkill;
	[SerializeField] float setTimeCanUseSkill;
	private bool canUseSkill; // Co the tan cong don tiep theo
	[SerializeField] float percentHpToAngry;
	private bool isAngry;
	private Color colorHealth;
	private Color colorMana;

	// Luu tru cac chuoi de dung lai nhieu lan
	private const string animFrozenPlayer = "FrozenEnemy";
	private const string skillText = "Skill";

	private Animator anim;
	private Rigidbody2D r2;
	private EnemyMove eMove;
	private EnemyState eState;
	private EnemyInfo eInfo;

	[SerializeField] GameObject[] skillEffect;
	[SerializeField] float[] timeDelaySkillEffect;
	[SerializeField] Vector2 posSkill;
	private GameObject gSkill;

	private EnemySound sound;

	[SerializeField] GameObject dangerous;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
		eMove = GetComponent<EnemyMove> ();
		eState = GetComponent<EnemyState> ();
		eInfo = GetComponent<EnemyInfo> ();

		sound = GetComponentInChildren<EnemySound> ();

		currentSkill = 1;

		//delaySkill = setDelaySkill ();
		//currentTimeToSkill = setCurrentTimeToSkill();
		canUseSkill = true;

		StartCoroutine (waitTimeCanSkillAgain (delaySkill[0], 1));
		//anim.SetFloat (animFrozenPlayer, frozenEnemySkill);

		dangerous.SetActive (false);
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (eState.getIsDead ()) {
			dangerous.SetActive (false);
		}

		if (!isAngry && eState.currentHealth < eInfo.maxHealth * percentHpToAngry) {
			setAngryEnemy ();
		}else if(isAngry){
			setNormalEnemy();
		}

		//Debug.Log ("isSkill: " + eMove.getCanSkill ());
		// Neu trong khoang tan cong va thoi gian hoi cua cac don tan cong
		if (eMove.getCanSkill() && (eState.getNumOfBeHurt()> eState.getNumCanAttack() || anim.GetFloat(animFrozenPlayer) < 0f) && eState.getCanDo() && !PauseSystem.isPause && !PlayerInfo.isDead) {
			if(currentTimeToSkill[0] < 0f){
				if (canUseSkill && (isAngry || eState.currentMana > manaToSkill) && !eState.getIsDead()) {
					StartCoroutine (waitAfterDangerous (1f, 1));
					currentTimeToSkill [0] = delaySkill [0];
				}
			}
		}
	}

	// Ham tinh toan cac thong so khi tan cong theo id doan tan cong
	void setSkill(int idSkill){
		setRunSkillEffect (idSkill);

		float time = getTimeOfAnimation (skillText + idSkill);
		canUseSkill = false;

		anim.SetFloat (animFrozenPlayer, time);

		currentTimeToSkill [idSkill-1] = delaySkill [idSkill-1];

		//Debug.Log (skillText + currentSkill);
		anim.Play (skillText + idSkill);

		StartCoroutine (waitEndAnimation (time));
		StartCoroutine (waitTimeCanSkillAgain (delaySkill [idSkill - 1], idSkill));
		StartCoroutine (waitTimeEnemyCanUseSkill (setTimeCanUseSkill));

		r2.AddForce (new Vector2 ((forceSkillX[idSkill-1])* eMove.getDirectionMove(), forceSkillY[idSkill-1]));

		eState.resetNumOfBeHurt ();
	}

	float[] setDelaySkill(){
		float[] temp = new float[numSkill];

		for (int i = 0; i < numSkill; i++) {
			temp [i] = 10f;
		}
		return temp;
	}

	float[] setCurrentTimeToSkill(){
		float[] temp = new float[numSkill];

		for (int i = 0; i < numSkill; i++) {
			temp [i] = -1f;
		}
		return temp;
	}

	// Ham thay doi cac thong so khi Enemy gan het mau (gian du)
	public void setAngryEnemy(){
		colorHealth = eMove.getImageHealth ().color;
		colorMana = eMove.getImageMana ().color;

		GetComponentInChildren<EnemyMove> ().getImageMana ().color = Color.red;
		GetComponentInChildren<EnemyMove> ().getImageHealth ().color = Color.black;

		delaySkill [0] *= 0.8f;
		isAngry = true;
	}

	public void setNormalEnemy(){
		GetComponentInChildren<EnemyMove> ().getImageMana ().color = colorHealth;
		GetComponentInChildren<EnemyMove> ().getImageHealth ().color = colorMana;

		delaySkill [0] *= 1.25f;
		isAngry = false;
	}



	// set for instantiate skilleffect
	public void setRunSkillEffect(int idSkill){
		StartCoroutine (waitToCreateOb (timeDelaySkillEffect[idSkill-1], idSkill));
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
		anim.SetFloat (animFrozenPlayer, -1f);

	}

	// for after dangerous
	IEnumerator waitAfterDangerous(float time, int idSkill){
		dangerous.SetActive (true);

		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);

		currentSkill = idSkill;
		setSkill (currentSkill);

		eState.currentMana -= manaToSkill;

	}

	IEnumerator waitTimeEnemyCanUseSkill(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		canUseSkill = true;
	}

	IEnumerator waitTimeCanSkillAgain(float time, int idSkill){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		currentTimeToSkill[idSkill-1] = -1f;
	}

	IEnumerator waitToCreateOb(float time, int idSkill){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		dangerous.SetActive (false);

		if (!eState.getIsDead ()) {
			posSkill = new Vector2 (transform.position.x, transform.position.y);
			if (eMove.getFacing () > 0) {
				gSkill = Instantiate (skillEffect [idSkill - 1], posSkill, Quaternion.identity) as GameObject;
				SkillController newSkill = gSkill.GetComponent<SkillController> ();
				newSkill.thisEnemySkilling = gameObject;
				newSkill.setVerX (1);
				newSkill.setCanRun (true);

				sound.playSound (idSkill + 3);
			} else {
				gSkill = Instantiate (skillEffect [idSkill - 1], posSkill, Quaternion.identity) as GameObject;
				SkillController newSkill = gSkill.GetComponent<SkillController> ();
				newSkill.thisEnemySkilling = gameObject;
				newSkill.setVerX (-1);
				newSkill.setCanRun (true);

				sound.playSound (idSkill + 3);
			}
		}
	}
}
