using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCtrl : MonoBehaviour {
	public GameObject lamp;
	bool isOn; 
	void Start () {
		isOn = true;

	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Player")){
			lamp.GetComponent<Animator> ().enabled = true;

			play ();
		GameCtrl.instance.currentCheckPoint = gameObject;
			isOn = false;
		}
	}
	void play(){
		if (isOn) {
			SFXCtrl.instance.SavePoint (lamp.transform.position);
			AudioController.instance.KeyFound (lamp.transform.position);
		}
	}
}
