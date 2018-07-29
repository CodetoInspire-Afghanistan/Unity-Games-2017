using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneBossCtrl : MonoBehaviour {
	
	public Transform leftEdge, rightEdge,pos1,pos2;
	 Vector3 pos;
	public float speed;
	float originalSpeed;
	bool CanTurn;
	private Rigidbody2D rb;
	private SpriteRenderer sr;
	public float MaxDelay, MinDelay;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		anim= GetComponent<Animator> ();
		CanTurn = true;
		SetStartingDirection ();
	}

	// Update is called once per frame
	void Update () {
		pos = transform.position;
		pos.x = Mathf.Clamp (transform.position.x,pos1.transform.position.x,pos2.transform.position.x);
		transform.position=pos;
		Move ();
		FlipOnEdges ();
	}
	void SetStartingDirection(){
		if(speed>0){
			sr.flipX = true;
		}else if(speed<0){
			sr.flipY = false;
		}
	}
	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine (leftEdge.position,rightEdge.position);
	}

	IEnumerator TurnLeft(float originalSpeed){
		anim.SetInteger ("State",0);
		yield return new WaitForSeconds (Random.Range (MinDelay, MaxDelay));
		sr.flipX = false;
		speed = -originalSpeed;
		CanTurn = true;


	}
	IEnumerator TurnRight(float originalSpeed){
		anim.SetInteger ("State",0);
		yield return new WaitForSeconds (Random.Range (MinDelay, MaxDelay));
		sr.flipX = true;
		speed = -originalSpeed;
		CanTurn = true;
	}
	void Move(){
		Vector2 temp = rb.velocity;
		temp.x = speed;
		rb.velocity = temp;
	}
	void FlipOnEdges(){
		if(sr.flipX && transform.position.x>=rightEdge.position.x){
			if(CanTurn){
				CanTurn = false;
				originalSpeed = speed;
				speed = 0;
				StartCoroutine ("TurnLeft",originalSpeed);
			}

		}else if(!sr.flipX && transform.position.x<=leftEdge.position.x){
			if(CanTurn){
				CanTurn = false;
				originalSpeed = speed;
				speed = 0;
				StartCoroutine ("TurnRight",originalSpeed);

			}
		}
	}

}
