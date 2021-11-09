using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop nay xu ly ve tancong bang ky nang cua nguoi choi
public class ComboSkill : MonoBehaviour {

	[SerializeField] float timeReserverSkill1;
	[SerializeField] float timeReserverSkill2;
	[SerializeField] float[] forceSkillX = {0, 0};
	[SerializeField] float[] forceSkillY = {0, 0};
	[SerializeField] float[] manaForSkill = { 0, 0 };
	//private static int statePlayer;
	private static float frozenPlayer;

	[SerializeField] int test;

	private Animator anim; 
	private Rigidbody2D r2;
	private PlayerState pState;
	private PlayerMove pMove;
	private LoadIconByCharacter loadDelaySkill;

	private const string animAttacking = "Attacking";
	private const string animSkill1 = "Skill1";
	private const string animSkill2 = "Skill2";
	private const string animGround = "Ground";

	[SerializeField] GameObject[] skillEffect;
	[SerializeField] float[] timeDelaySkillEffect;
	[SerializeField] Vector2 posSkill;
	private GameObject gSkill;

	[SerializeField] GameObject skillBG;
	[SerializeField] Animator animLoadSkill;
	private const string animLoadSkillPanel = "LoadSkillPanel";

	private CharacterSound sound;

	// Use this for initialization
	void Start () {
		pState = GetComponent<PlayerState> ();
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
		pMove = GetComponent<PlayerMove> ();
		loadDelaySkill = GameObject.Find("BotRightPanel").GetComponent<LoadIconByCharacter>();

		sound = GetComponentInChildren<CharacterSound> ();

		skillBG.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		timeReserverSkill1 -= Time.deltaTime;
		timeReserverSkill2 -= Time.deltaTime;

		//skillForKeyBoard ();


		if (Input.GetKeyDown (KeyCode.K)) {
			loadDelaySkill.skill1 ();
		}

		if (Input.GetKeyDown (KeyCode.L)) {
			loadDelaySkill.skill2 ();
		}


	}

	//for windown
	public void skillForKeyBoard(){
		if (Input.GetKeyDown (KeyCode.K) && timeReserverSkill1 < 0f && (pState.getFrozenPlayer() < 0) && pState.getCanDo() && anim.GetBool(animGround)) {
			if (PlayerInfo.playerEnergy < manaForSkill [0]) {

			} else {
				StartCoroutine (waitEndPause (0.3f, 1));

				setRunSkillEffect (1);

				timeReserverSkill1 = 2f;
				float time = getTimeOfAnimation (animSkill1);
				anim.Play (animSkill1);
				setForceSkill (1);
				GetComponent<ComboAttack> ().resetCombo ();
				GetComponent<PlayerState> ().setFrozenPlayer (time);
				//Debug.Log ("Time Skill1 = " + time);
				//Debug.Log ("Frozen Skill 1 = "+ PlayerState.frozenPlayer);
				anim.SetBool (animAttacking, true);

				StartCoroutine (waitEndAnim (time));

				PlayerInfo.playerEnergy -= (int)manaForSkill [0];
			}
		}

		if (Input.GetKeyDown (KeyCode.L) && timeReserverSkill2 < 0f && (pState.getFrozenPlayer() < 0) && anim.GetBool(animGround)) {
			if (PlayerInfo.playerEnergy < manaForSkill [1]) {

			} else {
				StartCoroutine (waitEndPause (0.3f, 2));

				setRunSkillEffect (2);

				timeReserverSkill2 = 4f;
				float time = getTimeOfAnimation (animSkill2);

				anim.Play (animSkill2);
				setForceSkill (2);
				GetComponent<ComboAttack> ().resetCombo ();
				GetComponent<PlayerState> ().setFrozenPlayer (time);
				//Debug.Log ("Time Skill2 = " + time);
				//Debug.Log ("Frozen Skill 2 = "+ PlayerState.frozenPlayer);
				anim.SetBool (animAttacking, true);

				// Tinh thoi gian chay het Skill animation va xu ly bien Attacking
				StartCoroutine (waitEndAnim (time));

				PlayerInfo.playerEnergy -= (int)manaForSkill [1];
			}
		}
	}

	// For button UI
	public float skill1(){
		if (timeReserverSkill1 < 0f && (pState.getFrozenPlayer() < 0) && pState.getCanDo() && anim.GetBool(animGround)) {
			if (PlayerInfo.playerEnergy < manaForSkill [0]) {
				return 0;
			} else {
				StartCoroutine (waitEndPause (0.3f, 1));

				setRunSkillEffect (1);

				timeReserverSkill1 = 2f;
				float time = getTimeOfAnimation (animSkill1);
				anim.Play (animSkill1);
				setForceSkill (1);
				GetComponent<ComboAttack> ().resetCombo ();
				GetComponent<PlayerState> ().setFrozenPlayer (time);
				//Debug.Log ("Time Skill1 = " + time);
				//Debug.Log ("Frozen Skill 1 = "+ PlayerState.frozenPlayer);
				anim.SetBool (animAttacking, true);

				StartCoroutine (waitEndAnim (time));

				PlayerInfo.playerEnergy -= (int)manaForSkill [0];

				return timeReserverSkill1;
			}
		}

		return 0;
	}

	public float skill2(){
		if (timeReserverSkill2 < 0f && (pState.getFrozenPlayer() < 0) && anim.GetBool(animGround)) {
			if (PlayerInfo.playerEnergy < manaForSkill [1]) {
				return 0;
			} else {
				StartCoroutine (waitEndPause (0.3f, 2));

				setRunSkillEffect (2);

				timeReserverSkill2 = 4f;
				float time = getTimeOfAnimation (animSkill2);

				anim.Play (animSkill2);
				setForceSkill (2);
				GetComponent<ComboAttack> ().resetCombo ();
				GetComponent<PlayerState> ().setFrozenPlayer (time);
				//Debug.Log ("Time Skill2 = " + time);
				//Debug.Log ("Frozen Skill 2 = "+ PlayerState.frozenPlayer);
				anim.SetBool (animAttacking, true);

				// Tinh thoi gian chay het Skill animation va xu ly bien Attacking
				StartCoroutine (waitEndAnim (time));

				PlayerInfo.playerEnergy -= (int)manaForSkill [1];

				return timeReserverSkill2;
			}
		}
		return 0;
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

	//Check player is attacking with skill
	public bool isSkilling(){
		if (timeReserverSkill1 > 0 || timeReserverSkill2 > 0) {
			return true;
		}
		return false;
	}

	void setForceSkill(int idSkill){
		// check direction of face player when load facingRight value in PlayerMove class (it and this class in the same Object)
		int way = (gameObject.GetComponent<PlayerMove> ().getFacingRight ())?1:-1;
		r2.AddForce (new Vector2 ((forceSkillX[idSkill-1])* way, forceSkillY[idSkill-1]));
	}


	// Set lai bien Attacking ve false sau khi chay het animation skill
	IEnumerator waitEndAnim(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		anim.SetBool (animAttacking, false);
	}

	IEnumerator waitEndPause(float time, int idSkill){
		if (pState.getFrozenPlayer () < 0) {
			sound.playSound (7 + idSkill);
			skillBG.SetActive (true);
			animLoadSkill.Play (animLoadSkillPanel);
			//PauseSystem.isPause = true;
			Time.timeScale = 0.35f;
		}
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		skillBG.SetActive (false);
		PauseSystem.resumeGame ();
	}
		
	IEnumerator waitToCreateOb(float time, int idSkill){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		if (pState.getCanDo ()) {
			posSkill = new Vector2 (transform.position.x, transform.position.y);
			if (pMove.getFacingRight ()) {
				sound.playSound (idSkill + 3);
				gSkill = Instantiate (skillEffect [idSkill - 1], posSkill, Quaternion.identity) as GameObject;
				gSkill.GetComponent<SkillController> ().setVerX (1);
				gSkill.GetComponent<SkillController> ().setCanRun (true);
			} else {
				sound.playSound (idSkill + 3);
				gSkill = Instantiate (skillEffect [idSkill - 1], posSkill, Quaternion.identity) as GameObject;
				gSkill.GetComponent<SkillController> ().setVerX (-1);
				gSkill.GetComponent<SkillController> ().setCanRun (true);
			}
		}
	}
}
