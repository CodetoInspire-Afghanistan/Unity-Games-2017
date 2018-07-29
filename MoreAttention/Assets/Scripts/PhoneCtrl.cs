using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCtrl : MonoBehaviour {
	#region: PUBLIC VARIABLES
	public GameObject cable;
	public GameObject hideCharger;
	public GameObject phoneCharging;
	public GameObject popUpScore;
	public Transform popUpScoreSpawner;
	//public GameObject batteryAudio;
	#endregion

	#region: MONOBEHAVIOR METHODS

	void OnMouseDown(){
			Destroy (gameObject);
			cable.gameObject.SetActive (false);
			hideCharger.gameObject.SetActive (true);
			phoneCharging.gameObject.SetActive (false);
			//tvProgramAudio.SetActive (false);
			Instantiate (popUpScore, popUpScoreSpawner.position, Quaternion.identity);
			GameCtrl.instance.MinesScore ();

	}
	#endregion
}
