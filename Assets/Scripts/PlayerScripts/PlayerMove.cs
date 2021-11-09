using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	[SerializeField] float moveSpeed;

	[SerializeField] bool facingRight = true;
	[SerializeField] bool moving = false;

	[SerializeField] float timeReserveCross;
	[SerializeField] float forceCross;

	[SerializeField] float test;
	[SerializeField] int idPlayer = 1;

	//sound effect
	[SerializeField] AudioSource listSound;

	private Animator anim;
	private Rigidbody2D r2;
	private Transform tran;
	private PlayerState pState;

	private GameObject joyStick;

	private SoundsInGame sound;

	const string animMoving = "Moving";
	const string animGround = "Ground";
	const string animAttacking = "Attacking";
	const string animCross = "Cross";

	const string moveValueHorizontal = "Horizontal";
	const string movePlayer2 = "Player2";

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
		pState = GetComponent<PlayerState> ();

		joyStick = GameObject.FindGameObjectWithTag ("Joystick");

		sound = GameObject.FindGameObjectWithTag ("Sounds").GetComponent<SoundsInGame> ();

		tran = transform;

		moveSpeed = PlayerInfo.playerSpeed;
		//moveSpeed = 30f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		timeReserveCross -= Time.deltaTime;

		//float moveValue = (idPlayer == 1) ? Input.GetAxisRaw (moveValueHorizontal) : Input.GetAxisRaw(movePlayer2);

		// check value of joystick cripts
		//moveWithJoystick();

		moveWithKeyboard ();
		crossForKeyBoard ();


		//test = moveValue;
		anim.SetBool (animMoving, moving);
	}

	public void crossForKeyBoard(){
		//function check to cross
		if (Input.GetKeyDown (KeyCode.H) && timeReserveCross < 0 && pState.getCanMove() && !PlayerInfo.isDead) {
			timeReserveCross = 0.4f;
			int way = facingRight ? 1 : -1;
			//r2.AddForce (new Vector2 (8000*way, 0));
			if (moving) {
				r2.velocity = new Vector2 (r2.velocity.x + 750 * way, r2.velocity.y);
				//tran.position = new Vector3(tran.position.x + 10f, tran.position.y, tran.position.z);
				anim.Play (animCross);
			} else if (!anim.GetBool (animGround)) {
				//r2.velocity = new Vector2 (100f * way, 0f);
				//tran.position.x = tran.position.x + 30*way;
			} else {
				r2.velocity = new Vector2 (r2.velocity.x + forceCross * way, r2.velocity.y);
				anim.Play (animCross);
			}

			sound.playSound (4);

		}
	}

	public void cross(){
		if (timeReserveCross < 0 && pState.getCanMove() && !PlayerInfo.isDead) {
			timeReserveCross = 0.4f;
			int way = facingRight ? 1 : -1;
			//r2.AddForce (new Vector2 (8000*way, 0));
			tran.position = new Vector3(tran.position.x + way*15f, tran.position.y, tran.position.z);
			anim.Play (animCross);

			sound.playSound (4);

		}
	}

	// move with joystick
	public void moveWithJoystick(){
		//float moveValue = (idPlayer == 1) ? Input.GetAxisRaw (moveValueHorizontal) : Input.GetAxisRaw(movePlayer2);
		float moveValue = joyStick.GetComponent<JoyStickPlayer>().InputDirection.x;

		if (moveValue != 0f && pState.getCanMove() && pState.getCanDo() && !PlayerInfo.isDead) {
			bool temp = (moveValue > 0f) ? true : false;
			if (facingRight != temp) {
				facingRight = temp;
				split ();
			}

			if (timeReserveCross < 0.15f) {
				moving = true;
			}
			//r2.AddForce (new Vector2(moveSpeed*test, 0));
			int way = (moveValue>0)?1:-1;
				
			r2.velocity = new Vector2(way * moveSpeed, r2.velocity.y);
			anim.SetBool (animAttacking, false);
			GetComponent<ComboAttack> ().resetCombo ();// reset combo attack when moving

		} else {
			moving = false;
		}
	}

	// move with keybroad
	public void moveWithKeyboard(){
		//float moveValue = (idPlayer == 1) ? Input.GetAxisRaw (moveValueHorizontal) : Input.GetAxisRaw(movePlayer2);
		float moveValue = (idPlayer == 1) ? Input.GetAxisRaw (moveValueHorizontal) : Input.GetAxisRaw (moveValueHorizontal);

		//float moveValue = joyStick.GetComponent<JoyStickPlayer>().InputDirection.x;

		if (moveValue != 0f && pState.getCanMove() && pState.getCanDo() && !PlayerInfo.isDead) {
			bool temp = (moveValue > 0f) ? true : false;
			if (facingRight != temp) {
				facingRight = temp;
				split ();
			}

			if (timeReserveCross < 0.15f) {
				moving = true;
			}
			//r2.AddForce (new Vector2(moveSpeed*test, 0));
			int way = (moveValue>0)?1:-1;

			r2.velocity = new Vector2(way * moveSpeed, r2.velocity.y);
			anim.SetBool (animAttacking, false);
			GetComponent<ComboAttack> ().resetCombo ();// reset combo attack when moving

		} else {
			moving = false;
		}
	}

	public void split()
	{
		//facingRight = !facingRight;
		tran.localScale = new Vector3(tran.localScale.x *-1, tran.localScale.y, tran.localScale.z);
	}

	// Flip player when be Attack
	public void flipAndFacing(bool dir){// dir chi huong cua tan cong: true la tu ben phai, false la bi tan cong tu ben trai
		if ((dir != facingRight && dir)|| (dir != facingRight && !dir)) {
			split ();
			facingRight = dir;
		} 
	}

	public bool getFacingRight(){
		return facingRight;
	}

	public int getFacingFollowInteger(){
		if (facingRight) {
			return 1;
		}
		return -1;
	}

	public bool getMoving(){
		return moving;
	}

}
