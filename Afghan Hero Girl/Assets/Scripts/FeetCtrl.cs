using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour {


	PlayerCtrl playerCtrl;
	public GameObject Player;
	// Use this for initialization
	void Start () {
		playerCtrl =gameObject.transform.parent.gameObject.GetComponent<PlayerCtrl> ();
	}
		
    void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag=="Ground"){
			SFXCtrl.instance.PlayerLand (gameObject.transform.position);
			playerCtrl.isJumping = false;
		}

        if(col.gameObject.tag=="Platform"){
			playerCtrl.isJumping = false;
			SFXCtrl.instance.PlayerLand (gameObject.transform.position);
            Player.transform.parent = col.gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.CompareTag ("Platform")) {
            Player.transform.parent = null;
        }
    }
}



