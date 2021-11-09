using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// lop nay xu ly logic giua cac trang thai cua Enemy (bi tan cong, chet)
public class EnemyState : MonoBehaviour {

	[SerializeField] bool isBoss;
	[SerializeField] int numCanAttack;
	private int numOfBeHurt = 0;

	private Rigidbody2D r2;
	//private Transform tran;
	private Animator anim;

	private EnemyMove eMove;
	private EnemyAttack eAttack;

	[SerializeField] PlayerStat statHealth;
	[SerializeField] PlayerStat statMana;
	[SerializeField] float timeDisplayerHealth;
	[SerializeField] GameObject barObject;

	[SerializeField] float reHealth = 5;
	[SerializeField] float reMana = 5;

	public float currentHealth { get; set;}
	private bool isDead = false;
	public float currentMana { get; set;}

	private EnemyInfo eInfo;
	private LootScript dropItem;

	private const string animHurt = "Hurt";
	private const string animKnocked = "Knocked";

	[SerializeField] float timeCount;

	[SerializeField] float timeReturnIdle;

	[SerializeField] GameObject dmgPartical;
	[SerializeField] Transform posEffect;

	private EnemySound sound;

	void Start(){
		r2 = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		//tran = GetComponent<Transform> ();
		eMove = GetComponent<EnemyMove> ();
		eAttack = GetComponent<EnemyAttack> ();
		eInfo = GetComponent<EnemyInfo> ();
		sound = GetComponentInChildren<EnemySound> ();

		dropItem = GetComponentInChildren<LootScript> ();

		eInfo.setStatFollowLevel ();
		statHealth.setValueBar (eInfo.maxHealth, eInfo.maxHealth);
		statMana.setValueBar (eInfo.maxMana, eInfo.maxMana);
		currentHealth = eInfo.maxHealth;
		currentMana = eInfo.maxMana;
	}

	void Update(){

		timeCount -= Time.deltaTime;
		timeDisplayerHealth -= Time.deltaTime;

		currentMana += Time.deltaTime * reHealth;
		currentHealth += Time.deltaTime * reMana;

		if (timeDisplayerHealth < 0) {
			barObject.SetActive (false);
		}

		if (currentHealth <= 0 && !isDead) {
			//beDead ();
		} else {
			statHealth.CurrentValue = currentHealth;
			currentHealth = statHealth.CurrentValue;
		}

		if (currentMana < 0) {
			currentMana = 0;
		} else if(currentMana > eInfo.maxMana){
			currentMana = eInfo.maxMana;
		}

		statMana.CurrentValue = currentMana;

		//Debug.Log ("Current mana: " + currentMana);
	}

	public void beHurt(int wayAttacked, float x, float posX, float dmg){
		Destroy(Instantiate (dmgPartical, posEffect), 0.5f);

		float tempPos = posX - gameObject.transform.position.x;
		//eMove.setFacingToPlayer ((float)wayAttacked);
		eMove.setFacingToPlayer (tempPos);
		if (tempPos> 0) {
			wayAttacked = -1;
		} else {
			wayAttacked = 1;
		}

		/*
		if (tempPos > 0) {
			//eMove.facingToPlayer();
			////eMove.flipToRight();
			r2.AddForce (new Vector2 (-x, 0));
			//StartCoroutine (waitEndTimeAnim (time));
		} else if (tempPos < 0) {
			//eMove.flipToLeft ();
			r2.AddForce (new Vector2 (x, 0));
			//StartCoroutine (waitEndTimeAnim (time));
		} 
		*/
		r2.AddForce (new Vector2 (x*wayAttacked, 0));

		anim.Play (animHurt);
		eMove.setIdle ();
		timeCount = getTimeOfAnimation (animHurt);

		barObject.SetActive (true);
		timeDisplayerHealth = 10f;

		currentHealth -= dmg;

		if (currentHealth <= 0) {
			beDead ();
		} else {
			numOfBeHurt++;

			eAttack.resetAttack ();
		}

	}

	public void beKnocked(int wayAttacked, float[] force, float posX, float dmg){
		
		float tempPos = posX - gameObject.transform.position.x;
		//eMove.setFacingToPlayer ((float)wayAttacked);
		eMove.setFacingToPlayer (tempPos);
		if (tempPos> 0) {
			wayAttacked = -1;
		} else {
			wayAttacked = 1;
		}

		if (!isBoss) {
			/*
			if (tempPos > 0) {
				//eMove.facingToPlayer();
				r2.AddForce (new Vector2 (-force [0], force [1]));
				//StartCoroutine (waitEndTimeAnim (time));
			} else if (tempPos < 0) {
				r2.AddForce (new Vector2 (force [0], force [1]));
				//StartCoroutine (waitEndTimeAnim (time));
			} 
			*/
			Destroy(Instantiate (dmgPartical, posEffect), 0.5f);
			r2.AddForce (new Vector2 (force [0]*wayAttacked, force [1]));

			anim.Play (animKnocked);
		} else {
			/*
			if (tempPos > 0) {
				//eMove.facingToPlayer();
				r2.AddForce (new Vector2 (-force [0], 0));
				//StartCoroutine (waitEndTimeAnim (time));
			} else if (tempPos < 0) {
				r2.AddForce (new Vector2 (force [0], 0));
				//StartCoroutine (waitEndTimeAnim (time));
			} 
			*/
			Destroy(Instantiate (dmgPartical, posEffect), 0.5f);
			r2.AddForce (new Vector2 (force [0]*wayAttacked, 0));

			anim.Play (animHurt);
		}

		sound.playSound (6);

		eMove.setIdle ();
		timeCount = timeReturnIdle;

		barObject.SetActive (true);
		timeDisplayerHealth = 10f;
		currentHealth -= dmg;

		if (currentHealth <= 0) {
			beDead ();
		} else {
			numOfBeHurt++;

			eAttack.resetAttack ();
		}
	}

	public void beDead (){
		//Debug.Log ("Enemy die is: " + gameObject.name);
		isDead = true;
		//itemPrefabs [0].SetActive (true);
		dropItem.calculateLoot(eInfo.getIdEnemy(), eInfo.getLevel());

		FloatTextController.createFloatingText (5, "+"+((int)eInfo.enemyXp).ToString (), eMove.getTarget());

		// update for playerInfo
		GameInfo.NumEnemyAlive--;
		GameInfo.Bounty += (int)eInfo.enemyScore;
		LevelUpSystem.UpdateXp ((int)eInfo.enemyXp);

		barObject.SetActive (false);
		anim.SetFloat ("FrozenEnemy", 3600f);
		anim.Play ("Dead");
		Destroy (gameObject, 10f);

		sound.playSound (7);
	}

	public bool getCanDo(){
		if (timeCount < 0) {
			return true;
		} else {
			return false;
		}
	}

	public bool getIsDead(){
		return isDead;
	}

	public int getNumOfBeHurt(){
		return numOfBeHurt;
	}

	public int getNumCanAttack(){
		return numCanAttack;
	}

	public void resetNumOfBeHurt(){
		numOfBeHurt = 0;
	}

	float getTimeOfAnimation(string nameOfAnim){
		float time = 0;
		RuntimeAnimatorController ac = anim.runtimeAnimatorController;   

		for (int i = 0; i < ac.animationClips.Length; i++)
			if (ac.animationClips[i].name == nameOfAnim)
				time = ac.animationClips[i].length;

		return time;
	}

}
