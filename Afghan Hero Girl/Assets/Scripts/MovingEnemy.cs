using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

	SpriteRenderer sr;
	public Transform pos1,pos2;
	public float speed;
	Vector3 nextPos;
	public Transform StartPos;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		nextPos = StartPos.position;
	}

	// Update is called once per frame
	void Update () {
		if(transform.position==pos1.position){

			nextPos=pos2.position;
			sr.flipX = false;
		}
		if(transform.position==pos2.position){
			nextPos=pos1.position;
			sr.flipX = true;

		}
		transform.position = Vector3.MoveTowards (transform.position, nextPos, speed * Time.deltaTime);

	}
}

