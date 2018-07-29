using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player ctrl.
/// </summary>
public class PlayerCtrl : MonoBehaviour {

	#region: PUBLIC VARIABLES
	public float boostSpeed;
	public bool isMoveLeft;
	public bool isMoveRight;
	public bool canMove;
	public Transform pos1;
	public Transform pos2;
	Vector3 pos;
	#endregion

	#region: PRIVATE VARIABLES
	Rigidbody2D rigid;
	#endregion

	#region: MONOBEHAVIOR METHODS

	//Use this for initialization
	void Start () {
		canMove = false;
		rigid = GetComponent<Rigidbody2D> ();
	}
	

	void Update () {

		pos = transform.position;
		pos.x = Mathf.Clamp (transform.position.x,-80f,0.7f);
		transform.position = pos;
		if(canMove){
		float playerSpeed = Input.GetAxisRaw ("Horizontal")*boostSpeed;
		if (playerSpeed != 0) {
			CameraMove (playerSpeed);
		} else {
			StopMoving ();
		}
		if (isMoveLeft) {
			CameraMove (-boostSpeed);
		} 
		else if(isMoveRight) {
			CameraMove (boostSpeed);
		}
		}
	}
	#endregion

	#region: PRIVATE METHODS
	void CameraMove(float playerSpeed){
		rigid.velocity= new Vector2(playerSpeed, 0);
	}

	public void StopMoving(){
		rigid.velocity = new Vector2 (0, rigid.velocity.y);
	}
	#endregion

	#region: PUBLIC METHODS
	public void MoveLeft(){
		isMoveLeft = true;
	}

	public void MoveRight(){
		isMoveRight = true;
	}

	public void StopMovingPlayer(){
		isMoveLeft = false;
		isMoveRight = false;
		StopMoving ();
	}
	#endregion
}
