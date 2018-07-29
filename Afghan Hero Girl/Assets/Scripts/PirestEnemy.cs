using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirestEnemy : MonoBehaviour {


	public static PirestEnemy instance;
	SpriteRenderer sr;
	public GameObject LeftenemyBullet;
	public Transform LeftenemyBulletSpawnner;
	public float time;
	public bool fire;
	Animator anim;

	void Awake(){
		if (instance == null)
			instance = this;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if(time<0){
			Invoke ("fireBullet",0.1f);
			time = 3;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("PlayerSeeArea")) {
			anim.SetInteger ("State1",1);
			fire = true;
		}
	}

	void fireBullet(){
		if (fire) {
			
			Instantiate (LeftenemyBullet, LeftenemyBulletSpawnner.position, Quaternion.identity);
			AudioController.instance.PirestBullet (LeftenemyBulletSpawnner.position);

		}
	}

}
