using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour {

	public GameObject player;
	PlayerCtrl playerController;


	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerCtrl> ();
	}
	

	public void MoveLeft(){
		playerController.MoveLeft ();
	}
	public void MoveRight(){
		playerController.MoveRight ();
	}
	public void JumpPlayer(){
		playerController.JumpPlayer ();

	}
	public void FirePlayer(){
		playerController.PlayerFire ();

	}
	public void BottleFire(){
		playerController.BottleFire ();
		ServitorCtrl.instance.isTuoch = true;
	}
	public void StopMovingPlayer(){
		playerController.StopMoveingPlayer ();
	}

}
