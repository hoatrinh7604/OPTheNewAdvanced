using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ham nay chua cac thong so cho chuyen dong cua enemy
public class EnemyMove : MonoBehaviour {
	[SerializeField] int idEnemy;

	[SerializeField] bool isBoss;
		
	[SerializeField] int facingLeft;
	[SerializeField] bool grounded;
	[SerializeField] bool canFlip;

	[SerializeField] int speedWalk;
	[SerializeField] int speedRun;

	private int currentSpeed;
	private  bool canAttack;
	private  bool canSkill;

	[SerializeField] float currentDistance;
	[SerializeField] float distanceCanMove;

	[SerializeField] float distanceFoundPlayer;
	[SerializeField] float distanceToWalk;
	[SerializeField] float distanceToSkill;
	[SerializeField] float distanceToAttack;

	[SerializeField] float forceRunAttack;

	[SerializeField] Transform target;

	private Rigidbody2D r2;
	private Transform tran;
	private Animator anim;
	private EnemyState eState;

	[SerializeField] Image healthBar;
	[SerializeField] Image manaBar;
	[SerializeField] GameObject levelBar;

	[SerializeField] float groundRadius = 0.2f;
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask whatIsGround;

	private float distanceTemp;
	private int directionMove;
	private bool canRunAttack;
	[SerializeField] float setTimeToRunAttackAgain;
	private float timeToRunAttackAgain;
	[SerializeField] bool canWalk;

	private EnemySound sound;

	private const string animSpeed = "Speed";
	private const string animGround = "Ground";
	private const string animFrozenEnemy = "FrozenEnemy";
	private const string animCanRunAttack = "CanRunAttack";

	private const string animRunAttackClip = "RunAttack";

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		r2 = GetComponent<Rigidbody2D> ();
		tran = GetComponent<Transform> ();
		anim = GetComponent<Animator> ();
		eState = GetComponent<EnemyState> ();

		sound = GetComponentInChildren<EnemySound> ();

		facingLeft = -1;
		canWalk = true;
		timeToRunAttackAgain = -1f;

		anim.SetFloat (animFrozenEnemy, -1f);
		//canAttack = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Tinh khoang cach tu enemy den target (Player)
		currentDistance = tran.position.x - target.position.x;

		// Lay gia tri tuyet doi cua khoang cach
		distanceTemp = Mathf.Abs (currentDistance);
		//distanceCanMove = distanceTemp;

		if (anim.GetFloat (animFrozenEnemy) < 0f && eState.getCanDo() && !eState.getIsDead() && !PauseSystem.isPause) {
			if (distanceTemp < (distanceToAttack + 3f) && currentSpeed != speedRun) {// Neu trong khoang tan cong
				if (!canWalk && distanceTemp > (distanceToAttack - 3f)) {// Enemy se dung yen trong 1 khoang thoi gian bien canWalk set lai ve true
					canWalk = false;

					currentSpeed = 0;
					anim.SetInteger (animSpeed, currentSpeed);

					facingToPlayer ();
					setDirectionMove ();
					StartCoroutine (waitEndTimeCanWalk (2f));

					//Debug.Log (1);
				} else { // Enemy di chuyen theo huong chi dinh ma khong phu thuoc vao Player (di chuyen xung quanh)
					//setWalk ();
					if (timeToRunAttackAgain < 0 && distanceTemp > distanceToAttack) {
						runToPlayer ();
						runAttack ();
					} else {
						setWalk ();
					}

				}

			} else if (distanceTemp < distanceToWalk && currentSpeed != speedRun) {
				// Khoang cach Enemy di bo den player 
				currentSpeed = speedWalk;

				anim.SetInteger (animSpeed, currentSpeed);

				setDirectionMove ();
				facingToPlayer ();
				r2.AddForce (new Vector2 (directionMove * currentSpeed, 0));
				//Debug.Log (3);

			} else if (distanceTemp < distanceFoundPlayer) {
				// Khoang cach Enemy chay duoi theo Player
				if (distanceTemp < distanceToAttack) {
					runAttack ();
					//Debug.Log (3.5f);
				} else {
					runToPlayer ();
					//Debug.Log (4);
				}

			} else { // Neu khong trong cac truong hop tren thi set dung yen
				canAttack = false;
				currentSpeed = 0;
				anim.SetInteger (animSpeed, currentSpeed);

				//Debug.Log (5);

			}


			if (distanceTemp < distanceToAttack && currentSpeed != speedRun) {// or current == 0
				if (isPositiveWithPlayer () && distanceTemp > 3 && currentSpeed == 0) {
					canAttack = true;
				} else if (isPositiveWithPlayer () && distanceTemp > 1 && currentSpeed == speedWalk) {
					canAttack = true;
				} else {
					canAttack = false;
				}
			} else {
				canAttack = false;
			}
		}

		// Set can Attack or skill for enemy
		if (isBoss && distanceTemp < distanceToSkill && isPositiveWithPlayer () && distanceTemp > 5) {// Khoang cach co the dung Skill
			canSkill = true;
		} else {
			canSkill = false;
		}
			
		//tran.position.x = Vector2.MoveTowards(tran.position, target.position, currentSpeed * Time.deltaTime);

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool (animGround, grounded);


		// Tao ma sat
		r2.velocity = new Vector2 (r2.velocity.x * 0.7f, r2.velocity.y);
	}

	// Run to Player
	void runToPlayer(){
		canWalk = false;

		setDirectionMove ();
		facingToPlayer ();

		currentSpeed = speedRun;
		anim.SetInteger (animSpeed, currentSpeed);

		r2.AddForce (new Vector2 (directionMove * currentSpeed, 0));

		sound.playSound (2);
	}

	void runAttack(){
		// check run Attack
		if (timeToRunAttackAgain < 0f) {
			if (distanceTemp < distanceToAttack) {
				//Debug.Log ("Run Attack");
				//anim.SetBool (animCanRunAttack, true);
				float time = getTimeOfAnimation (animRunAttackClip);
				anim.Play(animRunAttackClip);

				//sound.playSound (1);

				r2.AddForce (new Vector2 (forceRunAttack* directionMove, 0));
				anim.SetFloat (animFrozenEnemy, time);
				timeToRunAttackAgain = setTimeToRunAttackAgain;
				StartCoroutine (waitForCanRunAttack (timeToRunAttackAgain));
				StartCoroutine (waitEndTimeRunAttack (time));
			} 
		} else {
			setWalk ();
		}
	}

	void setWalk(){
		canWalk = true;

		currentSpeed = speedWalk;
		anim.SetInteger (animSpeed, currentSpeed);

		facingToPlayer ();
		r2.AddForce (new Vector2 (directionMove * currentSpeed, 0));
		StartCoroutine (waitEndTimeCantWalk (6f));

		//Debug.Log (2);
	}

	public void setIdle(){
		canWalk = false;
		currentSpeed = 0;
		anim.SetInteger (animSpeed, currentSpeed);

		facingToPlayer ();
		StartCoroutine (waitEndTimeCanWalk (1f));
	}

	// get facing
	public int getFacing(){
		return facingLeft;
	}

	// lat doi tuong
	public void flip(){
		tran.localScale = new Vector3 (tran.localScale.x * -1, tran.localScale.y, tran.localScale.z);
		facingLeft = -facingLeft;
		setDirectionMove ();

		healthBar.transform.localScale = new Vector3 (tran.localScale.x, tran.localScale.y, tran.localScale.z);
		manaBar.transform.localScale = new Vector3 (tran.localScale.x, tran.localScale.y, tran.localScale.z);
		if (tran.localScale.x * levelBar.transform.localScale.x < 0) {
			levelBar.transform.localScale = new Vector3 (-levelBar.transform.localScale.x, levelBar.transform.localScale.y, levelBar.transform.localScale.z);
		}
	}

	public void flipToRight(){
		if (facingLeft == -1) {
			flip ();
		}
	}

	public void flipToLeft(){
		if (facingLeft == 1) {
			flip ();
		}
	}

	// Lat doi tuong theo huong Player
	public void facingToPlayer(){
		if (directionMove == -1 && facingLeft == 1) {
			flip ();
		} else if (directionMove == 1 && facingLeft == -1) {
			flip ();
		}
	}

	public void setFacingToPlayer(float pos){
		// dao nguoc lai khi dung tempPos o ham trong EnemyState
		if (pos > 0 && facingLeft == -1) {
			flip ();
		} else if (pos < 0 && facingLeft == 1) {
			flip ();
		}
	}

	// Kiem tra co nhin ve phia Player
	public bool isPositiveWithPlayer(){
		if (currentDistance > 0 && facingLeft == -1) {
			return true;
		} else if (currentDistance < 0 && facingLeft == 1) {
			return true;
		} else {
			return false;
		}
	}

	// Set huong cua di chuyen
	void setDirectionMove(){
		if (currentDistance > 0) {
			directionMove = -1;
		} else {
			directionMove = 1;
		}
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

	// * Cac ham dem thoi gian

	IEnumerator waitForCanRunAttack(float time){
		yield return new WaitForSeconds (time);
		timeToRunAttackAgain = -1f;
	}

	IEnumerator waitEndTimeRunAttack(float time){
		yield return new WaitForSeconds (time);
		anim.SetBool (animCanRunAttack, false);
		anim.SetFloat (animFrozenEnemy, -1f);
		currentSpeed = 0;
	}

	IEnumerator waitEndTimeCanWalk(float time){
		yield return new WaitForSeconds (time);
		canWalk = true;
	}

	IEnumerator waitEndTimeCantWalk(float time){
		yield return new WaitForSeconds (time);
		canWalk = false;
	}






	// get function
	public Transform getTarget(){
		return target;
	}

	public bool getCanAttack(){
		return canAttack;
	}

	public bool getCanSkill(){
		return canSkill;
	}

	public int getCurrentSpeed(){
		return currentSpeed;
	}

	public int getDirectionMove(){
		return directionMove;
	}

	public Image getImageMana(){
		return manaBar;
	}

	public Image getImageHealth(){
		return healthBar;
	}
}
