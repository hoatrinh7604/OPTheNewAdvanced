using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

	[SerializeField] bool grounded = false;

	[SerializeField] float groundRadius = 0.2f;
	[SerializeField] float jumpForce = 700f; //use 800f 

	[SerializeField] float forceJA = -30f;

	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask whatIsGround;

	private bool doubleJump = false;

	private Animator anim;
	private Rigidbody2D r2;
	private PlayerState pState;
	private SoundsInGame sound;
	//private int statePlayer;

	const string animGround = "Ground";
	const string animDoubleJump = "DoubleJump";
	const string animAttacking = "Attacking";
	const string animJumpAttack = "JumpAttack";

	const string animJump = "Jump";
	const string animDJump = "DJump";

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		r2 = GetComponent<Rigidbody2D> ();
		pState = GetComponent<PlayerState> ();
		sound = GameObject.FindGameObjectWithTag ("Sounds").GetComponent<SoundsInGame> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		//statePlayer = pState.getStatePlayer();

		jumpForKeyBoard ();
		jumpAttackForKeyBoard ();

		// Tao toc do roi nhanh
		if (grounded) {
			r2.gravityScale = 1f;
			// tao ma sat
			r2.velocity = new Vector2 (r2.velocity.x * 0.7f, r2.velocity.y);
		} else {
			r2.gravityScale = 2f;
		}
			
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool (animGround, grounded);
		setJump ();

	}

	//for windown
	public void jumpForKeyBoard(){
		if (Input.GetKeyDown (KeyCode.Space) && pState.getCanMove() && (grounded || !doubleJump)) {
			if (grounded) {
				grounded = false;
				anim.SetBool (animGround, grounded);
				//r2.AddForce (Vector2.up * jumpForce);
				r2.AddForce(new Vector2(0f, jumpForce));
				anim.Play (animJump);

				sound.playSound (4);
				//anim.SetBool (animAttacking, false);
			}else if (!doubleJump) {
				doubleJump = true;
				anim.SetBool (animDoubleJump, doubleJump);
				//r2.AddForce (Vector2.up * jumpForce * 0.8f);
				r2.AddForce(new Vector2(0f, jumpForce* 0.8f));
				anim.Play (animDJump);
				//anim.SetBool (animAttacking, false);
				sound.playSound (4);
			} 

			// tao ma sat va roi nhanh hon khi nhay
			//r2.velocity = new Vector2 (r2.velocity.x * 0.05f, r2.velocity.y);
		}
	}

	public void jumpAttackForKeyBoard(){
		if(Input.GetKeyDown(KeyCode.J) && pState.getFrozenPlayer() < 0 && !anim.GetBool(animAttacking) && doubleJump) {
			r2.velocity = new Vector2 (0, forceJA);
			anim.Play (animJumpAttack);
		}
	}

	// for android
	public void jump(){
		if (pState.getCanMove() && (grounded || !doubleJump)) {
			if (grounded) {
				grounded = false;
				anim.SetBool (animGround, grounded);
				//r2.AddForce (Vector2.up * jumpForce);
				r2.AddForce(new Vector2(0f, jumpForce));
				anim.Play (animJump);
				//anim.SetBool (animAttacking, false);
				sound.playSound (4);
			}else if (!doubleJump) {
				doubleJump = true;
				anim.SetBool (animDoubleJump, doubleJump);
				//r2.AddForce (Vector2.up * jumpForce * 0.8f);
				r2.AddForce(new Vector2(0f, jumpForce* 0.8f));
				anim.Play (animDJump);
				//anim.SetBool (animAttacking, false);
				sound.playSound (4);
			} 

			// tao ma sat va roi nhanh hon khi nhay
			//r2.velocity = new Vector2 (r2.velocity.x * 0.05f, r2.velocity.y);
		}
	}

	public void jumpAttack(){
		if(pState.getFrozenPlayer() < 0 && !anim.GetBool(animAttacking) && doubleJump) {
			r2.velocity = new Vector2 (0, forceJA);
			anim.Play (animJumpAttack);
			sound.playSound (4);
		}
	}

	void setJump(){
		if (grounded) {
			doubleJump = false;
			anim.SetBool (animDoubleJump, doubleJump);
		} 
	}

}
