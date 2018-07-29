using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	Rigidbody2D rb;
	public Vector2 vel;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = vel;
	}
		
	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.CompareTag ("Enemy")) {

			GameCtrl.instance.BulletHitEnemy (other.gameObject.transform);
			Destroy (gameObject);
			SFXCtrl.instance.enemyDied (other.transform.position);
			AudioController.instance.EnemyHit (other.transform.position);
		}if (other.gameObject.CompareTag ("PurpleWizard")) {

			GameCtrl.instance.BulletHitEnemy (other.gameObject.transform);
			Destroy (gameObject);
			SFXCtrl.instance.purpleWizard (other.transform.position);
			AudioController.instance.EnemyHit (other.transform.position);
		}
		if (other.gameObject.CompareTag ("PrisetEnemy")) {

			GameCtrl.instance.BulletHitEnemy (other.gameObject.transform);
			Destroy (gameObject);
			SFXCtrl.instance.PrisetEnemy(other.transform.position);
			AudioController.instance.EnemyHit (other.transform.position);

		}
		if (other.gameObject.CompareTag ("LevelOneBoss")) {

			BossHealthBar.health -= 5;
		}
		else if (!other.gameObject.CompareTag ("Player")) {

			Destroy (gameObject);
		}
	}

}
