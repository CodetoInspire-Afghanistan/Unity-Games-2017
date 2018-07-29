using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingPlatform : MonoBehaviour {
	Rigidbody2D rigid;
	Vector3 crPos;
	void Start () {
		
		rigid = GetComponent<Rigidbody2D> ();
		crPos = transform.position;
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("PlayerFeet")){
			
			Invoke ("FallDown",0.5f);
			//Destroy (gameObject,2f);
			
		}

	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("Fire")) {
//			GameCtrl.instance.showPlatform = true;
			gameObject.SetActive(false);
		}
	}
	void FallDown(){
		rigid.bodyType = RigidbodyType2D.Dynamic;
		Invoke ("ResetPlatformsPosition",3);
	}

	void ResetPlatformsPosition(){
		gameObject.SetActive(true);

		rigid.bodyType = RigidbodyType2D.Kinematic;
		transform.position = crPos;
	}
}
