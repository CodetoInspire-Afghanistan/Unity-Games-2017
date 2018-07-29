using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampCtrl : MonoBehaviour {
	
	#region: PUBLIC VARIABLES
	public GameObject popUpScore;
	public Transform popUpScoreSpawner;
	public GameObject lampOn;

	#endregion



	#region: MONOBEHAVIOR METHODS


	public void OnMouseDown(){
		
			gameObject.GetComponentInChildren<Light> ().enabled = false;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			lampOn.SetActive (false);
			AudioCtrl.instance.SwitchOff (transform.position);
			Instantiate (popUpScore, popUpScoreSpawner.position, Quaternion.identity);
			GameCtrl.instance.UpdateScore ();

	}
	#endregion
}
