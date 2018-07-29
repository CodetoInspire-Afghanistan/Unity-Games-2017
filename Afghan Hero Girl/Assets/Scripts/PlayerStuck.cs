using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour {

	public GameObject player;
	PlayerCtrl plCtrl;

	// Use this for initialization
	void Start () {
		plCtrl = player.GetComponent<PlayerCtrl> ();
	}

	void OnTriggerEnter2D(){
		plCtrl.isStuck = true;
	}
	void OnTriggerStay2D(){
		plCtrl.isStuck = true;
	}

	void OnTriggerExit2D(){
		plCtrl.isStuck = false;
	}
}
