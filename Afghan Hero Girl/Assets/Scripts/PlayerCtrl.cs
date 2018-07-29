using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Player ctrl.
/// </summary>
public class PlayerCtrl : MonoBehaviour {

	public float jumpSpeed;
	public float boostSpeed;
	public float boxHeight;
	public float boxWidth;
	public bool isGrounded;
	public Transform feet;
	public LayerMask whatIsGrounded;
	public float doubleJumpDelay;
	public bool canDoubleJump;
	public bool canfire;
	public bool hasBottle;

	public GameObject leftBullet;
	public GameObject RightBullet;
	public Transform LeftBulletSpawnner;
	public Transform RightBulletSpawnner;
	public GameObject leftMagic;
	public GameObject RightMagic;
	public Transform LeftMagicSpawnner;
	public Transform RightMagicSpawnner;
	public GameObject door;
	public GameObject leftBottleBullet;
	public GameObject RightBottleBullet;

	public bool isJumping;
	public bool isMoveLeft;
	public bool isMoveRight;
	public bool isStuck;
	public bool attack;
	public bool onLadder;
	private float vertical;
	Rigidbody2D rb;
	Animator anim;
	SpriteRenderer sr;

	string oldFireTag;
	string oldEnemyTag;
	string oldObstacleTag;
	string oldKillerTag;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapBox (feet.position,new Vector2(boxWidth,boxHeight),360.0f,whatIsGrounded);
		float playerSpeed = Input.GetAxisRaw ("Horizontal");
		playerSpeed *= boostSpeed;
		 vertical = Input.GetAxisRaw ("Vertical");

		if (playerSpeed != 0)
			MoveHorizontal (playerSpeed);
		else
			StopMoving ();

		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}

		Falling ();

		if (isMoveLeft) {
			MoveHorizontal(-boostSpeed);
		} else if (isMoveRight) {
			MoveHorizontal(boostSpeed);
		  }
        if (Input.GetKeyDown(KeyCode.LeftShift)){
          
			BottleBullet();
			HundleBAttack ();


        }
        ResetValue();
		if(Input.GetButtonDown("Fire1")){
			attack = true;
			HundleAttack();
			fireBullet ();

		}
	}

	void MoveHorizontal(float playerSpeed){

		if (playerSpeed > 0)
			sr.flipX = false;
		else
			sr.flipX = true;
		rb.velocity = new Vector2 (playerSpeed,rb.velocity.y);
		if(!isJumping)
			anim.SetInteger ("State",1);
	}



	void StopMoving(){
		rb.velocity = new Vector2 (0,rb.velocity.y);
		if(!isJumping)
			anim.SetInteger ("State",0);

	}

    void HundleAttack(){
        if (attack){
			anim.SetTrigger("Throw-attack");

        }
    }

	void HundleBAttack(){
		if (GameCtrl.instance.data.magicBottleCounter > 0){
			anim.SetTrigger("Attack");
			}
	}

    void ResetValue(){
        attack = false;

    }

	private void Jump(){
		if (isGrounded) {
			isJumping = true;
			rb.AddForce (new Vector2 (0, jumpSpeed));
			anim.SetInteger ("State", 2);
			AudioController.instance.PlayerJump (transform.position);
			Invoke ("EnableDoubleJump",doubleJumpDelay);
		}
		if(canDoubleJump && !isGrounded){
			rb.velocity = Vector2.zero;
			rb.AddForce (new Vector2(0,jumpSpeed));
			anim.SetInteger ("State", 2);
			AudioController.instance.PlayerJump (transform.position);
			canDoubleJump = false;
			
		}
	}

	void EnableDoubleJump(){
		canDoubleJump = true;
	}

	void Falling(){
		if (rb.velocity.y < 0) {
			anim.SetInteger ("State", 0);
		}
	}

	void BottleBullet(){
		if (GameCtrl.instance.data.magicBottleCounter > 0) {

			if (sr.flipX) {
				Instantiate (leftBottleBullet, LeftBulletSpawnner.position, Quaternion.identity);

			}
			else {
				Instantiate (RightBottleBullet, RightBulletSpawnner.position, Quaternion.identity);
			}

			GameCtrl.instance.LessMagicBottle_Servitor();
			HundleBAttack ();

		}
	}

	void fireBullet(){
		if (canfire) {

			if (sr.flipX) {
				Instantiate (leftBullet, LeftBulletSpawnner.position, Quaternion.identity);

			}
			else {
				Instantiate (RightBullet, RightBulletSpawnner.position, Quaternion.identity);
			}
			attack = true;
			HundleAttack ();
			AudioController.instance.FireBullet (transform.position);
		}
	}


	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag ("Killer")) {
			oldKillerTag = other.gameObject.tag;
			other.gameObject.tag = "Untagged";
			StartCoroutine ("ResetKillerTags",other);

			SFXCtrl.instance.Blood (transform.position);
			AudioController.instance.PlayerDie (transform.position);
			GameCtrl.instance.PlayerDied (gameObject);
		}
		if (other.gameObject.CompareTag ("Fire")) {
			oldFireTag = other.gameObject.tag;
			other.gameObject.tag = "Untagged";
			StartCoroutine ("ResetFireTags",other);
			SFXCtrl.instance.Fire (transform.position);
			AudioController.instance.PlayerDie (transform.position);
			GameCtrl.instance.PlayerDied (gameObject);

		}
		if (other.gameObject.CompareTag ("obstacle")) {
			oldObstacleTag = other.gameObject.tag;

			other.gameObject.tag = "Untagged";
			StartCoroutine ("ResetObstacleTags",other);
			SFXCtrl.instance.Blood (transform.position);
			AudioController.instance.PlayerDie (transform.position);
			GameCtrl.instance.PlayerDied (gameObject);
		}
		if (other.gameObject.CompareTag ("Enemy")) {
			oldEnemyTag = other.gameObject.tag;

			other.gameObject.tag = "Untagged";
			StartCoroutine ("ResetEnemyTags",other);
			AudioController.instance.PlayerDie (transform.position);
			SFXCtrl.instance.Blood (other.transform.position);
			GameCtrl.instance.PlayerDied (gameObject);

		}
		if (other.gameObject.CompareTag ("PurpleWizard")) {
			AudioController.instance.PlayerDie (transform.position);
			GameCtrl.instance.PlayerDied (gameObject);
		}
		if (other.gameObject.CompareTag ("PrisetEnemy")) {
			AudioController.instance.PlayerDie (transform.position);
			GameCtrl.instance.PlayerDied (gameObject);
		}
	
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (feet.position,new Vector3(boxWidth,boxHeight,0));
	}

	public void MoveLeft(){
		isMoveLeft = true;
	}
	public void MoveRight(){
		isMoveRight = true;
	}
	public void BottleFire(){
		BottleBullet ();
	}
	public void JumpPlayer(){
		Jump ();
	}
	public void StopMoveingPlayer(){
		isMoveLeft = false;
		isMoveRight = false;
		StopMoving ();
	}
	public void PlayerFire(){
		fireBullet ();
	}


	public void OnTriggerEnter2D(Collider2D other){

		switch(other.gameObject.tag){

		case "NextLevel":
			gameObject.SetActive(false);
			GameCtrl.instance.LevelComplete();

			break;

		case "Stop":
			GameCtrl.instance.stopCameraFollow ();
			if(GameCtrl.instance.canOpenDoor){
				GameCtrl.instance.OpenDoor ();
			}
			break;
		
		
		default:
			break;

		}

	}


	IEnumerator ResetFireTags(Collision2D other){
		yield return new WaitForSeconds (1f);
		other.gameObject.tag = oldFireTag;
	}

	IEnumerator ResetEnemyTags(Collision2D other){
		yield return new WaitForSeconds (1f);
		other.gameObject.tag = oldEnemyTag;
	}
	IEnumerator ResetObstacleTags(Collision2D other){
		yield return new WaitForSeconds (2f);
		other.gameObject.tag = oldObstacleTag;
	}
	IEnumerator ResetKillerTags(Collision2D other){
		yield return new WaitForSeconds (2f);
		other.gameObject.tag = oldKillerTag;
	}


}



		
	


