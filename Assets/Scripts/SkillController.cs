using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Phu trach viec khoi tao va xu ly cac doi tuong Ky nang
public class SkillController : MonoBehaviour {
	[SerializeField] bool isSkill2;
	[SerializeField] float verX = 40f;
	[SerializeField] float verY;
	[SerializeField] float lifeTime;
	private Rigidbody2D r2;
	public bool canRun = false;

	[SerializeField] Collider2D box2D;

	public GameObject thisEnemySkilling {get; set;}

	private float timeDown = 2f;

	// Use this for initialization
	void Awake () {
		//verX = 40f;
		box2D.enabled = true;
		Vector3 localScale = transform.localScale;
		//Debug.Log ("game object: " + gameObject.name);
		if (verX < 0) {
			localScale.x *= -1;
			transform.localScale = localScale;
		}
	}

	void Start(){
		r2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, lifeTime);

		timeDown -= Time.deltaTime;
		if (isSkill2 && timeDown < 0) {
			timeDown = 2f;
			box2D.enabled = true;
		} else if (isSkill2 && timeDown > 1) {
			//box2D.enabled = false;
		}

		if (canRun) {
			r2.velocity = new Vector2 (verX, verY);
			//Invoke ("destroyGameobject", lifeTime);

		}
	}

	void destroyGameobject(){
		foreach (Transform child in transform) {
			child.GetComponent < ParticleSystem> ().Stop ();
			Destroy (child.gameObject, 3f);
		}
		transform.DetachChildren ();
		Destroy (gameObject);
	}

	public void setVerX(int temp){
		if (temp * verX < 0) {
			verX = -verX;
			flip ();
		}
	}

	public void setCanRun(bool value){
		canRun = value;
	}

	void flip(){
		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
	}

	public void setBox2D(){
		box2D.enabled = false;
	}




}
