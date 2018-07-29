using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWashing : MonoBehaviour {

	#region: PUBLIC VARIABLES
	public GameObject popUpScore;
	public Transform popUpScoreSpawner;
	public GameObject washingMachin;
	WashingMachinCtrl washingMachineCtrl;
	#endregion

	#region: MONOBEHAVIOR METHODS

	public void OnMouseDown(){
		//Destroy (gameObject);
			AudioCtrl.instance.SwitchOff (transform.position);
			gameObject.GetComponent<Collider2D> ().enabled = false;
			washingMachin.GetComponent<WashingMachinCtrl> ().enabled = false;
			Instantiate (popUpScore, popUpScoreSpawner.position, Quaternion.identity);
			GameCtrl.instance.MinesScore ();

	}
	#endregion
}
