using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public Vector2 speed;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		rb.velocity = speed;
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			SFXCtrl.instance.Blood (other.transform.position);
			AudioController.instance.PlayerDie (other.gameObject.transform.position);
			Destroy (gameObject);
			GameCtrl.instance.PlayerDied(other.gameObject);
		}
	}   
		
}
