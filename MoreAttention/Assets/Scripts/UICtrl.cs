using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// User interface ctrl.
/// </summary>
public class UICtrl : MonoBehaviour {
	
	    #region: PUBLIC VARIABLES
		public GameObject player;
	    #endregion

	    #region: PRIVATE VARIABLES
		PlayerCtrl playerController;
	    #endregion

	    #region: MONOBEHAVIOR METHODS
		// Use this for initialization
		void Start () {
			playerController = player.GetComponent<PlayerCtrl> ();
		}
	    #endregion

	    #region: PUBLIC METHODS
		public void MoveLeft(){
			playerController.MoveLeft ();
		}

		public void MoveRight(){
			playerController.MoveRight ();
		}
		
		public void StopMovingPlayer(){
			playerController.StopMovingPlayer ();
		}
	    #endregion
	}


