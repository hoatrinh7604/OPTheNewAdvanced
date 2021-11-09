using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lop xu ly cac trang thai cua nhan vat khi bi Enemy tan cong
public class PlayerState : MonoBehaviour {

	//[SerializeField] float forcePow = 100f;
	//[SerializeField] float forcePow2 = 200f;
	//[SerializeField] float forceHurt = 100f;

	[SerializeField] bool isDead = false;

	[SerializeField] float timeToCanChange;

	[SerializeField] float currentHealth;
	[SerializeField] float maxHealth;

	// player can't control if this value > 0
	private float frozenPlayer;
	private float timeCanDo;

	private Animator anim;
	private Rigidbody2D r2;
	private PlayerMove pMove;
	private Transform tran;

	[SerializeField] GameObject dmgPartical;
	[SerializeField] Transform posEffect;

	[SerializeField] GameObject gameOverPanel;

	private CharacterSound sound;
	private BgSounds soundBG;

	//state of player: 0 = idel; 1 = hurt; 2 = knockdown; 3 = stand up; 4 = Skilling 
	// State: 0 = standUp; 1 = JA; 2 = Hurt; 3 = Knock; 4 = Skill; 5 = Attack; 6 = Jump; 7 = Move; 8 = Idel 
	// 10 = Dead
	private int statePlayer = 8;
	private bool canChangeState = true;

	const string animHurt = "Hurt";
	const string animKnocked = "Knocked";
	const string animGround = "Ground";
	const string animFrozenPlayer = "FrozenPlayer";
	const string animStandUp = "StandUp";
	const string animKnockedDown = "KnockedDown";
	const string animDead = "Dead";

	void Awake(){
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
		pMove = GetComponent<PlayerMove> ();
		tran = GetComponent<Transform> ();
		sound = GetComponentInChildren<CharacterSound> ();
		soundBG = GameObject.FindGameObjectWithTag ("Sounds").GetComponentInChildren<BgSounds> ();

		gameOverPanel = GameObject.FindGameObjectWithTag ("GameOver");
		gameOverPanel.SetActive (false);

		// set bar health follow player
		//pStat.setValueBar (maxHealth, maxHealth);
		//currentHealth = maxHealth;
	}

	// Use this for initialization
	void Update () {
		timeCanDo -= Time.deltaTime;

		if (PlayerInfo.playerHealth <= 0 && !PlayerInfo.isDead) {
			beDead ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (frozenPlayer < 0) {
			if (statePlayer == 2) {
				statePlayer = 8;
			} else if (statePlayer == 0) {
				statePlayer = 8;
			} else if(statePlayer == 3 && anim.GetBool (animGround)) {
				frozenPlayer = getTimeOfAnimation (animStandUp);
				statePlayer = 0;
				StartCoroutine (waitToCanChangeState (timeToCanChange));
			}

			anim.SetBool (animHurt, false);
			anim.SetBool (animKnocked, false);
		}

		anim.SetFloat (animFrozenPlayer, frozenPlayer);
		frozenPlayer -= Time.deltaTime;
			
	}

	// if player is attacked => call this function
	public void beHurt(float x, float posX, int dmg){//x la luc day, posX la vi tri nguon tac dong
		Destroy(Instantiate (dmgPartical, posEffect), 0.5f);

		anim.SetFloat (animFrozenPlayer, 0.2f);
		ManagerController.outWar = 5f;

		if (!PlayerInfo.isDead) {
			if (anim.GetBool (animGround)) {
				if (posX - tran.position.x > 0) {
					pMove.flipAndFacing (true);
					//anim.SetBool (animHurt, true);
					anim.Play (animHurt);

					//anim.SetBool (animKnocked, false);
					frozenPlayer = getTimeOfAnimation (animHurt);
					timeCanDo = frozenPlayer;
					//Debug.Log ("Hurt =" +frozenPlayer);
					statePlayer = 2;
					r2.AddForce (new Vector2 (-x, 0));
				} else {
					pMove.flipAndFacing (false);
					//anim.SetBool (animHurt, true);
					anim.Play (animHurt);
					//anim.SetBool (animKnocked, false);
					frozenPlayer = getTimeOfAnimation (animHurt);
					timeCanDo = frozenPlayer;
					//Debug.Log ("Hurt =" +frozenPlayer);
					statePlayer = 2;
					r2.AddForce (new Vector2 (x, 0));
				}


			} else {
				float[] temp = { x, 0 };
				beKnockedDown (temp, posX, dmg);
			}

			float newdmg = setArmor (dmg);
			PlayerInfo.playerHealth -= (newdmg>0)?newdmg:1;
			if (PlayerInfo.playerHealth <= 0) {
				beDead ();
			}

		}
		//pStat.CurrentValue = currentHealth -= dmg;

	}

	// if player is knocked down => call function
	public void beKnockedDown(float[] knocked, float posX, int dmg){
		Destroy(Instantiate (dmgPartical, posEffect), 0.5f);

		anim.SetFloat (animFrozenPlayer, 0.3f);
		statePlayer = 3;
		ManagerController.outWar = 5f;

		if (!PlayerInfo.isDead) {
			if (posX - tran.position.x > 0) {
				pMove.flipAndFacing (true);
				//anim.SetBool (animKnocked, true);
				anim.Play (animKnockedDown);
				//anim.SetBool (animHurt, false);
				frozenPlayer = getTimeOfAnimation (animKnockedDown);
				timeCanDo = frozenPlayer;
				//Debug.Log ("KnockedDown =" + frozenPlayer);
				statePlayer = 3;
				r2.AddForce (new Vector2 (-knocked [0], knocked [1]));

				canChangeState = false;
			} else {
				pMove.flipAndFacing (false);
				//anim.SetBool (animKnocked, true);
				anim.Play (animKnockedDown);
				//anim.SetBool (animHurt, false);
				frozenPlayer = getTimeOfAnimation (animKnockedDown);
				timeCanDo = frozenPlayer;
				//Debug.Log ("KnockedDown =" + frozenPlayer);
				statePlayer = 3;
				r2.AddForce (new Vector2 (knocked [0], knocked [1]));

				canChangeState = false;
			}

			sound.playSound (6);
			float newdmg = setArmor (dmg);
			PlayerInfo.playerHealth -= (newdmg>0)?newdmg:1;
			if (PlayerInfo.playerHealth <= 0) {
				beDead ();
			}
		}
		//pStat.CurrentValue = currentHealth -= dmg; 
	}
		
	// if player dead => call function
	void beDead(){
		if (!isDead) {
			statePlayer = 10;
			frozenPlayer = 3600;
			isDead = true;
			PlayerInfo.isDead = true;
			anim.Play ("Dead");
			anim.SetBool (animDead, true);

			sound.playSound (7);

			StartCoroutine(waitToGameOver (1.5f));
		}
	}

	public float setArmor(float dmg){
		float percent = GameInfo.Armor / (GameInfo.Level * 5) * 100;// Mac dinh eney la 1/5 = 20%

		float randomValue = Random.Range (1, percent);
		dmg -= randomValue * dmg / 100; // giam dmg bang chinh luong ti le giam dam toi da cua armr

		return dmg;
	}


	// set state
	public void setState(int state){
		statePlayer = state;
	}

	// set frozenPlayer
	public void setFrozenPlayer(float frozen){
		frozenPlayer = frozen;
	}

	//get state
	public int getStatePlayer(){
		return statePlayer;
	}

	public float getFrozenPlayer(){
		return frozenPlayer;
	}

	// get time of a animation by name
	float getTimeOfAnimation(string nameOfAnim){
		float time = 0;
		RuntimeAnimatorController ac = anim.runtimeAnimatorController;   

		for (int i = 0; i < ac.animationClips.Length; i++)
			if (ac.animationClips[i].name == nameOfAnim)
				time = ac.animationClips[i].length;

		return time;
	}

	public bool getCanMove(){
		if (frozenPlayer < 0 && canChangeState) {
			return true;
		} else {
			return false;
		}
	}

	public bool getCanDo(){
		if (timeCanDo< 0) {
			return true;
		} else {
			return false;
		}
	}

	IEnumerator waitToCanChangeState(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		canChangeState = true;
	}

	IEnumerator waitToGameOver(float time){
		// sau khi chay endCombo() thi set thoi gian ket thuc cua anim do (tru 0.5f uoc luong do tre cua game)
		yield return new WaitForSeconds (time);
		SaveAndLoadManager.saveCharacter (GameInfo.getBaseClass(), GameInfo.Id);
		gameOverPanel.SetActive (true);
		soundBG.playSound (4);// game over
	}

}
